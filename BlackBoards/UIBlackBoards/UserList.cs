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
    public partial class UserList : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public UserList(User anUser, Repository aRepository, Panel container)
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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            AdminHandler adminHandler = new AdminHandler((Admin)logged);
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User selectedUser = (User)listBoxAllUsers.SelectedItem;
                if (selectedUser.Equals(logged))
                {
                    MessageBox.Show("No se puede eliminar el usuario si está logeado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    adminHandler.DeleteUser(selectedUser.Email, theRepository);
                    MessageBox.Show("Se elimino el usuario " + selectedUser.Email + " correctamente", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User selectedUser = (User)listBoxAllUsers.SelectedItem;
                panelContainer.Controls.Clear();
                UserControl modifyUser = new ModifyUser(logged, theRepository, panelContainer, selectedUser);
                panelContainer.Controls.Add(modifyUser);
            }
        }
    }
}
