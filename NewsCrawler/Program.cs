using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace NewsCrawler
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginDB());
            Database.DBCreate(); 
            Application.Run(new UpdateNews());
            Application.Run(new MainForm());

        }
    }
}
