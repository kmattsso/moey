using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using Brushes = System.Windows.Media.Brushes;


namespace Moey
{

    public partial class GraphOverTime : UserControl
    {

        String purposes;
        String types;
        String descriptions;
        
        int Owner { get; }

        public GraphOverTime(int owner_sk)
        {
            InitializeComponent();
            Owner = owner_sk;

            dateTimePickerStart.MinDate = Program.startDate;
            dateTimePickerStart.MaxDate = DateTime.Today.Date;
            dateTimePickerStart.Value = Program.startDate;
            dateTimePickerEnd.MinDate = Program.startDate;
            dateTimePickerEnd.MaxDate = DateTime.Today.Date;
            dateTimePickerEnd.Value = Program.endDate;

            dateTimePickerEnd.ValueChanged += DateTimePicker_ValueChanged;
            dateTimePickerStart.ValueChanged += DateTimePicker_ValueChanged;

            DataTable purpose = Program.sqlApp.CreateDataTable(
                "SELECT DISTINCT d.purpose " +
                "FROM description d, " +
                "( " +
                "    SELECT description_sk " +
                "    FROM balance " +
                "    WHERE amount != 0 " +
                "    UNION " +
                "    SELECT description_sk " +
                "    FROM accrued " +
                "    WHERE amount != 0 " +
                ") x " +
                "WHERE d.description_sk = x.description_sk " +
                "AND d.owner_sk = @p1 " +
                "ORDER BY purpose;",
                new SqlDbType[] { SqlDbType.Int },
                new object[] { Owner });


            foreach (DataRow dr in purpose.Rows)
            {
                checkedListBoxPurpose.Items.Add(dr["purpose"].ToString(), true);
            }
            CheckedListBoxPurpose_SelectedIndexChanged(null, null);
        }

   

        private void RefreshGraph()
        {
            LineSeries line_series = null;
            ChartValues<DateTimePoint> chart_values = new ChartValues<DateTimePoint>();

            double balance = 0d, accrued = 0d, transaction = 0d, offset = 0d;
            int x;
            DateTime dataPointTime;
            SortedList<DateTime, Double> datapointsBalance = new SortedList<DateTime, Double>();
            SortedList<DateTime, Double> datapointsAccrued = new SortedList<DateTime, Double>();
            SortedList<DateTime, Double> datapointsTransaction = new SortedList<DateTime, Double>();
            SortedList<DateTime, Double> datapoints = new SortedList<DateTime, Double>();
            SortedList<int, SortedList<DateTime, Double>> datapointsAll = new SortedList<int, SortedList< DateTime, Double >> ();


            var dayConfig = Mappers.Xy<LiveChartDateModel>()
                    .X(dateModel => dateModel.DateTime.Ticks / (TimeSpan.FromDays(1).Ticks * 30.44))
                    .Y(dateModel => dateModel.Value);
            SeriesCollection series_collection = new SeriesCollection(dayConfig);

            //balance
            DataTable dataBalance = Program.sqlApp.CreateDataTable(
                "SELECT b.date_sk, " +
                "       date, " +
                "       DATEADD(d, (7 - DATEPART(dw, date)) + 1, date) week, " +
                "       EOMONTH(date) mon, " +
                "       d.purpose, " +
                "       d.description_sk, " +
                "       d.description, " +
                "       b.amount " +
                "FROM balance b, " +
                "     description d, " +
                "     agent a, " +
                "     date " +
                "WHERE b.description_sk = d.description_sk " +
                "      AND b.date_sk = date.date_sk " +
                "      AND d.agent_sk = a.agent_sk " +
                "      AND b.active_fl = 1 " +
                "      AND a.owner_sk = @p1 " +
                "      AND d.purpose in (" + purposes + ") " +
                "      AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "      AND date.date <= @p2 " +
                "ORDER BY description_sk, " +
                "         b.date_sk; ",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.DateTime2 },
                new object[] { Owner, dateTimePickerEnd.Value.Date });

