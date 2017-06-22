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
    public partial class TeamList : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public TeamList(string anUser, Facade facade, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            foreach (Team actualteam in theFacade.GetAllTeamsInDB())
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

        private void buttonModify_Click(object sender, EventArgs e)
        {
            if (hasSelectedATeam())
            {
                Team selectedTeam = theFacade.GetSpecificTeam(((Team)listBoxTeams.SelectedItem).Name);
                panelContainer.Controls.Clear();
                UserControl modifyTeamWindow = new ModifyTeam(logged, theFacade, panelContainer, selectedTeam);
                panelContainer.Controls.Add(modifyTeamWindow);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            TeamPersistance teamContext = new TeamPersistance();
            UserPersistance userContext = new UserPersistance();
            if (hasSelectedATeam())
            {
                Team selectedTeam = teamContext.GetTeamByName(((Team)listBoxTeams.SelectedItem).Name);
                bool hasDeletedTheTeam = theFacade.deleteTeam(logged,selectedTeam.Name).Validation;
                if (hasDeletedTheTeam)
                {
                    MessageBox.Show("Equipo " + selectedTeam.Name + " borrado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("No se pudo borrar al equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TeamList_Load(object sender, EventArgs e)
        {

        }
    }
}
