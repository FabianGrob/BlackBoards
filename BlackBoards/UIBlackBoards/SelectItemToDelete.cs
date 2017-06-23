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
    public partial class SelectItemToDelete : UserControl
    {
        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Facade theFacade;
        public SelectItemToDelete(BlackBoard aBoard, string anUser, Panel container, Panel boardcontainer, Facade facade)
        {
            BlackBoardPersistance bbctx = new BlackBoardPersistance();
            InitializeComponent();
            actualBlackBoard = bbctx.GetBlackBoardByName(aBoard.Name);
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
            theFacade = facade;
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
                ItemPersistance itemctx = new ItemPersistance();
                Item selectedItem = itemctx.GetItem(((Item)listBoxItems.SelectedItem).IDItem);
                UserPersistance userContext = new UserPersistance();
                UserHandler handler = new UserHandler(userContext.GetUserByEmail(logged));
                User completeLoggedUser = userContext.GetUserByEmail(logged);
                theFacade.DeleteItem(completeLoggedUser,actualBlackBoard, selectedItem);
                boardContainer.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(actualBlackBoard, logged, boardContainer,theFacade);
                boardContainer.Controls.Add(visualize);
                panelContainer.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, panelContainer, boardContainer, actualBlackBoard);
                panelContainer.Controls.Add(pwindow);
                MessageBox.Show("Se ha eliminado el elemento del pizarron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
