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
    public partial class ResolveItemComment : UserControl
    {

        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Repository theRepository;
        public ResolveItemComment(BlackBoard aBoard, string anUser, Panel container, Panel aBoardContainer, Item anItem, Repository aRepository)
        {
            InitializeComponent();
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer = container;
            boardContainer = aBoardContainer;
            theRepository = aRepository;
            foreach (Comment aComment in anItem.comments)
            {
                listBoxComments.Items.Add(aComment);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxComments.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun comentario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Comment selectedComment = (Comment)listBoxComments.SelectedItem;
                //UserHandler handler = new UserHandler(logged);
                if (selectedComment.ResolvingDate.Equals(DateTime.MaxValue))
                {
                    bool resolved = true;// handler.ResolveComment(selectedComment);
                    MessageBox.Show("El comentario se marcó como resuelto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                    ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, panelContainer, boardContainer, actualBlackBoard);
                    panelContainer.Controls.Add(pwindow);
                }
                else
                {
                    MessageBox.Show("El comentario ya estaba resuelto por: " + selectedComment.resolvingUser, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, panelContainer, boardContainer, actualBlackBoard);
            panelContainer.Controls.Add(pwindow);
        }
    }
}
