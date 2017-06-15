using BlackBoards;
using BlackBoards.Domain.BlackBoards;
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
        private User logged;
        private BlackBoard blackBoard;
        private Repository theRepository;
        private Panel containerPanel;
        private Panel blackboardPanel;

        public AddNewItem(User anUser, Repository aRepository, Panel container, Panel aBlackboardPanel, BlackBoard aBlackBoard)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            containerPanel = container;
            blackboardPanel = aBlackboardPanel;
            blackBoard = aBlackBoard;
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
                UserHandler handler = new UserHandler(logged);
                handler.AddItemToBlackBoard(blackBoard, newItem);
                blackboardPanel.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(blackBoard, logged, blackboardPanel);
                blackboardPanel.Controls.Add(visualize);
                containerPanel.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, containerPanel, blackboardPanel, blackBoard);
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
                UserHandler handler = new UserHandler(logged);
                handler.AddItemToBlackBoard(blackBoard, newPicture);
                blackboardPanel.Controls.Clear();
                VisualizeBlackBoard visualize = new VisualizeBlackBoard(blackBoard, logged, blackboardPanel);
                blackboardPanel.Controls.Add(visualize);
                containerPanel.Controls.Clear();
                ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, containerPanel, blackboardPanel, blackBoard);
                containerPanel.Controls.Add(pwindow);
            }
        }

        private void buttonComeBack_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, containerPanel, blackboardPanel, blackBoard);
            containerPanel.Controls.Add(pwindow);
        }
    }
}
