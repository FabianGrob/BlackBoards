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
    public partial class SelectItemToDelete : UserControl
    {
        private BlackBoard actualBlackBoard;
        private User logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Repository theRepository;
        public SelectItemToDelete(BlackBoard aBoard, User anUser, Panel container, Panel boardcontainer, Repository aRepository)
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

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool hasSelected()
        {
            int selectedIndex = listBoxItems.SelectedIndex;
            bool hasSelectedSomething = selectedIndex != -1;
            if (!hasSelectedSomething)
            {
                MessageBox.Show("No se ha seleccionado ningun elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hasSelectedSomething;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (hasSelected())
            {
                Item selectedItem = (Item)listBoxItems.SelectedItem;
                UserHandler handler = new UserHandler(logged);
                handler.RemoveItemBlackBoard(actualBlackBoard, selectedItem);
                boardContainer.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(actualBlackBoard, logged, boardContainer);
                boardContainer.Controls.Add(visualize);
                panelContainer.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, panelContainer, boardContainer, actualBlackBoard);
                panelContainer.Controls.Add(pwindow);
                MessageBox.Show("Se ha eliminado el elemento del pizarron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
