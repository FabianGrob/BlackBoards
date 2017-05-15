using BlackBoards;
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

        private void AddNewItem_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTextBox_Click(object sender, EventArgs e)
        {
            BlackBoards.TextBox newItem = new BlackBoards.TextBox();
            newItem.Font = (string)comboBoxFont.SelectedItem;
            newItem.FontSize = Convert.ToInt32(numericUpDown1.Value);
            newItem.Content = textBox.Text;
            UserHandler handler = new UserHandler(logged);
            handler.AddItemToBlackBoard(blackBoard, newItem);

            blackboardPanel.Controls.Clear();
            VisualizeBlackBoard visualize = new VisualizeBlackBoard(blackBoard, logged, blackboardPanel);
            blackboardPanel.Controls.Add(visualize);

        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";

            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                pictureBox.Image = File;
            }
        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            Picture newPicture = new Picture();
            newPicture.Img = File;
            newPicture.Description = textBox.Text;
            UserHandler handler = new UserHandler(logged);
            handler.AddItemToBlackBoard(blackBoard, newPicture);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
