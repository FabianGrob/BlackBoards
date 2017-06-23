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
    public partial class ItemListed : UserControl
    {
        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Facade theFacade;
        public ItemListed(BlackBoard aBoard, string anUser, Panel container, Panel boardcontainer, Facade facade)
        {
            BlackBoardPersistance bbctx = new BlackBoardPersistance();
            InitializeComponent();
            actualBlackBoard =bbctx.GetBlackBoardByName(aBoard.Name);
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
            theFacade = facade;

            foreach (Item actualItem in actualBlackBoard.itemList)
            {
                listBoxItems.Items.Add(actualItem);
            }
        }

        private void ItemListed_Load(object sender, EventArgs e)
        {

        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxItems.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Item selectedItem = (Item)listBoxItems.SelectedItem;
                panelContainer.Controls.Clear();
                CommentItem commentWindow = new CommentItem(actualBlackBoard, logged, panelContainer, boardContainer, selectedItem, theFacade);
                panelContainer.Controls.Add(commentWindow);


            }
        }

        private void buttonResolve_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxItems.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Item selectedItem = (Item)listBoxItems.SelectedItem;
                panelContainer.Controls.Clear();
                ResolveItemComment resolveWindow = new ResolveItemComment(actualBlackBoard, logged, panelContainer, boardContainer, selectedItem, theFacade);
                panelContainer.Controls.Add(resolveWindow);

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
