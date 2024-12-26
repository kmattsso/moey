using Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moey
{
    static class Program
    {

        public static SQLApp sqlApp;
        public static DateTime startDate, endDate;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            sqlApp = new SQLApp("BAHIA002", "moey", "sa", "sa01", SQLApp.DbType.SQLServer);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            _ = sqlApp.Backup("C:\\FirmaBackup");
        }

        public static void RefreshBoundries()
        {
            startDate = (DateTime)Program.sqlApp.Get("SELECT CONVERT(DATETIME2, CAST(MIN(date_sk) AS VARCHAR), 112) " +
                "FROM " +
                "( " +
                "    SELECT date_sk " +
                "    FROM balance " +
                "    WHERE active_fl = 1 " +
                "    UNION ALL " +
                "    SELECT date_sk " +
                "    FROM accrued " +
                "    WHERE active_fl = 1 " +
                ") x; ");
            endDate = (DateTime)Program.sqlApp.Get("SELECT CONVERT(DATETIME2, CAST(MAX(date_sk) AS VARCHAR), 112) " +
                "FROM " +
                "( " +
                "    SELECT date_sk " +
                "    FROM balance " +
                "    WHERE active_fl = 1 " +
                "    UNION ALL " +
                "    SELECT date_sk " +
                "    FROM accrued " +
                "    WHERE active_fl = 1 " +
                ") x; ");
        }
    }
}
