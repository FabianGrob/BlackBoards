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
    public partial class ResolveItemComment : UserControl
    {

        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Facade theFacade;
        private Item theItem;
        public ResolveItemComment(BlackBoard aBoard, string anUser, Panel container, Panel aBoardContainer, Item anItem, Facade facade)
        {
            BlackBoardPersistance bbctx = new BlackBoardPersistance();
            InitializeComponent();
            actualBlackBoard = bbctx.GetBlackBoardByName(aBoard.Name);
            logged = anUser;
            ItemPersistance itemctx = new ItemPersistance();
            theItem = itemctx.GetItem(anItem.IDItem);
            panelContainer = container;
            boardContainer = aBoardContainer;
            theFacade = facade;
            foreach (Comment aComment in theItem.comments)
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
                CommentPersistance commentctx = new CommentPersistance();
                Comment selectedComment = commentctx.GetComment(((Comment)listBoxComments.SelectedItem).IDComment);
                if (!theFacade.WasResolved(selectedComment))
                {
                    theFacade.resolveComment(logged,selectedComment);
                    MessageBox.Show("El comentario se marcó como resuelto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                    ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, panelContainer, boardContainer, actualBlackBoard);
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
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, panelContainer, boardContainer, actualBlackBoard);
            panelContainer.Controls.Add(pwindow);
        }
    }
}
