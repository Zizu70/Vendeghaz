using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vendeghaz
{                  
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// 
        /// </summary> // Ezzel állítjuk be az STA módot
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
