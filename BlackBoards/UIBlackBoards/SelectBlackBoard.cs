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
using BlackBoards.Handlers;
using Persistance;

namespace UIBlackBoards
{
    public partial class SelectBlackBoard : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        private Team team;
        public SelectBlackBoard(string anUser, Facade facade, Panel container, Team teamToAddBlackBoard)
        {
            TeamPersistance teamContext = new TeamPersistance();
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            team = teamContext.GetTeamByName(teamToAddBlackBoard.Name);
            foreach (BlackBoard actualBoard in team.boards)
            {
                listBoxBlackBoards.Items.Add(actualBoard);
            }
        }

        private bool hasSelectedABlackBoard()
        {
            int selectedIndex = listBoxBlackBoards.SelectedIndex;
            bool hasSelected = (selectedIndex != -1);
            return hasSelected;
        }

        private void buttonModifyBlackBoard_Click(object sender, EventArgs e)
        {
            if (hasSelectedABlackBoard())
            {
                BlackBoardPersistance bbcontext = new BlackBoardPersistance();
                BlackBoard selectedBlackBoard = bbcontext.GetBlackBoardByName(((BlackBoard)listBoxBlackBoards.SelectedItem).Name);
                panelContainer.Controls.Clear();
                UserControl selectBlackBoard = new ModifyBlackBoard(logged, theFacade, panelContainer, team, selectedBlackBoard);
                panelContainer.Controls.Add(selectBlackBoard);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun pizarron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveBlackBoard_Click(object sender, EventArgs e)
        {
            if (hasSelectedABlackBoard())
            {
                BlackBoard selectedBlackBoard = (BlackBoard)listBoxBlackBoards.SelectedItem;
                bool hasDeletedTheTeam = false;// handler.RemoveBlackBoard(team, selectedBlackBoard, theRepository);

                if (hasDeletedTheTeam)
                {
                    MessageBox.Show("Pizarron " + selectedBlackBoard.Name + " borrado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo borrar el pizarron ya que no eres administrador ni el creador del mismo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ningun pizarron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonVisualice_Click(object sender, EventArgs e)
        {
            if (hasSelectedABlackBoard())
            {
                BlackBoard selectedBlackBoard = (BlackBoard)listBoxBlackBoards.SelectedItem;
                this.Visible = false;
                //VisualizeBoard newVi = new VisualizeBoard(selectedBlackBoard, logged, theFacade);
                //newVi.Visible = true;
            }
        }
    }
}
