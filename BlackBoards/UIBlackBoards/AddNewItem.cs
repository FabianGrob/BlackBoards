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

        public bool validationsTextBox(string text, string font, int fontSize)
        {
            bool allValidationsOk = true;
            if (text.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("El texto ingresado es vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (font.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("La fuente ingresada es invalida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (fontSize<0)
            {
                allValidationsOk = false;
                MessageBox.Show("El tamaño de fuente no puede ser menor a 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            return allValidationsOk;
        }

        public bool validationsPictures(string text, Image aFile)
        {
            bool allValidationsOk = true;
            if (text.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("El texto ingresado es vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (aFile==null)
            {
                allValidationsOk = false;
                MessageBox.Show("No se ha cargado ninguna foto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            } 
            return allValidationsOk;
        }

        private void buttonTextBox_Click(object sender, EventArgs e)
        {
            bool ok=validationsTextBox(textBox.Text,(string)comboBoxFont.SelectedItem, Convert.ToInt32(numericUpDown1.Value));
            if (ok)
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
                File = Image.FromFile(f.FileName);
                pictureBox.Image = File;
                
            }
        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            bool ok = validationsPictures(textBox.Text, File);
            if (ok)
            {
                Picture newPicture = new Picture();
                newPicture.Img = File;
                newPicture.Description = textBox.Text;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonComeBack_Click(object sender, EventArgs e)
        {
            containerPanel.Controls.Clear();
            ManageBlackBoard pwindow = new ManageBlackBoard(logged, theRepository, containerPanel, blackboardPanel, blackBoard);
            containerPanel.Controls.Add(pwindow);
        }
    }
}
