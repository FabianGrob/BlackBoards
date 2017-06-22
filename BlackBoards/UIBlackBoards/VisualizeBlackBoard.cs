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
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace UIBlackBoards
{
    public partial class VisualizeBlackBoard : UserControl
    {
        private BlackBoard actualBlackBoard;
        private string logged;
        private Panel panelContainer;
        private List<Control> controls;

        public VisualizeBlackBoard(BlackBoard aBoard, string anUser, Panel container)
        {
            InitializeComponent();
            panelContainer = container;
            actualBlackBoard = aBoard;
            logged = anUser;
            panelContainer.SetBounds(0, 0, actualBlackBoard.Dimension.Width, actualBlackBoard.Dimension.Height);
            controls = new List<Control>();
            loadControls();
        }
        private void loadControls()
        {
            foreach (Item actualItem in actualBlackBoard.itemList)
            {
                Control controlToAdd;
                if (actualItem.IsPicture())
                {
                    PictureBox actualControl = new PictureBox();
                    Picture itemToAdd = actualItem as Picture;
                    //controlToAdd = 

                    actualControl.SizeMode = PictureBoxSizeMode.StretchImage;
                    actualControl.Image = itemToAdd.Img();
                    actualControl.SetBounds(itemToAdd.Origin.XAxis, itemToAdd.Origin.YAxis, itemToAdd.Dimension.Width, itemToAdd.Dimension.Height);
                    controlToAdd = actualControl;
                }
                else
                {
                    RichTextBox actualControl = new RichTextBox();
                    BlackBoards.TextBox itemToAdd = actualItem as BlackBoards.TextBox;
                    actualControl = new RichTextBox();
                    actualControl.Text = itemToAdd.Content;
                    actualControl.Font = new Font(itemToAdd.Font, itemToAdd.FontSize);
                    actualControl.SetBounds(itemToAdd.Origin.XAxis, itemToAdd.Origin.YAxis, itemToAdd.Dimension.Width, itemToAdd.Dimension.Height);
                    actualControl.Visible = true;
                    controlToAdd = actualControl;
                }

                ControlMoverOrResizer.Init(controlToAdd);
                controls.Add(controlToAdd);
                Controls.Add(controlToAdd);
            }
            /*   
        
             public override Control Print()
        {
            RichTextBox itemToAdd = new RichTextBox();
            itemToAdd.Text = this.content;
            itemToAdd.Font = new Font(this.Font, this.FontSize);
            itemToAdd.SetBounds(this.Origin.XAxis, this.Origin.YAxis, this.Dimension.Width, this.Dimension.Height);
            itemToAdd.Visible = true;
            return itemToAdd;
        }*/
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int indexItems = 0;
            foreach (Control aControl in controls)
            {
                int x = aControl.Bounds.X;
                int y = aControl.Bounds.Y;
                int height = aControl.Bounds.Height;
                int width = aControl.Bounds.Width;
                Item actualItem = actualBlackBoard.itemList.ElementAt(indexItems);
                actualItem.Dimension.Height = height;
                actualItem.Dimension.Width = width;
                actualItem.Origin.XAxis = x;
                actualItem.Origin.YAxis = y;
                if (!actualItem.IsPicture())
                {
                    BlackBoards.TextBox actualTxtBx = (BlackBoards.TextBox)actualItem;
                    actualTxtBx.Content = aControl.Text;
                }
                indexItems++;

            }
            MessageBox.Show("Se guardaron las posiciones correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl discardWindow = new VisualizeBlackBoard(actualBlackBoard, logged, panelContainer);
            panelContainer.Controls.Add(discardWindow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var gfxScreenshot = Graphics.FromImage(Screenshot);
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "PNG(*.PNG)|*.png";

            if (f.ShowDialog() == DialogResult.OK)
            {
                Screenshot.Save(f.FileName, ImageFormat.Png);
            }

        }

    }
}
