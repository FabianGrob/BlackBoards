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
    public partial class BlackBoardsPerTeam : UserControl
    {
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public BlackBoardsPerTeam(string anUser, Facade facade, Panel container)
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

        private void buttonChooseTeam_Click(object sender, EventArgs e)
        {
            if (listBoxTeams.SelectedIndex != -1)
            {
                TeamPersistance teamContext = new TeamPersistance();
                Team selectedTeam = teamContext.GetTeamByName(((Team)listBoxTeams.SelectedItem).Name);
                panelContainer.Controls.Clear();
                TeamBlackBoards content = new TeamBlackBoards(logged, theFacade, panelContainer,selectedTeam);
                panelContainer.Controls.Add(content);
            }
            else {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
