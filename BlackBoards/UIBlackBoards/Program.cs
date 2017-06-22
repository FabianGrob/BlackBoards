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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Facade theFacade = new Facade();
            theFacade.createFirstUser();
            LogIn window = new LogIn(theFacade);
            Application.Run(new LogIn(theFacade));
        }
    }
}
