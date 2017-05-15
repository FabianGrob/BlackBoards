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
            panelContainer.Controls.Clear();
            UserControl addUser = new AddNewUser(logged, theRepository, panelContainer);
            panelContainer.Controls.Add(addUser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl userList = new UserList(logged, theRepository, panelContainer);
            panelContainer.Controls.Add(userList);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl addTeam = new AddNewTeam(logged, theRepository, panelContainer);
            panelContainer.Controls.Add(addTeam);
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogIn windows = new LogIn(theRepository);
            this.Visible = false;
            windows.Visible = true;
        }
    }
}
