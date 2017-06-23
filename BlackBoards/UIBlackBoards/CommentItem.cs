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
    public partial class CommentItem : UserControl
    {
        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private Panel boardContainer;
        private Item selectedItem;
        private Facade theFacade;
        public CommentItem(BlackBoard aBoard, string anUser, Panel container, Panel boardcontainer, Item actualItem, Facade facade)
        {
            BlackBoardPersistance bbctx = new BlackBoardPersistance();
            ItemPersistance itemctx = new ItemPersistance();
            InitializeComponent();
            actualBlackBoard = bbctx.GetBlackBoardByName(aBoard.Name);
            logged = anUser;
            panelContainer = container;
            boardContainer = boardcontainer;
            selectedItem = itemctx.GetItem(actualItem.IDItem);
            theFacade = facade;
        }
        private bool validateText(string text)
        {
            return text.Length > 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt = textBox1.Text;
            if (validateText(txt))
            {
                theFacade.newComment(logged, selectedItem, txt);
                panelContainer.Controls.Clear();

                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, panelContainer, boardContainer, actualBlackBoard);
                panelContainer.Controls.Add(pwindow);
                MessageBox.Show("Se creó el comentario correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se ingreso un comentario demasiado corto (almenos 6 letras)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, panelContainer, boardContainer, actualBlackBoard);
            panelContainer.Controls.Add(pwindow);
        }
    }
}
