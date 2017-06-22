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
using Persistance;

namespace UIBlackBoards
{
    public partial class UserListForComments : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public UserListForComments(string anUser, Facade facade, Panel container)
        {
            UserPersistance userContext = new UserPersistance();
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            foreach (User actualUser in theFacade.GetAllUSersInDB())
            {
                listBoxAllUsers.Items.Add(actualUser);
            }
            listBoxAllUsers.SelectedItem = 0;
        }

        private void buttonSelectUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                UserPersistance userContext = new UserPersistance();
                User selectedUser = userContext.GetUserByEmail(((User)listBoxAllUsers.SelectedItem).Name);
                panelContainer.Controls.Clear();
                //UserControl resolvedComments = new ResolvedCommentsByUser(logged, theFacade, panelContainer, selectedUser);
                //panelContainer.Controls.Add(resolvedComments);
            }
        }
    }
}
