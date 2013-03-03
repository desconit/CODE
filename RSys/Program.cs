using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSys
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static User  clsuser = new User();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
