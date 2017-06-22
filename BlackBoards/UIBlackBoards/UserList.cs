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
using Persistance;

namespace UIBlackBoards
{
    public partial class UserList : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public UserList(string anUser, Facade facade, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            List<User> allUsers = theFacade.GetAllUSersInDB();
            foreach (User actualUser in allUsers)
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
                UserPersistance userContext = new UserPersistance();
                User selectedUser = userContext.GetUserByEmail(((User)listBoxAllUsers.SelectedItem).Email);
                ValidationReturn validation = new ValidationReturn(false, "No se ha podido elminar el usuario seleccionado");
                validation = theFacade.deleteUser(logged, selectedUser.Email);
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
                User choosedUser = (User)listBoxAllUsers.SelectedItem;
                User selectedUser = theFacade.GetSpecificUser(choosedUser.Email);
                panelContainer.Controls.Clear();
                UserControl modifyUser = new ModifyUser(logged, theFacade, panelContainer, selectedUser);
                panelContainer.Controls.Add(modifyUser);
            }
        }
    }
}
