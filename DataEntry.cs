using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using TableEdit;
using System.IO;

namespace Moey
{
    public partial class DataEntry : UserControl
    {
        int Owner { get; }
        public DataEntry(int owner_sk)
        {
            InitializeComponent();

            Owner = owner_sk;

            DataTable items = Program.sqlApp.CreateDataTable("SELECT agent_sk value, description display FROM agent WHERE owner_sk = @p1 ORDER BY description",
                new SqlDbType[] {SqlDbType.Int},
                new object[] { Owner });

            listBoxAgent.ValueMember = "value";
            listBoxAgent.DisplayMember = "display";
            listBoxAgent.DataSource = items;
        }

        private void ListBoxAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable descriptions = Program.sqlApp.CreateDataTable(
                "SELECT description_sk value, " +
                "       description + ' (' + purpose + ' ' + type + ')' display " +
                "FROM Description " +
                "WHERE agent_sk = @p1 " +
                "AND owner_sk = @p2 " +
                "ORDER BY description",
            new SqlDbType[] { SqlDbType.Int, SqlDbType.Int },
            new object[] { listBoxAgent.SelectedValue, Owner });

            listBoxDescription.ValueMember = "value";
            listBoxDescription.DisplayMember = "display";
            listBoxDescription.DataSource = descriptions;
        }

