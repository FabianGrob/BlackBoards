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
    public partial class ManageBlackBoard : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        private Panel panelContainerBlackBoard;
        private BlackBoard blackBoard;
        public ManageBlackBoard(User anUser, Repository aRepository, Panel container, Panel containerBlackBoard, BlackBoard aBlackBoard)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            panelContainerBlackBoard = containerBlackBoard;
            blackBoard = aBlackBoard;
        }

        private void buttonCreateItem_Click(object sender, EventArgs e)
        {
            AddNewItem newVisualize = new AddNewItem(logged, theRepository, panelContainer, panelContainerBlackBoard, blackBoard);
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(newVisualize);
        }

        private void buttonManageComment_Click(object sender, EventArgs e)
        {
            ItemListed newVisualize = new ItemListed(blackBoard,logged,panelContainer, panelContainerBlackBoard, theRepository);
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(newVisualize);
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            SelectItemToDelete newVisualize = new SelectItemToDelete(blackBoard, logged, panelContainer, panelContainerBlackBoard, theRepository);
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(newVisualize);
        }
    }
}
