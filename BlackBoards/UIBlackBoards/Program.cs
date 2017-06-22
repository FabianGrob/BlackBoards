using BlackBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIBlackBoards;

namespace BlackBoards
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LogIn());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Facade theFacade = new Facade();

            LogIn window = new LogIn(theFacade);
            Application.Run(new LogIn(theFacade));
        }
    }
}
