using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackBoards;
using BlackBoards.Handlers;

namespace UIBlackBoards
{
    public partial class AddNewTeam : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public AddNewTeam(User anUser, Repository aRepository, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            foreach (User actualUser in theRepository.UserList)
            {
                listBoxAllUsers.Items.Add(actualUser);
            }
            listBoxAllUsers.SelectedItem = 0;
        }
        private void AddNewTeam_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {

            User selectedUser=(User)listBoxAllUsers.SelectedItem;
            listBoxAllUsers.Items.Remove(selectedUser);
            listBoxSelectedUsers.Items.Add(selectedUser);
        }

        private void textBoxCantMaxUsers_TextChanged(object sender, EventArgs e)
        {

        }

        private bool isInListBox(User user)
        {
            return (listBoxSelectedUsers.Items.Contains(user));
        }
        private List<User> getSelectedUsers()
        {
            List<User> userList=new List<User>();
            foreach (User actualUser in theRepository.UserList)
            {
                if (isInListBox(actualUser))
                {
                    userList.Add(actualUser);
                }
            }
            return userList;
        }

        private bool validations()
        {
            bool allValidationsOk = true;
            if (textBoxName.Text.Length == 0)
            {
                allValidationsOk = false;
            }
            if (richTextBoxDescription.Text.Length == 0)
            {
                allValidationsOk = false;
            }
            if (textBoxCantMaxUsers.Text.Length == 0)
            {
                allValidationsOk = false;
            } else
            {
                int n;
                if(int.TryParse(textBoxCantMaxUsers.Text, out n) == false)
                {
                    allValidationsOk = false;
                }
            }
            if (getSelectedUsers().Count == 0)
            {
                allValidationsOk = false;
            }
            return allValidationsOk;
        }

        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            bool validationsOk = validations();
            if (validationsOk)
            {
                List<User> members = getSelectedUsers();
                string teamName = textBoxName.Text;
                string description = richTextBoxDescription.Text;
                int maxUsers = Int32.Parse(textBoxCantMaxUsers.Text);
                List<BlackBoard> blackBoards = new List<BlackBoard>();
                AdminHandler handler = new AdminHandler((Admin)logged);
                bool existingTeam = handler.CreateTeam(teamName,description,maxUsers,members,blackBoards,theRepository);
                if (existingTeam)
                {
                    MessageBox.Show("El equipo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("El equipo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
