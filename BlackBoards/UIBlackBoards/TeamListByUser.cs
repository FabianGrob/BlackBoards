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
    public partial class TeamListByUser : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public TeamListByUser(string anUser, Facade facade, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            
            List<Team> listOfTeamsByUser = theFacade.GetTeamsBelongs(logged);
            foreach (Team actualteam in listOfTeamsByUser)
            {
                listBoxTeams.Items.Add(actualteam);
            }
        }

        private bool hasSelectedATeam()
        {
            int selectedIndex = listBoxTeams.SelectedIndex;
            bool hasSelected = (selectedIndex != -1);
            return hasSelected;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (hasSelectedATeam())
            {
                Team selectedTeam = (Team)listBoxTeams.SelectedItem;
                panelContainer.Controls.Clear();
                UserControl addNewBlackBoardWindow = new AddNewBlackBoard(logged, theFacade, panelContainer, selectedTeam);
                panelContainer.Controls.Add(addNewBlackBoardWindow);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModifyBlackBoards_Click(object sender, EventArgs e)
        {
            if (hasSelectedATeam())
            {
                TeamPersistance teamContext = new TeamPersistance();
                Team selectedTeam = teamContext.GetTeamByName(((Team)listBoxTeams.SelectedItem).Name);
                panelContainer.Controls.Clear();
                UserControl selectBlackBoard = new SelectBlackBoard(logged, theFacade, panelContainer, selectedTeam);
                panelContainer.Controls.Add(selectBlackBoard);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
