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
    public partial class AddNewBlackBoard : UserControl
    {
        private string logged;
        private Repository theRepository;
        private Panel panelContainer;
        private Team team;
        public AddNewBlackBoard(string anUser, Repository aRepository, Panel container, Team teamToAddBlackBoard)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            team = teamToAddBlackBoard;
        }

        private void AddNewBlackBoard_Load(object sender, EventArgs e)
        {

        }

        public bool validations(string name, string description, string height, string width)
        {
            bool allValidationsOk = true;
            if (name.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("El nombre ingresado es vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (description.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("La descripcion ingresada es vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            if (height.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("La altura es vacia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            else
            {
                int n;
                if (int.TryParse(height, out n) == false)
                {
                    allValidationsOk = false;
                    MessageBox.Show("La altura no puede tener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return allValidationsOk;
                }
            }
            if (width.Length == 0)
            {
                allValidationsOk = false;
                MessageBox.Show("El ancho es vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return allValidationsOk;
            }
            else
            {
                int n;
                if (int.TryParse(width, out n) == false)
                {
                    allValidationsOk = false;
                    MessageBox.Show("El ancho no puede tener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return allValidationsOk;
                }
            }
            return allValidationsOk;
        }

        private void buttonCreateBlackBoard_Click(object sender, EventArgs e)
        {
            bool validationsOk = validations(textBoxName.Text, richTextBoxDescription.Text, textBoxHeight.Text, textBoxWidth.Text);
            if (validationsOk)
            {
                string blackBoardName = textBoxName.Text;
                string description = richTextBoxDescription.Text;
                int height = Int32.Parse(textBoxHeight.Text);
                int width = Int32.Parse(textBoxWidth.Text);
                BlackBoard newBlackBoard = new BlackBoard();
                newBlackBoard.Name = blackBoardName;
                newBlackBoard.Description = description;
                newBlackBoard.Dimension.Height = height;
                newBlackBoard.Dimension.Width = width;
                //UserHandler uHandler = new UserHandler(logged);
                bool existingBlackBoard = true;//uHandler.CreateBlackBoard(team, newBlackBoard);
                if (!existingBlackBoard)
                {
                    MessageBox.Show("El pizarron ingresado ya existe, o se le ingreso un tamaño pequeño/grande (El Ancho debe estar entre 50 y 750 y el Alto entre 50 y 500).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El pizarron ha sido ingresado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
            }
        }
    }
}
