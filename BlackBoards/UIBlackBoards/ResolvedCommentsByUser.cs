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
using Persistance;

namespace UIBlackBoards
{
    public partial class ResolvedCommentsByUser : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        private User selectedUser;
        private List<Comment> resolved;
        public ResolvedCommentsByUser(string anUser, Facade facade, Panel container, User selected)
        {
            InitializeComponent();
            UserPersistance userctx = new UserPersistance();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            selectedUser = userctx.GetUserByEmail(selected.Email);
            dateTimePicker.Value = DateTime.Today;
            label1.Text = "Comentarios resueltos por el Usuario: " + selectedUser.Email;
            resolved = theFacade.ResolvedCommentsByUser(selectedUser);
            foreach (Comment actualComment in resolved)
            {
                listBoxResolvedComments.Items.Add(actualComment);
            }
            foreach (User actualUser in userctx.allUsers())
            {
                comboBoxUsers.Items.Add(actualUser);
            }
            comboBoxUsers.SelectedIndex = 0;
        }

        private void buttonCreationDAte_Click(object sender, EventArgs e)
        {

            if (dateTimePicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha seleccionada pertenece al futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime creation = dateTimePicker.Value;
                listBoxResolvedComments.Items.Clear();
                List<Comment> filteredPerCreation = theFacade.filterCreationDate(resolved, creation);
                foreach (Comment actualComment in filteredPerCreation)
                {
                    listBoxResolvedComments.Items.Add(actualComment);
                }
            }
        }

        private void buttonModDate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha seleccionada pertenece al futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime modification = dateTimePicker.Value;
                listBoxResolvedComments.Items.Clear();
                List<Comment> filteredPerResolving = theFacade.filterResolvingDate(resolved, modification);
                foreach (Comment actualComment in filteredPerResolving)
                {
                    listBoxResolvedComments.Items.Add(actualComment);
                }
            }
        }

        private void buttonCommentingUser_Click(object sender, EventArgs e)
        {
            UserPersistance userctx = new UserPersistance();
            User commentUser = userctx.GetUserByEmail(((User)comboBoxUsers.SelectedItem).Email);
            listBoxResolvedComments.Items.Clear();
            List<Comment> commentedBy = theFacade.filterCommentingUser(resolved, commentUser);
            foreach (Comment actualComment in commentedBy)
            {
                listBoxResolvedComments.Items.Add(actualComment);
            }

        }
    }
}
