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
            Repository theRepository = new Repository();
            Admin anAdmin = new Admin();
            anAdmin.Name = "Generated";
            anAdmin.LastName = "admin";
            anAdmin.Email = "Admin@Admin.com";
            anAdmin.Password = "admin";
            anAdmin.BirthDate = DateTime.Today;
            theRepository.UserList.Add(anAdmin);
            theRepository.AdministratorList.Add(anAdmin);
            LogIn window = new LogIn(theRepository);
            Application.Run(new LogIn(theRepository));
        }
    }
}
