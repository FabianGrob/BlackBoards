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

namespace UIBlackBoards
{
    public partial class UserListForComments : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public UserListForComments(User anUser, Repository aRepository, Panel container)
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

        private void buttonSelectUser_Click(object sender, EventArgs e)
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
                UserControl resolvedComments = new ResolvedCommentsByUser(logged, theRepository, panelContainer, selectedUser);
                panelContainer.Controls.Add(resolvedComments);
            }
        }
    }
}
