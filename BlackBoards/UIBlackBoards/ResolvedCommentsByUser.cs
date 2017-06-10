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
    public partial class ResolvedCommentsByUser : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        private User selectedUser;
        private List<Comment> resolved;
        public ResolvedCommentsByUser(User anUser, Repository aRepository, Panel container,User selected)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            selectedUser = selected;
            dateTimePicker.Value = DateTime.Today;
            label1.Text = "Comentarios resueltos por el Usuario: " + selectedUser.Email;
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            resolved = repHandler.resolvedCommentsByUser(selectedUser);
            foreach (Comment actualComment in resolved)
            {
                listBoxResolvedComments.Items.Add(actualComment);
            }
            foreach (User actualUser in theRepository.UserList)
            {
                comboBoxUsers.Items.Add(actualUser);
            }
            comboBoxUsers.SelectedIndex = 0;
        }

        private void buttonCreationDAte_Click(object sender, EventArgs e)
        {
            RepositoryHandler handler = new RepositoryHandler(theRepository);
           
            if (dateTimePicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha seleccionada pertenece al futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                DateTime creation = dateTimePicker.Value;
                listBoxResolvedComments.Items.Clear();
                List<Comment> filteredPerCreation = handler.filterCreationDate(resolved, creation);
                foreach (Comment actualComment in filteredPerCreation)
                {
                    listBoxResolvedComments.Items.Add(actualComment);                       
                }
            }
        }

        private void buttonModDate_Click(object sender, EventArgs e)
        {
            RepositoryHandler handler = new RepositoryHandler(theRepository);
            if (dateTimePicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha seleccionada pertenece al futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime modification = dateTimePicker.Value;
                listBoxResolvedComments.Items.Clear();
                List<Comment> filteredPerResolving = handler.filterResolvingDate(resolved, modification);
                foreach (Comment actualComment in filteredPerResolving)
                {
                    listBoxResolvedComments.Items.Add(actualComment);                    
                }
            }
        }

        private void buttonCommentingUser_Click(object sender, EventArgs e)
        {
            RepositoryHandler handler = new RepositoryHandler(theRepository);
            User commentUser = (User)comboBoxUsers.SelectedItem;
            listBoxResolvedComments.Items.Clear();
            List<Comment> commentedBy = handler.filterCommentingUser(resolved, commentUser);
            foreach (Comment actualComment in commentedBy)
            {
                listBoxResolvedComments.Items.Add(actualComment);
            }

        }
    }
}
