namespace Moey
{
    partial class GraphOverTime
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxShowAsTotal = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxUseFirstBalanceAs0 = new System.Windows.Forms.CheckBox();
            this.checkedListBoxType = new System.Windows.Forms.CheckedListBox();
            this.checkBoxEliminateTransactions = new System.Windows.Forms.CheckBox();
            this.checkedListBoxDescription = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxPurpose = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(974, 598);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(3, 3);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(94, 20);
            this.dateTimePickerStart.TabIndex = 1;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(103, 3);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(94, 20);
            this.dateTimePickerEnd.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxShowAsTotal);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dateTimePickerEnd);
            this.panel2.Controls.Add(this.dateTimePickerStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1174, 27);
            this.panel2.TabIndex = 4;
            // 
            // checkBoxShowAsTotal
            // 
            this.checkBoxShowAsTotal.AutoSize = true;
            this.checkBoxShowAsTotal.Checked = true;
            this.checkBoxShowAsTotal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowAsTotal.Location = new System.Drawing.Point(261, 6);
            this.checkBoxShowAsTotal.Name = "checkBoxShowAsTotal";
            this.checkBoxShowAsTotal.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowAsTotal.TabIndex = 4;
            this.checkBoxShowAsTotal.Text = "Show as total";
            this.checkBoxShowAsTotal.UseVisualStyleBackColor = true;
            this.checkBoxShowAsTotal.CheckedChanged += new System.EventHandler(this.CheckBoxShowAsTotal_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxUseFirstBalanceAs0);
            this.panel1.Controls.Add(this.checkedListBoxType);
            this.panel1.Controls.Add(this.checkBoxEliminateTransactions);
            this.panel1.Controls.Add(this.checkedListBoxDescription);
            this.panel1.Controls.Add(this.checkedListBoxPurpose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 598);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxUseFirstBalanceAs0
            // 
            this.checkBoxUseFirstBalanceAs0.AutoSize = true;
            this.checkBoxUseFirstBalanceAs0.Location = new System.Drawing.Point(3, 578);
            this.checkBoxUseFirstBalanceAs0.Name = "checkBoxUseFirstBalanceAs0";
            this.checkBoxUseFirstBalanceAs0.Size = new System.Drawing.Size(69, 17);
            this.checkBoxUseFirstBalanceAs0.TabIndex = 4;
            this.checkBoxUseFirstBalanceAs0.Text = "Start at 0";
            this.checkBoxUseFirstBalanceAs0.UseVisualStyleBackColor = true;
            this.checkBoxUseFirstBalanceAs0.CheckedChanged += new System.EventHandler(this.CheckBoxUseFirstBalanceAs0_CheckedChanged);
            // 
            // checkedListBoxType
            // 
            this.checkedListBoxType.CheckOnClick = true;
            this.checkedListBoxType.FormattingEnabled = true;
            this.checkedListBoxType.Location = new System.Drawing.Point(3, 136);
            this.checkedListBoxType.Name = "checkedListBoxType";
            this.checkedListBoxType.Size = new System.Drawing.Size(191, 94);
            this.checkedListBoxType.TabIndex = 3;
            this.checkedListBoxType.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxType_SelectedIndexChanged);
            // 
            // checkBoxEliminateTransactions
            // 
            this.checkBoxEliminateTransactions.AutoSize = true;
            this.checkBoxEliminateTransactions.Location = new System.Drawing.Point(3, 561);
            this.checkBoxEliminateTransactions.Name = "checkBoxEliminateTransactions";
            this.checkBoxEliminateTransactions.Size = new System.Drawing.Size(128, 17);
            this.checkBoxEliminateTransactions.TabIndex = 2;
            this.checkBoxEliminateTransactions.Text = "Eliminate transactions";
            this.checkBoxEliminateTransactions.UseVisualStyleBackColor = true;
            this.checkBoxEliminateTransactions.CheckedChanged += new System.EventHandler(this.CheckBoxEliminateTransactions_CheckedChanged);
            // 
            // checkedListBoxDescription
            // 
            this.checkedListBoxDescription.CheckOnClick = true;
            this.checkedListBoxDescription.FormattingEnabled = true;
            this.checkedListBoxDescription.Location = new System.Drawing.Point(3, 236);
            this.checkedListBoxDescription.Name = "checkedListBoxDescription";
            this.checkedListBoxDescription.Size = new System.Drawing.Size(191, 319);
            this.checkedListBoxDescription.TabIndex = 1;
            this.checkedListBoxDescription.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxDescription_SelectedIndexChanged);
            // 
            // checkedListBoxPurpose
            // 
            this.checkedListBoxPurpose.CheckOnClick = true;
            this.checkedListBoxPurpose.FormattingEnabled = true;
            this.checkedListBoxPurpose.Location = new System.Drawing.Point(3, 6);
            this.checkedListBoxPurpose.Name = "checkedListBoxPurpose";
            this.checkedListBoxPurpose.Size = new System.Drawing.Size(191, 124);
            this.checkedListBoxPurpose.TabIndex = 0;
            this.checkedListBoxPurpose.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxPurpose_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cartesianChart1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(200, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(974, 598);
            this.panel4.TabIndex = 6;
            // 
            // GraphOverTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "GraphOverTime";
            this.Size = new System.Drawing.Size(1174, 625);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox checkedListBoxPurpose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox checkedListBoxDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxEliminateTransactions;
        private System.Windows.Forms.CheckedListBox checkedListBoxType;
        private System.Windows.Forms.CheckBox checkBoxShowAsTotal;
        private System.Windows.Forms.CheckBox checkBoxUseFirstBalanceAs0;
    }
}
