using BlackBoards.Handlers;
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
            AdminHandler handler = new AdminHandler(anAdmin);
            List<User> userList = new List<User>();
            userList.Add(anAdmin);
            handler.CreateTeam("GeneratedTeam","GeneratedDescription",3,userList,new List<BlackBoard>(),theRepository);
            UserHandler handlerUser = new UserHandler(anAdmin);
            BlackBoard blackBoard = new BlackBoard();
            blackBoard.Name = "GeneratedBlackBoard";
            blackBoard.Dimension.Height = 350;
            blackBoard.Dimension.Width = 650;
            blackBoard.Description = "GeneratedDescription";
            TextBox textBox = new TextBox();
            textBox.Dimension.Height = 50;
            textBox.Dimension.Width = 50;
            textBox.Font = "Arial";
            textBox.FontSize = 20;
            textBox.Content = "GeneratedText";
            handlerUser.CreateBlackBoard(theRepository.TeamList.ElementAt(0),blackBoard);
            handlerUser.AddItemToBlackBoard(blackBoard,textBox);

            LogIn window = new LogIn(theRepository);
            Application.Run(new LogIn(theRepository));
        }
    }
}
