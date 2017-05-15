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
        private Item selectedItem;
        private Repository theRepository;
        public CommentItem(BlackBoard aBoard, User anUser, Panel container, Panel boardcontainer,Item actualItem,Repository aRepository)
        {
            InitializeComponent();
            InitializeComponent();
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
            selectedItem = actualItem;
            theRepository = aRepository;
        }

        private void CommentItem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 5)
            {
                UserHandler handler = new UserHandler(logged);
                handler.CreateNewComment(selectedItem, richTextBox1.Text);
                panelContainer.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged,theRepository,panelContainer,boardContainer,actualBlackBoard);
                panelContainer.Controls.Add(pwindow);
                MessageBox.Show("Se creó el comentario correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Se ingreso un comentario demasiado corto(almenos 6 letras)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, panelContainer, boardContainer, actualBlackBoard);
            panelContainer.Controls.Add(pwindow);
        }
    }
}