            //accrued
            DataTable dataAccrued = Program.sqlApp.CreateDataTable(
                "SELECT b.date_sk, " +
                "       date, " +
                "       DATEADD(d, (7 - DATEPART(dw, date)) + 1, date) week, " +
                "       EOMONTH(date) mon, " +
                "       d.purpose, " +
                "       d.description_sk, " +
                "       d.description, " +
                "       b.amount " +
                "FROM accrued b, " +
                "     description d, " +
                "     agent a, " +
                "     date " +
                "WHERE b.description_sk = d.description_sk " +
                "      AND b.date_sk = date.date_sk " +
                "      AND d.agent_sk = a.agent_sk " +
                "      AND b.active_fl = 1 " +
                "      AND a.owner_sk = @p1 " +
                "      AND d.purpose in (" + purposes + ") " +
                "      AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "      AND date.date <= @p2 " +
                "ORDER BY description_sk, " +
                "         b.date_sk; ",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.DateTime2 },
                new object[] { Owner, dateTimePickerEnd.Value.Date });

            //transactions
            DataTable dataTransaction = Program.sqlApp.CreateDataTable(
                "SELECT b.date_sk, " +
                "       date, " +
                "       DATEADD(d, (7 - DATEPART(dw, date)) + 1, date) week, " +
                "       EOMONTH(date) mon, " +
                "       d.purpose, " +
                "       d.description_sk, " +
                "       d.description, " +
                "       b.amount amount " +
                "FROM [transaction] b, " +
                "     description d, " +
                "     agent a, " +
                "     date " +
                "WHERE b.description_sk = d.description_sk " +
                "      AND b.date_sk = date.date_sk " +
                "      AND d.agent_sk = a.agent_sk " +
                "      AND b.active_fl = 1 " +
                "      AND a.owner_sk = @p1 " +
                "      AND d.purpose in (" + purposes + ") " +
                "      AND d.type in (" + types + ") " +
                "      AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "      AND date.date <= @p2 " +
                "ORDER BY description_sk, " +
                "         b.date_sk; ",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.DateTime2 },
                new object[] { Owner, dateTimePickerEnd.Value.Date });

            DataTable dtTemp = Program.sqlApp.CreateDataTable(
                "SELECT DISTINCT " +
                "       description_sk, " +
                "       description, " +
                "       MAX(date) OVER(PARTITION BY 1) end_date " +
                "FROM " +
                "( " +
                "    SELECT d.description_sk, " +
                "           d.description, " +
                "           date.date " +
                "    FROM balance b, " +
                "         description d, " +
                "         agent a, " +
                "         date " +
                "    WHERE b.description_sk = d.description_sk " +
                "          AND b.date_sk = date.date_sk " +
                "          AND d.agent_sk = a.agent_sk " +
                "          AND b.active_fl = 1 " +
                "          AND a.owner_sk = @p1 " +
                "          AND d.purpose IN( " + purposes + " ) " +
                "          AND d.type in (" + types + ") " +
                "          AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "          AND date.date <= @p2 " +
                "    UNION " +
                "    SELECT d.description_sk, " +
                "           d.description, " +
                "           date.date " +
                "    FROM accrued b, " +
                "         description d, " +
                "         agent a, " +
                "         date " +
                "    WHERE b.description_sk = d.description_sk " +
                "          AND b.date_sk = date.date_sk " +
                "          AND d.agent_sk = a.agent_sk " +
                "          AND b.active_fl = 1 " +
                "          AND a.owner_sk = @p1 " +
                "          AND d.purpose IN( " + purposes + " ) " +
                "          AND d.type in (" + types + ") " +
                "          AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "          AND date.date <= @p2 " +
                "    UNION " +
                "    SELECT d.description_sk, " +
                "           d.description, " +
                "           date.date " +
                "    FROM[transaction] b, " +
                "         description d, " +
                "         agent a, " +
                "         date " +
                "    WHERE b.description_sk = d.description_sk " +
                "          AND b.date_sk = date.date_sk " +
                "          AND d.agent_sk = a.agent_sk " +
                "          AND b.active_fl = 1 " +
                "          AND a.owner_sk = @p1 " +
                "          AND d.purpose IN( " + purposes + " ) " +
                "          AND d.type in (" + types + ") " +
                "          AND a.description + ': ' + d.description in (" + descriptions + ") " +
                "          AND date.date <= @p2 " +
                ")x " +
                "ORDER BY description_sk;",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.DateTime2 },
                new object[] { Owner, dateTimePickerEnd.Value.Date });

            // Populate data
            foreach (DataRow desc in dtTemp.Rows)
            {
                foreach (DataRow dr in dataBalance.Select("description_sk = " + desc["description_sk"].ToString(), "date_sk"))
                {
                    if (datapointsBalance.ContainsKey((DateTime)dr["date"]))
                    {
                        balance = (double)(decimal)dr["amount"] + datapointsBalance[(DateTime)dr["date"]];
                        datapointsBalance.Remove((DateTime)dr["date"]);
                        datapointsBalance.Add((DateTime)dr["date"], balance);
                    }
                    else
                    {
                        datapointsBalance.Add((DateTime)dr["date"], (double)(decimal)dr["amount"]);
                        datapoints.Add((DateTime)dr["date"], 0d);
                    }
                }

                foreach (DataRow dr in dataAccrued.Select("description_sk = " + desc["description_sk"].ToString(), "date_sk"))
                {
                    if (datapointsAccrued.ContainsKey((DateTime)dr["date"]))
                    {
                        accrued = (double)(decimal)dr["amount"] + datapointsAccrued[(DateTime)dr["date"]];
                        datapointsAccrued.Remove((DateTime)dr["date"]);
                        datapointsAccrued.Add((DateTime)dr["date"], accrued);
                    }
                    else
                    {
                        datapointsAccrued.Add((DateTime)dr["date"], (double)(decimal)dr["amount"]);
                        if (!datapoints.ContainsKey((DateTime)dr["date"]))
                            datapoints.Add((DateTime)dr["date"], 0d);
                    }
                }

                foreach (DataRow dr in dataTransaction.Select("description_sk = " + desc["description_sk"].ToString(), "date_sk"))
                {
                    if (datapointsTransaction.ContainsKey((DateTime)dr["date"]))
                    {
                        transaction = (double)(decimal)dr["amount"] + datapointsTransaction[(DateTime)dr["date"]];
                        datapointsTransaction.Remove((DateTime)dr["date"]);
                        datapointsTransaction.Add((DateTime)dr["date"], transaction);
                    }
                    else
                    {
                        datapointsTransaction.Add((DateTime)dr["date"], (double)(decimal)dr["amount"]);
                        if (!datapoints.ContainsKey((DateTime)dr["date"]))
                            datapoints.Add((DateTime)dr["date"], 0d);
                    }
                }

                //Coallesce all data 
                balance = 0d;
                offset = 0d;
                accrued = 0d;
                transaction = 0d;
                
                for (int i = 0; i < datapoints.Count; i++)
                {
                    dataPointTime = datapoints.Keys[i];
                    if (datapointsBalance.ContainsKey(dataPointTime))
                        balance = datapointsBalance.Values[datapointsBalance.IndexOfKey(dataPointTime)];
                    if (datapointsAccrued.ContainsKey(dataPointTime))
                        accrued = datapointsAccrued.Values[datapointsAccrued.IndexOfKey(dataPointTime)];
                    if (checkBoxEliminateTransactions.Checked && datapointsTransaction.ContainsKey(dataPointTime))
                        transaction -= datapointsTransaction.Values[datapointsTransaction.IndexOfKey(dataPointTime)];

                    if (i == 0 && checkBoxUseFirstBalanceAs0.Checked && (balance + accrued + transaction) != 0d) offset = balance + accrued + transaction;

                    datapoints.RemoveAt(i);
                    datapoints.Add(dataPointTime, balance + accrued + transaction - offset);
                }


                // Ensure there is a last value
                if (!datapoints.ContainsKey((DateTime)desc["end_date"]) && !(balance + accrued + transaction).Equals(0d))
                    datapoints.Add((DateTime)desc["end_date"], balance + accrued + transaction - offset);


                if (checkBoxShowAsTotal.Checked)
                {
                    // Save series for later
                    datapointsAll.Add((int)(long)desc["description_sk"], datapoints);
                }
                else
                {
                    // Show now
                    line_series = new LineSeries
                    {
                        Title = desc["description"].ToString(),
                        LineSmoothness = 0,
                        Fill = Brushes.Transparent
                    };

                    chart_values = new ChartValues<DateTimePoint> { };
                    dataPointTime = dateTimePickerStart.Value.Date;
                    x = 0;
                    foreach (var pair in datapoints)
                    {
                        if (dataPointTime < dateTimePickerStart.Value.Date && pair.Key > dateTimePickerStart.Value.Date)
                        {
                            chart_values.Add(new DateTimePoint(dateTimePickerStart.Value.Date, balance));
                            x++;
                        }
                        if (pair.Key >= dateTimePickerStart.Value.Date)
                        {
                            chart_values.Add(new DateTimePoint(pair.Key, pair.Value));
                            x++;
                        }
                        dataPointTime = pair.Key;
                        balance = pair.Value;
                    }
                    line_series.Values = chart_values;
                    if (x >= 2) series_collection.Add(line_series);
                }

                datapoints = new SortedList<DateTime, Double>();
                datapointsBalance.Clear();
                datapointsAccrued.Clear();
                datapointsTransaction.Clear();
            }

            if (checkBoxShowAsTotal.Checked)
            {
                // Coalesce the whole shabang

                //Extract all dataPointTimes
                for (int i = 0; i < datapointsAll.Count; i++)
                {
                    for (int j = 0; j < datapointsAll.Values[i].Count; j++)
                    {
                        dataPointTime = datapointsAll.Values[i].Keys[j];
                        if (!datapoints.ContainsKey(dataPointTime))
                            datapoints.Add(dataPointTime, balance);
                    }
                }
                //Put all dataPointTimes in all lists
                for (int i = 0; i < datapoints.Count; i++)
                {
                    dataPointTime = datapoints.Keys[i];
                    for (int j = 0; j < datapointsAll.Count; j++)
                    {
                        if (!datapointsAll.Values[j].ContainsKey(dataPointTime))
                        {
                            datapointsAll.Values[j].Add(dataPointTime, 0d);
                            //Set correct value
                            x = datapointsAll.Values[j].IndexOfKey(dataPointTime);
                            if (x > 0)
                            {
                                datapointsAll.Values[j].RemoveAt(x);
                                datapointsAll.Values[j].Add(dataPointTime, datapointsAll.Values[j].Values[x - 1]);
                            }
                        }

                    }
                }

                // Gather data
                for (int i = 0; i < datapoints.Count; i++)
                {
                    dataPointTime = datapoints.Keys[i];
                    balance = 0d;
                    for (int j = 0; j < datapointsAll.Count; j++)
                    {
                        // Get the data for this date in all lists
                        balance += datapointsAll.Values[j].Values[i];
                    }
                    datapoints.RemoveAt(i);
                    datapoints.Add(dataPointTime, balance);
                }


                // Show now
                line_series = new LineSeries
                {
                    Title = "Total",
                    LineSmoothness = 0,
                    Fill = Brushes.Transparent
                };

                chart_values = new ChartValues<DateTimePoint> { };
                dataPointTime = dateTimePickerStart.Value.Date;
                x = 0;
                foreach (var pair in datapoints)
                {
                    if (dataPointTime < dateTimePickerStart.Value.Date && pair.Key > dateTimePickerStart.Value.Date)
                    {
                        chart_values.Add(new DateTimePoint(dateTimePickerStart.Value.Date, balance));
                        x++;
                    }
                    if (pair.Key >= dateTimePickerStart.Value.Date)
                    {
                        chart_values.Add(new DateTimePoint(pair.Key, pair.Value));
                        x++;
                    }
                    dataPointTime = pair.Key;
                    balance = pair.Value;
                }
                line_series.Values = chart_values;
                if (x >= 2) series_collection.Add(line_series);
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            cartesianChart1.Series = series_collection;
            cartesianChart1.LegendLocation = LegendLocation.Bottom;

            cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = val => new System.DateTime((long)val).ToString("yyyyMMdd")
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                LabelFormatter = val => val.ToString("N") + " SEK"
            });

            var tooltip = (DefaultTooltip)cartesianChart1.DataTooltip;
            tooltip.SelectionMode = LiveCharts.TooltipSelectionMode.OnlySender;
           

        }

        private void CheckedListBoxPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Purposes
            purposes = "'";
            for (int i = 0; i < checkedListBoxPurpose.Items.Count; i++)
            {
                if (checkedListBoxPurpose.GetItemCheckState(i) == CheckState.Checked)
                    purposes = string.Concat(purposes, ",'", checkedListBoxPurpose.Items[i].ToString(), "'");
            }
            if (purposes.Equals("'")) purposes = "''";
            else purposes = purposes.Substring(2);

            //Type
            DataTable dtTemp = Program.sqlApp.CreateDataTable(
                "SELECT DISTINCT " +
                "       d.type " +
                "FROM description d, " +
                "( " +
                "    SELECT description_sk " +
                "    FROM balance " +
                "    WHERE amount != 0 " +
                "    UNION " +
                "    SELECT description_sk " +
                "    FROM accrued " +
                "    WHERE amount != 0 " +
                ") x " +
                "WHERE d.description_sk = x.description_sk " +
                "      AND d.purpose in (" + purposes + ") " +
                "      AND d.owner_sk = @p1 " +
                "ORDER BY 1;",
                new SqlDbType[] { SqlDbType.Int },
                new object[] { Owner });

            checkedListBoxType.Items.Clear();
            foreach (DataRow dr in dtTemp.Rows)
            {
                checkedListBoxType.Items.Add(dr["type"].ToString(), true);
            }

            CheckedListBoxType_SelectedIndexChanged(null, null);

        }

        private void CheckedListBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // types
            types = "'";
            for (int i = 0; i < checkedListBoxType.Items.Count; i++)
            {
                if (checkedListBoxType.GetItemCheckState(i) == CheckState.Checked)
                    types = string.Concat(types, ",'", checkedListBoxType.Items[i].ToString(), "'");
            }
            if (types.Equals("'")) types = "''";
            else types = types.Substring(2);

            //Description
            DataTable dtTemp = Program.sqlApp.CreateDataTable(
                "SELECT DISTINCT " +
                "       a.description + ': ' + d.description description " +
                "FROM description d, " +
                "     agent a, " +
                "( " +
                "    SELECT description_sk " +
                "    FROM balance " +
                "    WHERE amount != 0 " +
                "    UNION " +
                "    SELECT description_sk " +
                "    FROM accrued " +
                "    WHERE amount != 0 " +
                ") x " +
                "WHERE d.description_sk = x.description_sk " +
                "      AND d.agent_sk = a.agent_sk " +
                "      AND a.owner_sk = @p1 " +
                "      AND d.type in (" + types + ") " +
                "      AND d.purpose in (" + purposes + ") " +
                "ORDER BY 1; ",
                new SqlDbType[] { SqlDbType.Int },
                new object[] { Owner });

            checkedListBoxDescription.Items.Clear();
            foreach (DataRow dr in dtTemp.Rows)
            {
                checkedListBoxDescription.Items.Add(dr["description"].ToString(), true);
            }

            CheckedListBoxDescription_SelectedIndexChanged(null, null);
        }

        private void CheckedListBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            // descriptions
            descriptions = "'";
            for (int i = 0; i < checkedListBoxDescription.Items.Count; i++)
            {
                if (checkedListBoxDescription.GetItemCheckState(i) == CheckState.Checked)
                    descriptions = string.Concat(descriptions, ",'", checkedListBoxDescription.Items[i].ToString(), "'");
            }
            if (descriptions.Equals("'")) descriptions = "''";
            else descriptions = descriptions.Substring(2);

            RefreshGraph();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = dateTimePickerStart.MinDate;
            dateTimePickerEnd.Value = dateTimePickerEnd.MaxDate;
        }

        private void CheckBoxEliminateTransactions_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }

        internal class LiveChartDateModel
        {
            public System.DateTime DateTime { get; set; }
            public double Value { get; set; }
        }

        private void CheckBoxUseFirstBalanceAs0_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }

        private void CheckBoxShowAsTotal_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }
    }
}
