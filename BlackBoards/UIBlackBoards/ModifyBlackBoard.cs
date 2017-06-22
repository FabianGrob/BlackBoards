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
    public partial class ModifyBlackBoard : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        private Team team;
        private BlackBoard oldBlackBoard;
        public ModifyBlackBoard(string anUser, Facade facade, Panel container, Team teamToModifyBlackBoard, BlackBoard oBlackBoard)
        {
            TeamPersistance teamContext = new TeamPersistance();
            BlackBoardPersistance blackBoardCOntext = new BlackBoardPersistance();
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            team = teamContext.GetTeamByName(teamToModifyBlackBoard.Name);
            oldBlackBoard = blackBoardCOntext.GetBlackBoardByName(oBlackBoard.Name);
            textBoxName.Text = oldBlackBoard.Name;
            textBoxWidth.Text = oldBlackBoard.Dimension.Width + "";
            textBoxHeight.Text = oldBlackBoard.Dimension.Height + "";
            richTextBoxDescription.Text = oldBlackBoard.Description;
        }

        private void buttonModifiyBlackBoard_Click(object sender, EventArgs e)
        {
            AddNewBlackBoard doValidations = new AddNewBlackBoard(logged, theFacade, panelContainer, team);

            bool validationsOk = doValidations.validations(textBoxName.Text, richTextBoxDescription.Text, textBoxHeight.Text, textBoxWidth.Text);
            if (validationsOk)
            {
                BlackBoardPersistance bbContext = new BlackBoardPersistance();
                string blackBoardName = textBoxName.Text;
                string description = richTextBoxDescription.Text;
                int height = Int32.Parse(textBoxHeight.Text);
                int width = Int32.Parse(textBoxWidth.Text);
                BlackBoard toModify = bbContext.GetBlackBoardByName(oldBlackBoard.Name);
                BlackBoard newBlackBoard = new BlackBoard();
                newBlackBoard.Name = blackBoardName;
                newBlackBoard.Description = description;
                newBlackBoard.Dimension.Height = height;
                newBlackBoard.Dimension.Width = width;
                bool existingBlackBoard = theFacade.modifyBlackBoard(logged,team,newBlackBoard,toModify).Validation;
                if (!existingBlackBoard)
                {
                    MessageBox.Show("El pizarron ingresado ya existe, o se le ingreso un tamaño pequeño / grande (El Ancho debe estar entre 50 y 750 y el Alto entre 50 y 500). * Los elementos del pizarron deben caber en las nuevas dimensiones del mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El pizarron ha sido modificado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
            }
        }
    }
}
