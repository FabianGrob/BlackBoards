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
        }
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex != -1)
            {
                User selectedUser = (User)listBoxAllUsers.SelectedItem;
                listBoxAllUsers.Items.Remove(selectedUser);
                listBoxSelectedUsers.Items.Add(selectedUser);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool isInListBox(User user, ListBox listBoxSelectedUsers)
        {
            return (listBoxSelectedUsers.Items.Contains(user));
        }
        public List<User> getSelectedUsers(ListBox listBoxSelectedUsers)
        {
            List<User> userList = new List<User>();
            foreach (User actualUser in theRepository.UserList)
            {
                if (isInListBox(actualUser, listBoxSelectedUsers))
                {
                    userList.Add(actualUser);
                }
            }
            return userList;
        }
        public bool validations(string name, string description, string cantMaxUsers, List<User> userList)
        {
            bool allValidationsOk = true;
            if (name.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("El nombre ingresado es vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (description.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("La descripcion ingresada es vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (cantMaxUsers.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("La cantidad de usuarios maxima es vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            else
            {
                int n;
                if (int.TryParse(cantMaxUsers, out n) == false)
                {
                    allValidationsOk = false;
                    MessageBox.Show("La cantidad de usuarios maxima no puede tener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return allValidationsOk;
                }
            }
            if (userList.Count == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("No se seleccino ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            return allValidationsOk;
        }

        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            bool validationsOk = validations(textBoxName.Text, richTextBoxDescription.Text, textBoxCantMaxUsers.Text, getSelectedUsers(listBoxSelectedUsers));
            if (validationsOk)
            {
                List<User> members = getSelectedUsers(listBoxSelectedUsers);
                string teamName = textBoxName.Text;
                string description = richTextBoxDescription.Text;
                int maxUsers = Int32.Parse(textBoxCantMaxUsers.Text);
                List<BlackBoard> blackBoards = new List<BlackBoard>();
                AdminHandler handler = new AdminHandler((Admin)logged);
                bool existingTeam = handler.CreateTeam(teamName, description, maxUsers, members, blackBoards, theRepository);
                if (!existingTeam)
                {
                    MessageBox.Show("El equipo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El equipo ha sido ingresado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
            }
        }

        private void buttonDeleteMember_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSelectedUsers.SelectedIndex;
            if (selectedIndex != -1)
            {
                User selectedUser = (User)listBoxSelectedUsers.SelectedItem;
                listBoxSelectedUsers.Items.Remove(selectedUser);
                listBoxAllUsers.Items.Add(selectedUser);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
