using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moey
{

    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
            Program.RefreshBoundries();

            ToolStripMenuItemOwner.SelectedIndex = 0;
        }

        private void ToolStripMenuItemOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Controls.Clear();
            tabControl1.TabPages[0].Controls.Add(new DataEntry(ToolStripMenuItemOwner.SelectedIndex + 1) { Dock = DockStyle.Fill });
            tabControl1.TabPages[1].Controls.Clear();
            tabControl1.TabPages[1].Controls.Add(new GraphOverTime(ToolStripMenuItemOwner.SelectedIndex + 1) { Dock = DockStyle.Fill });
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
                tabControl1.TabPages[1].Controls.Add(new GraphOverTime(ToolStripMenuItemOwner.SelectedIndex + 1) { Dock = DockStyle.Fill });
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = MessageBox.Show("Version: " +
               (ApplicationDeployment.IsNetworkDeployed
               ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
               : Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }
        
    }
}