        private void ListBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable balance = Program.sqlApp.CreateDataTable(
                "SELECT description_sk, " +
                "       [Date].date_sk, " +
                "       date, " +
                "       amount " +
                "FROM   balance " +
                "INNER JOIN [Date] " +
                "ON balance.date_sk = [Date].date_sk " +
                "WHERE description_sk = @p1 " +
                "AND owner_sk = @p2 " +
                "AND active_fl = 1 " +
                "ORDER BY 1",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.Int },
                new object[] { listBoxDescription.SelectedValue, Owner });

            listViewBalance.SuspendLayout();
            listViewBalance.Items.Clear();
            foreach (DataRow dr in balance.Rows)
            {
                AmountItem item = new AmountItem(
                                        (int)(long)dr["date_sk"],
                                        (int)(long)dr["description_sk"],
                                        (DateTime)dr["date"],
                                        (double)(decimal)dr["amount"]);

                ListViewItem listViewItem = new ListViewItem(item.ToCols())
                {
                    Tag = item
                };
                listViewBalance.Items.Add(listViewItem);
            }
            listViewBalance.ResumeLayout();
            if (listViewBalance.Items.Count > 0) listViewBalance.EnsureVisible(listViewBalance.Items.Count - 1);

            

            DataTable transaction = Program.sqlApp.CreateDataTable(
                "SELECT description_sk, " +
                "       [Date].date_sk, " +
                "       date, " +
                "       amount " +
                "FROM   [transaction] " +
                "INNER JOIN [Date] " +
                "ON [transaction].date_sk = [Date].date_sk " +
                "WHERE description_sk = @p1 " +
                "AND owner_sk = @p2 " +
                "AND active_fl = 1 " +
                "ORDER BY 1",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.Int },
                new object[] { listBoxDescription.SelectedValue, Owner });
            
            listViewTransaction.SuspendLayout();
            listViewTransaction.Items.Clear();
            foreach (DataRow dr in transaction.Rows)
            {
                AmountItem item = new AmountItem(
                                        (int)(long)dr["date_sk"],
                                        (int)(long)dr["description_sk"],
                                        (DateTime)dr["date"],
                                        (double)(decimal)dr["amount"]);

                ListViewItem listViewItem = new ListViewItem(item.ToCols())
                {
                    Tag = item
                };
                listViewTransaction.Items.Add(listViewItem);
            }
            listViewTransaction.ResumeLayout();
            if(listViewTransaction.Items.Count > 0) listViewTransaction.EnsureVisible(listViewTransaction.Items.Count - 1);

            DataTable accrued = Program.sqlApp.CreateDataTable(
                "SELECT description_sk, " +
                "       [Date].date_sk, " +
                "       date, " +
                "       amount " +
                "FROM   accrued " +
                "INNER JOIN [Date] " +
                "ON accrued.date_sk = [Date].date_sk " +
                "WHERE description_sk = @p1 " +
                "AND owner_sk = @p2 " +
                "AND active_fl = 1 " +
                "ORDER BY 1",
                new SqlDbType[] { SqlDbType.Int, SqlDbType.Int },
                new object[] { listBoxDescription.SelectedValue, Owner });

            listViewAccrued.SuspendLayout();
            listViewAccrued.Items.Clear();
            foreach (DataRow dr in accrued.Rows)
            {
                AmountItem item = new AmountItem(
                                        (int)(long)dr["date_sk"],
                                        (int)(long)dr["description_sk"],
                                        (DateTime)dr["date"],
                                        (double)(decimal)dr["amount"]);

                ListViewItem listViewItem = new ListViewItem(item.ToCols())
                {
                    Tag = item
                };
                listViewAccrued.Items.Add(listViewItem);
            }
            listViewAccrued.ResumeLayout();
            if (listViewAccrued.Items.Count > 0) listViewAccrued.EnsureVisible(listViewAccrued.Items.Count - 1);

            AddSums();
        }


        private void ButtonAddBalance_Click(object sender, EventArgs e)
        {
            if (PrepareTarget("Balance", Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")), Int32.Parse(listBoxDescription.SelectedValue.ToString())))
            {

                Program.sqlApp.Do("INSERT INTO Balance (date_sk, description_sk, amount, active_fl, owner_sk) VALUES (@p1, @p2, @p3, 1, @p4)",
                        new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.Int },
                        new object[] {
                        Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")),
                        listBoxDescription.SelectedValue,
                        ((ValidAmount)textBoxAmount.Tag).Amount,
                        Owner });
                ListBoxDescription_SelectedIndexChanged(null, null);
            }
            else
            {
                _ = MessageBox.Show("Duplicates not allowed");
            }
        }
        private void ButtonRemoveBalance_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem dr in listViewBalance.SelectedItems)
            {
                Program.sqlApp.Do("UPDATE Balance SET active_fl=0 WHERE date_sk = @p1 AND description_sk = @p2 AND owner_sk = @p3",
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int },
                    new object[] { ((AmountItem)dr.Tag).DateSk, ((AmountItem)dr.Tag).DescriptionSk, Owner });
            }
            ListBoxDescription_SelectedIndexChanged(null, null);
            buttonRemoveBalance.Enabled = false;
        }

        private void ButtonAddAccrued_Click(object sender, EventArgs e)
        {
            if (PrepareTarget("Accrued", Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")), Int32.Parse(listBoxDescription.SelectedValue.ToString())))
            {

                Program.sqlApp.Do("INSERT INTO Accrued (date_sk, description_sk, amount, active_fl, owner_sk) VALUES (@p1, @p2, @p3, 1, @p4)",
                        new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.Int },
                        new object[] {
                        Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")),
                        listBoxDescription.SelectedValue,
                        ((ValidAmount)textBoxAmount.Tag).Amount,
                        Owner });
                ListBoxDescription_SelectedIndexChanged(null, null);
            }
            else
            {
                _ = MessageBox.Show("Duplicates not allowed");
            }
        }
        private void ButtonRemoveAccrued_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem dr in listViewAccrued.SelectedItems)
            {
                Program.sqlApp.Do("UPDATE Accrued SET active_fl=0 WHERE date_sk = @p1 AND description_sk = @p2 AND owner_sk = @p3",
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int },
                    new object[] { ((AmountItem)dr.Tag).DateSk, ((AmountItem)dr.Tag).DescriptionSk, Owner });
            }
            ListBoxDescription_SelectedIndexChanged(null, null);
            buttonRemoveAccrued.Enabled = false;
        }

        private void ButtonAddTransaction_Click(object sender, EventArgs e)
        {
            if(PrepareTarget("[Transaction]", Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")), Int32.Parse(listBoxDescription.SelectedValue.ToString())))
                {

                Program.sqlApp.Do("INSERT INTO [Transaction] (date_sk, description_sk, amount, active_fl, owner_sk) VALUES (@p1, @p2, @p3, 1, @p4)",
                        new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.Int },
                        new object[] {
                        Int32.Parse(dateTimePicker.Value.ToString("yyyyMMdd")),
                        listBoxDescription.SelectedValue,
                        ((ValidAmount)textBoxAmount.Tag).Amount,
                        Owner, });
                ListBoxDescription_SelectedIndexChanged(null, null);
            } 
            else
            {
                _ = MessageBox.Show("Duplicates not allowed");
            }
        }
        private void ButtonRemoveTransaction_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem dr in listViewTransaction.SelectedItems)
            {
                Program.sqlApp.Do("UPDATE [Transaction] SET active_fl=0 WHERE date_sk = @p1 AND description_sk = @p2 AND owner_sk = @p3",
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int },
                    new object[] { ((AmountItem)dr.Tag).DateSk, ((AmountItem)dr.Tag).DescriptionSk, Owner });
            }
            ListBoxDescription_SelectedIndexChanged(null, null);
            buttonRemoveTransaction.Enabled = false;
        }
        

        private void TextBoxAmount_Leave(object sender, EventArgs e)
        {

            ValidAmount amount = new ValidAmount(textBoxAmount.Text);
            textBoxAmount.Tag = amount;
            textBoxAmount.Text = amount.TextAmount;
            textBoxAmount.Select(textBoxAmount.Text.Length, 0);

            if (!amount.Valid) _ = MessageBox.Show("Invalid number");
            buttonAddBalance.Enabled = amount.Valid;
            buttonAddAccrued.Enabled = amount.Valid;
            buttonAddTransaction.Enabled = amount.Valid;

        }
        private void TextBoxAmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }


        private bool PrepareTarget(string target, int date_sk, int description_sk)
        {
            Program.sqlApp.Do("DELETE FROM " + target + " WHERE date_sk = @p1 AND description_sk = @p2 AND active_fl =0 AND owner_sk = @p3",
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int },
                    new object[] { date_sk, description_sk, Owner });

            
            if (Program.sqlApp.Get("SELECT date_sk FROM " + target + " WHERE date_sk = @p1 AND description_sk = @p2 AND owner_sk = @p3",
                    new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int },
                    new object[] { date_sk, description_sk, Owner }) != null) 
                return false;
            else
                return true;

        }

        private void AddSums()
        {
            AmountItem item;
            ListViewItem listViewItem;
            double sum;
            int l;

            listView2.SuspendLayout();
            listView2.Items.Clear();

            DataTable savings = Program.sqlApp.CreateDataTable(
                "SELECT purpose, sum(amount) amount " +
                "FROM description, " +
                "    (SELECT description_sk, " +
                "            SUM(amount) amount " +
                "     FROM  (SELECT DISTINCT " +
                "                   description_sk, " +
                "                   LAST_VALUE(amount) OVER (PARTITION BY description_sk ORDER BY date_sk ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) amount " +
                "            FROM balance " +
                "            WHERE active_fl = 1" +
                "            AND owner_sk = @p1 " + 
                "            UNION ALL " +
                "            SELECT DISTINCT description_sk, " +
                "                   LAST_VALUE(amount) OVER (PARTITION BY description_sk ORDER BY date_sk ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) amount " +
                "            FROM accrued " +
                "            WHERE active_fl = 1 " +
                "            AND owner_sk = @p1)x " +
                "     GROUP BY description_sk)x " +
                "WHERE description.description_sk = x.description_sk " +
                "AND   purpose != 'Pension' " +
                "GROUP BY purpose " +
                "ORDER BY 1",
                new SqlDbType[] { SqlDbType.Int },
                new object[] { Owner });

            sum = 0d;
            l = 0;
            foreach (DataRow dr in savings.Rows)
            {
                item = new AmountItem(
                            -1,
                            -1,
                            dr["purpose"].ToString(),
                            (double)(decimal)dr["amount"]);

                listViewItem = new ListViewItem(item.ToCols())
                {
                    Tag = item
                };
                listView2.Items.Add(listViewItem);

                sum += (double)(decimal)dr["amount"];
            }
            item = new AmountItem(
                        -1,
                        -1,
                        "Savings and loans",
                        sum);
            listViewItem = new ListViewItem(item.ToCols())
            {
                Tag = item
            };
            listView2.Items.Insert(l, listViewItem);
            listView2.Items[l].Font = new Font(listView2.Items[l].Font, listView2.Items[l].Font.Style | FontStyle.Bold);

            
            listViewItem = new ListViewItem(new string[] { null, null });
            listView2.Items.Add(listViewItem);
            

            DataTable pension = Program.sqlApp.CreateDataTable(
                "SELECT agent.description agent," +
                "       sum(amount) amount " +
                "FROM description, " +
                "     agent, " +
                "    (SELECT description_sk, " +
                "            sum(amount) amount " +
                "     FROM(SELECT DISTINCT " +
                "                 description_sk, " +
                "                 LAST_VALUE(amount) OVER (PARTITION BY description_sk ORDER BY date_sk ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) amount " +
                "          FROM balance " +
                "          WHERE active_fl = 1 " +
                "          AND owner_sk = @p1 " +
                "          UNION ALL " +
                "          SELECT DISTINCT description_sk, " +
                "                 LAST_VALUE(amount) OVER (PARTITION BY description_sk ORDER BY date_sk ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) amount " +
                "          FROM accrued " +
                "          WHERE active_fl = 1 " +
                "          AND owner_sk = @p1)x " +
                "     GROUP BY description_sk)x " +
                "WHERE description.description_sk = x.description_sk " +
                "AND description.agent_sk = agent.agent_sk " +
                "AND purpose = 'Pension' " +
                "GROUP BY agent.description " +
                "ORDER BY 1",
                new SqlDbType[] { SqlDbType.Int },
                new object[] { Owner });


            sum = 0d;
            l = listView2.Items.Count;
            foreach (DataRow dr in pension.Rows)
            {
                item = new AmountItem(
                            -1,
                            -1,
                            dr["agent"].ToString(),
                            (double)(decimal)dr["amount"]);

                listViewItem = new ListViewItem(item.ToCols())
                {
                    Tag = item
                };
                listView2.Items.Add(listViewItem);

                sum += (double)(decimal)dr["amount"];
            }
            item = new AmountItem(
                        -1,
                        -1,
                        "Pension",
                        sum);
            listViewItem = new ListViewItem(item.ToCols())
            {
                Tag = item
            };
            listView2.Items.Insert(l, listViewItem);
            listView2.Items[l].Font = new Font(listView2.Items[l].Font, listView2.Items[l].Font.Style | FontStyle.Bold);
            

            listView2.ResumeLayout();


        }

        private void ListViewBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBalance.SelectedItems.Count > 0)
                buttonRemoveBalance.Enabled = true;
        }

        private void ListViewAccrued_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAccrued.SelectedItems.Count > 0)
                buttonRemoveAccrued.Enabled = true;
        }

        private void ListViewTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTransaction.SelectedItems.Count > 0)
                buttonRemoveTransaction.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LogFile logFile = new LogFile(Path.GetTempPath() + "\\MOEY-" + Guid.NewGuid().ToString() + ".log", new System.Text.UTF8Encoding(false));
            using (Form f = new FormEditTable(Program.sqlApp, "Agents", "refTableEditTable", "refTableEditColumn", logFile))
                f.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            LogFile logFile = new LogFile(Path.GetTempPath() + "\\MOEY-" + Guid.NewGuid().ToString(), new System.Text.UTF8Encoding(false));
            using (Form f = new FormEditTable(Program.sqlApp, "Accounts", "refTableEditTable", "refTableEditColumn", logFile))
                f.ShowDialog();
        }
    }



    internal class ValidAmount
    {
        public double Amount { get; set; }
        public string TextAmount { get; set; }
        public bool Valid { get; set; }

        private double InterimAmount { get; set; }

        public ValidAmount(double amount)
        {
            Amount = amount;
            TextAmount = FormatAmount(Amount);
            Valid = true;
        }

        public ValidAmount(string amount)
        {
            amount = amount.Trim();
            if (string.IsNullOrEmpty(amount)) amount = "0";

            if (Validate(amount))
            {
                Amount = InterimAmount;
                TextAmount = FormatAmount(Amount);
                Valid = true;
            }
            else
            {
                Amount = 0;
                TextAmount = "";
                Valid = false;
            }
            
        }

        public string FormatAmount(double amount)
        {
            return String.Format("{0:#,##0.00}", amount);
        }

        public bool Validate(string amount)
        {
            try
            {
                InterimAmount = Double.Parse(amount, System.Globalization.NumberStyles.AllowThousands |
                                                   System.Globalization.NumberStyles.AllowDecimalPoint |
                                                   System.Globalization.NumberStyles.AllowLeadingSign);
                return true;

            }
            catch
            {
                return false;
            }
        }

    }
    internal class AmountItem
    {

        public int DescriptionSk { get; set; }
        public int DateSk { get; set; }
        public DateTime Date { get; set; }
        public String Text { get; set; }
        public double Amount { get; set; }

        private readonly string style;

        public AmountItem(int date_sk, int description_sk, DateTime date, double amount)
        {
            DescriptionSk = description_sk;
            DateSk = date_sk;
            Date = date;
            Text = null;
            Amount = amount;
            style = "Date";
        }
        public AmountItem(int date_sk, int description_sk, String text, double amount)
        {
            DescriptionSk = description_sk;
            DateSk = date_sk;
            Date = DateTime.MinValue;
            Text = text;
            Amount = amount;
            style = "String";
        }

        public string[] ToCols()
        {
            if (style == "Date") return new string[] { Date.ToString("yyyy-MM-dd"), Amount.ToString("#,##0.00") };
            else return new string[] { Text, Amount.ToString("#,##0.00") };
        }

        override
        public string ToString()
        {
            if (style == "Date") return Date.ToString("yyyy-MM-dd") + " " + Amount.ToString("#,##0.00");
            else return Text + " " + Amount.ToString("#,##0.00");
        }

    }
}
