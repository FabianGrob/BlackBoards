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
    public partial class ItemListed : UserControl
    {
        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Repository theRepository;
        public ItemListed(BlackBoard aBoard, string anUser, Panel container, Panel boardcontainer, Repository aRepository)
        {
            InitializeComponent();
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
            theRepository = aRepository;

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
                CommentItem commentWindow = new CommentItem(actualBlackBoard, logged, panelContainer, boardContainer, selectedItem, theRepository);
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
                ResolveItemComment resolveWindow = new ResolveItemComment(actualBlackBoard, logged, panelContainer, boardContainer, selectedItem, theRepository);
                panelContainer.Controls.Add(resolveWindow);

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
