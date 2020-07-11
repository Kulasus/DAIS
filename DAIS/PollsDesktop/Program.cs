using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PollsDesktop.DATABASE;
using PollsDesktop.Forms;
using PollsDesktop.DATABASE.DAO;
using PollsDesktop.DATABASE.DTO;

namespace PollsDesktop
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database db = new Database();
            bool connection = db.Connect();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
