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
using BlackBoards.Domain.BlackBoards;

namespace UIBlackBoards
{
    public partial class UserList : UserControl
    {
        private string logged;
        private Repository theRepository;
        private Panel panelContainer;
        public UserList(string anUser, Repository aRepository, Panel container)
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
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                User selectedUser = (User)listBoxAllUsers.SelectedItem;
                ValidationReturn validation = new ValidationReturn(false, "No se ha podido elminar el usuario seleccionado");
                Facade facade = new Facade();
                validation = facade.deleteUser(logged, selectedUser.Email);
                if (validation.Validation)
                {
                    MessageBox.Show(validation.Message, "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
                else
                {
                    MessageBox.Show(validation.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
