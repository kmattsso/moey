namespace Moey
{
    partial class DataEntry
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.listBoxAgent = new System.Windows.Forms.ListBox();
            this.listBoxDescription = new System.Windows.Forms.ListBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.buttonAddBalance = new System.Windows.Forms.Button();
            this.buttonAddTransaction = new System.Windows.Forms.Button();
            this.buttonRemoveBalance = new System.Windows.Forms.Button();
            this.buttonRemoveTransaction = new System.Windows.Forms.Button();
            this.listViewBalance = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewTransaction = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewAccrued = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddAccrued = new System.Windows.Forms.Button();
            this.buttonRemoveAccrued = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxAgent
            // 
            this.listBoxAgent.FormattingEnabled = true;
            this.listBoxAgent.Location = new System.Drawing.Point(3, 3);
            this.listBoxAgent.Name = "listBoxAgent";
            this.listBoxAgent.Size = new System.Drawing.Size(222, 173);
            this.listBoxAgent.TabIndex = 0;
            this.listBoxAgent.SelectedIndexChanged += new System.EventHandler(this.ListBoxAgent_SelectedIndexChanged);
            // 
            // listBoxDescription
            // 
            this.listBoxDescription.FormattingEnabled = true;
            this.listBoxDescription.Location = new System.Drawing.Point(231, 3);
            this.listBoxDescription.Name = "listBoxDescription";
            this.listBoxDescription.Size = new System.Drawing.Size(222, 173);
            this.listBoxDescription.TabIndex = 1;
            this.listBoxDescription.SelectedIndexChanged += new System.EventHandler(this.ListBoxDescription_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(3, 210);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(98, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(107, 210);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(94, 20);
            this.textBoxAmount.TabIndex = 3;
            this.textBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxAmount_KeyUp);
            this.textBoxAmount.Leave += new System.EventHandler(this.TextBoxAmount_Leave);
            // 
            // buttonAddBalance
            // 
            this.buttonAddBalance.Enabled = false;
            this.buttonAddBalance.Location = new System.Drawing.Point(3, 254);
            this.buttonAddBalance.Name = "buttonAddBalance";
            this.buttonAddBalance.Size = new System.Drawing.Size(128, 23);
            this.buttonAddBalance.TabIndex = 4;
            this.buttonAddBalance.Text = "Add Balance";
            this.buttonAddBalance.UseVisualStyleBackColor = true;
            this.buttonAddBalance.Click += new System.EventHandler(this.ButtonAddBalance_Click);
            // 
            // buttonAddTransaction
            // 
            this.buttonAddTransaction.Enabled = false;
            this.buttonAddTransaction.Location = new System.Drawing.Point(520, 254);
            this.buttonAddTransaction.Name = "buttonAddTransaction";
            this.buttonAddTransaction.Size = new System.Drawing.Size(128, 23);
            this.buttonAddTransaction.TabIndex = 6;
            this.buttonAddTransaction.Text = "Add Transaction";
            this.buttonAddTransaction.UseVisualStyleBackColor = true;
            this.buttonAddTransaction.Click += new System.EventHandler(this.ButtonAddTransaction_Click);
            // 
            // buttonRemoveBalance
            // 
            this.buttonRemoveBalance.Enabled = false;
            this.buttonRemoveBalance.Location = new System.Drawing.Point(3, 514);
            this.buttonRemoveBalance.Name = "buttonRemoveBalance";
            this.buttonRemoveBalance.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveBalance.TabIndex = 8;
            this.buttonRemoveBalance.Text = "Remove Balance";
            this.buttonRemoveBalance.UseVisualStyleBackColor = true;
            this.buttonRemoveBalance.Click += new System.EventHandler(this.ButtonRemoveBalance_Click);
            // 
            // buttonRemoveTransaction
            // 
            this.buttonRemoveTransaction.Enabled = false;
            this.buttonRemoveTransaction.Location = new System.Drawing.Point(520, 514);
            this.buttonRemoveTransaction.Name = "buttonRemoveTransaction";
            this.buttonRemoveTransaction.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveTransaction.TabIndex = 12;
            this.buttonRemoveTransaction.Text = "Remove Transaction";
            this.buttonRemoveTransaction.UseVisualStyleBackColor = true;
            this.buttonRemoveTransaction.Click += new System.EventHandler(this.ButtonRemoveTransaction_Click);
            // 
            // listViewBalance
            // 
            this.listViewBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewBalance.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listViewBalance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewBalance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewBalance.HideSelection = false;
            this.listViewBalance.Location = new System.Drawing.Point(3, 283);
            this.listViewBalance.Name = "listViewBalance";
            this.listViewBalance.ShowGroups = false;
            this.listViewBalance.Size = new System.Drawing.Size(252, 225);
            this.listViewBalance.TabIndex = 7;
            this.listViewBalance.UseCompatibleStateImageBehavior = false;
            this.listViewBalance.View = System.Windows.Forms.View.Details;
            this.listViewBalance.SelectedIndexChanged += new System.EventHandler(this.ListViewBalance_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 128;
            // 
            // listViewTransaction
            // 
            this.listViewTransaction.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewTransaction.FullRowSelect = true;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.listViewTransaction.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.listViewTransaction.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewTransaction.HideSelection = false;
            this.listViewTransaction.Location = new System.Drawing.Point(520, 283);
            this.listViewTransaction.Name = "listViewTransaction";
            this.listViewTransaction.ShowGroups = false;
            this.listViewTransaction.Size = new System.Drawing.Size(252, 225);
            this.listViewTransaction.TabIndex = 11;
            this.listViewTransaction.UseCompatibleStateImageBehavior = false;
            this.listViewTransaction.View = System.Windows.Forms.View.Details;
            this.listViewTransaction.SelectedIndexChanged += new System.EventHandler(this.ListViewTransaction_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 128;
            // 
            // listViewAccrued
            // 
            this.listViewAccrued.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listViewAccrued.FullRowSelect = true;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.listViewAccrued.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listViewAccrued.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewAccrued.HideSelection = false;
            this.listViewAccrued.Location = new System.Drawing.Point(262, 283);
            this.listViewAccrued.Name = "listViewAccrued";
            this.listViewAccrued.ShowGroups = false;
            this.listViewAccrued.Size = new System.Drawing.Size(252, 225);
            this.listViewAccrued.TabIndex = 9;
            this.listViewAccrued.UseCompatibleStateImageBehavior = false;
            this.listViewAccrued.View = System.Windows.Forms.View.Details;
            this.listViewAccrued.SelectedIndexChanged += new System.EventHandler(this.ListViewAccrued_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 128;
            // 
            // buttonAddAccrued
            // 
            this.buttonAddAccrued.Enabled = false;
            this.buttonAddAccrued.Location = new System.Drawing.Point(262, 254);
            this.buttonAddAccrued.Name = "buttonAddAccrued";
            this.buttonAddAccrued.Size = new System.Drawing.Size(128, 23);
            this.buttonAddAccrued.TabIndex = 5;
            this.buttonAddAccrued.Text = "Add Accrued";
            this.buttonAddAccrued.UseVisualStyleBackColor = true;
            this.buttonAddAccrued.Click += new System.EventHandler(this.ButtonAddAccrued_Click);
            // 
            // buttonRemoveAccrued
            // 
            this.buttonRemoveAccrued.Enabled = false;
            this.buttonRemoveAccrued.Location = new System.Drawing.Point(262, 514);
            this.buttonRemoveAccrued.Name = "buttonRemoveAccrued";
            this.buttonRemoveAccrued.Size = new System.Drawing.Size(128, 23);
            this.buttonRemoveAccrued.TabIndex = 10;
            this.buttonRemoveAccrued.Text = "Remove Accrued";
            this.buttonRemoveAccrued.UseVisualStyleBackColor = true;
            this.buttonRemoveAccrued.Click += new System.EventHandler(this.ButtonRemoveAccrued_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listView2.Enabled = false;
            this.listView2.FullRowSelect = true;
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup1";
            this.listView2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4});
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(520, 5);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.ShowGroups = false;
            this.listView2.Size = new System.Drawing.Size(252, 225);
            this.listView2.TabIndex = 13;
            this.listView2.TabStop = false;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 98;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(778, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Edit Agents";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(778, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Edit Accounts";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.buttonRemoveAccrued);
            this.Controls.Add(this.buttonAddAccrued);
            this.Controls.Add(this.listViewAccrued);
            this.Controls.Add(this.listViewTransaction);
            this.Controls.Add(this.listViewBalance);
            this.Controls.Add(this.buttonRemoveTransaction);
            this.Controls.Add(this.buttonRemoveBalance);
            this.Controls.Add(this.buttonAddTransaction);
            this.Controls.Add(this.buttonAddBalance);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listBoxDescription);
            this.Controls.Add(this.listBoxAgent);
            this.Name = "DataEntry";
            this.Size = new System.Drawing.Size(916, 598);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAgent;
        private System.Windows.Forms.ListBox listBoxDescription;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button buttonAddBalance;
        private System.Windows.Forms.Button buttonAddTransaction;
        private System.Windows.Forms.Button buttonRemoveBalance;
        private System.Windows.Forms.Button buttonRemoveTransaction;
        private System.Windows.Forms.ListView listViewBalance;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewTransaction;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listViewAccrued;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button buttonAddAccrued;
        private System.Windows.Forms.Button buttonRemoveAccrued;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
