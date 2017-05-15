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
        private User logged;
        private Panel panelContainer;
        private Panel boardContainer;
        public ItemListed(BlackBoard aBoard, User anUser, Panel container, Panel boardcontainer)
        {
            InitializeComponent();
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;

            foreach (Item actualItem in actualBlackBoard.ItemList)
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
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Item selectedItem = (Item)listBoxItems.SelectedItem;
                panelContainer.Controls.Clear();
               
                
            }
        }

        private void buttonResolve_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxItems.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No se ha seleccionado ningun usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Item selectedItem = (Item)listBoxItems.SelectedItem;
                panelContainer.Controls.Clear();


            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
        }
    }
}
