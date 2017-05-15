using BlackBoards;
using BlackBoards.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIBlackBoards
{
    public partial class MainMenu : Form
    {
        private User logged;
        private Repository theRepository;
        public MainMenu(User anUser, Repository aRepository)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            bool isUserAdmin = repHandler.IsUserAnAdmin(logged.Email);
            buttonCreateTeam.Enabled = isUserAdmin;
            buttonModifyTeam.Enabled = isUserAdmin;
            buttonCreateUser.Enabled = isUserAdmin;
            buttonModifyUser.Enabled = isUserAdmin;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
