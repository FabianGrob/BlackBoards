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
    public partial class CommentItem : UserControl
    {
        private BlackBoard actualBlackBoard;
        private User logged;
        private Panel panelContainer;
        private Panel boardContainer;
        public CommentItem(BlackBoard aBoard, User anUser, Panel container, Panel boardcontainer)
        {
            InitializeComponent();
            InitializeComponent();
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
        }

        private void CommentItem_Load(object sender, EventArgs e)
        {

        }
    }
}
