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
using System.Collections;

namespace UIBlackBoards
{
    public partial class VisualizeBlackBoard : UserControl
    {
        private BlackBoard actualBlackBoard;
        private User logged;
        private Panel panelContainer;
        private List<Control> controls;
        public VisualizeBlackBoard(BlackBoard aBoard,User anUser,Panel container)
        {
            InitializeComponent();
            panelContainer = container;
            actualBlackBoard = aBoard;
            logged = anUser;
            panel.SetBounds(0, 0, actualBlackBoard.Dimension.Width, actualBlackBoard.Dimension.Height);
            controls = new List<Control>();
            foreach (Item actualItem in actualBlackBoard.ItemList) {
               /*
                if (actualItem.IsPicture())
                {
                    PictureBox itemToAdd = new PictureBox();
                    itemToAdd.Image= actualItem.Image;
                    itemToAdd.SetBounds(actualItem.Origin.XAxis, actualItem.Origin.YAxis, actualItem.Dimension.Width, actualItem.Dimension.Height);
                    ControlMoverOrResizer.Init(itemToAdd);
                    controls.Add(itemToAdd);
                   
                    
                }
                else{
                    RichTextBox itemToAdd = new RichTextBox();
                    itemToAdd.Text = ((BlackBoards.TextBox)actualItem).Content;
                    itemToAdd.Font = new Font(((BlackBoards.TextBox)actualItem).Font, ((BlackBoards.TextBox)actualItem).FontSize) ;
                    itemToAdd.SetBounds(actualItem.Origin.XAxis, actualItem.Origin.YAxis, actualItem.Dimension.Width, actualItem.Dimension.Height);
                    ControlMoverOrResizer.Init(itemToAdd);
                    controls.Add(itemToAdd);
                }*/
                
              
            }
           
        }

        private void VisualizeBlackBoard_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int indexItems = 0; ;
            foreach (Control aControl in controls)
            {
                int x =aControl.Bounds.X;
                int y = aControl.Bounds.Y;
                int height = aControl.Bounds.Height;
                int width = aControl.Bounds.Width;
                Item actualItem = actualBlackBoard.ItemList.ElementAt(indexItems);
                actualItem.Dimension.Height = height;
                actualItem.Dimension.Width = width;
                actualItem.Origin.XAxis = x;
                actualItem.Origin.YAxis = y;
                if (!actualItem.IsPicture())
                {
                    BlackBoards.TextBox actualTxtBx = (BlackBoards.TextBox)actualItem;
                    actualTxtBx.Content = aControl.Text;
                }

            }
            MessageBox.Show("Se guardaron las posiciones correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl discardWindow = new VisualizeBlackBoard(actualBlackBoard, logged, panelContainer);
            panelContainer.Controls.Add(discardWindow);
        }
    }
}
