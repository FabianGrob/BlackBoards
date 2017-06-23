using BlackBoards;
using BlackBoards.Domain.BlackBoards;
using Persistance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIBlackBoards
{
    public partial class AddNewItem : UserControl
    {
        private Image File;
        private string FileNamePath;
        private string logged;
        private BlackBoard blackBoard;
        private Facade theFacade;
        private Panel containerPanel;
        private Panel blackboardPanel;

        public AddNewItem(string anUser, Facade facade, Panel container, Panel aBlackboardPanel, BlackBoard aBlackBoard)
        {
            BlackBoardPersistance BBcontext = new BlackBoardPersistance();
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            containerPanel = container;
            blackboardPanel = aBlackboardPanel;
            blackBoard = BBcontext.GetBlackBoardByName(aBlackBoard.Name);

            List<string> allFonts = loadAllFonts();
            foreach (string font in allFonts)
            {
                comboBoxFont.Items.Add(font);
            }
            comboBoxFont.SelectedIndex = 0;
        }

        public List<string> loadAllFonts()
        {
            List<string> fonts = new List<string>();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            return fonts;
        }

        public bool validationsTextBox(BlackBoards.TextBox newItem)
        {
            ValidationReturn validation = newItem.isValid();
            bool isValid = validation.Validation;
            if (!isValid)
            {
                MessageBox.Show(validation.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        public bool validationsPictures(Picture newPicture)
        {
            ValidationReturn validation = newPicture.IsValid();
            bool isValid = validation.Validation;
            if (!isValid)
            {
                MessageBox.Show(validation.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isValid;
        }

        private void buttonTextBox_Click(object sender, EventArgs e)
        {
            BlackBoards.TextBox newItem = new BlackBoards.TextBox();
            newItem.Font = (string)comboBoxFont.SelectedItem;
            newItem.FontSize = Convert.ToInt32(numericUpDown1.Value);
            newItem.Content = textBox.Text;
            bool ok = validationsTextBox(newItem);
            if (ok)
            {
                theFacade.newTextBox(blackBoard,newItem.Content,newItem.Dimension.Height,newItem.Dimension.Width,newItem.Origin.XAxis,newItem.Origin.YAxis,newItem.Font,newItem.FontSize);
               // UserHandler handler = new UserHandler(logged);
                //handler.AddItemToBlackBoard(blackBoard, newItem);
                blackboardPanel.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(blackBoard, logged, blackboardPanel,theFacade);
                blackboardPanel.Controls.Add(visualize);
                containerPanel.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, containerPanel, blackboardPanel, blackBoard);
                containerPanel.Controls.Add(pwindow);
            }
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (f.ShowDialog() == DialogResult.OK)
            {
                FileNamePath = f.FileName;
                File = Image.FromFile(f.FileName);
                pictureBox.Image = File;
            }
        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            Picture newPicture = new Picture();
            newPicture.ImgPath = (string)FileNamePath;
            newPicture.Description = textBox.Text;
            bool ok = validationsPictures(newPicture);
            if (ok)
            {
                UserPersistance userContext = new UserPersistance();
               UserHandler handler = new UserHandler(userContext.GetUserByEmail(logged));
               theFacade.newPicture(blackBoard,newPicture.Description,newPicture.Dimension.Height,newPicture.Dimension.Width,newPicture.Origin.XAxis,newPicture.Origin.YAxis,newPicture.ImgPath );
                blackboardPanel.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(blackBoard, logged, blackboardPanel,theFacade);
                blackboardPanel.Controls.Add(visualize);
                containerPanel.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, containerPanel, blackboardPanel, blackBoard);
                containerPanel.Controls.Add(pwindow);
            }
        }

        private void buttonComeBack_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theFacade, containerPanel, blackboardPanel, blackBoard);
            containerPanel.Controls.Add(pwindow);
        }
    }
}
