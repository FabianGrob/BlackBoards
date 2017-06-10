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

namespace UIBlackBoards
{
    public partial class SelectBlackBoard : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        private Team team;
        public SelectBlackBoard(User anUser, Repository aRepository, Panel container, Team teamToAddBlackBoard)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            team = teamToAddBlackBoard;
            foreach (BlackBoard actualBoard in team.Boards)
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
                BlackBoard selectedBlackBoard = (BlackBoard)listBoxBlackBoards.SelectedItem;
                panelContainer.Controls.Clear();
                UserControl selectBlackBoard = new ModifyBlackBoard(logged, theRepository, panelContainer, team,selectedBlackBoard);
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
                UserHandler handler = new UserHandler(logged);
                bool hasDeletedTheTeam = handler.RemoveBlackBoard(team, selectedBlackBoard, theRepository);
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
                VisualizeBoard newVi = new VisualizeBoard(selectedBlackBoard, logged, theRepository);
                newVi.Visible = true;
            }
        }
    }
}
