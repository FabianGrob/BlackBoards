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
    public partial class TeamListByUser : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public TeamListByUser(User anUser, Repository aRepository, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            RepositoryHandler rHandler = new RepositoryHandler(aRepository);
            List<Team> listOfTeamsByUser = rHandler.getUserTeams(logged);
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
                Team selectedTeam = (Team) listBoxTeams.SelectedItem;
                panelContainer.Controls.Clear();
                UserControl addNewBlackBoardWindow = new AddNewBlackBoard(logged, theRepository, panelContainer, selectedTeam);
                panelContainer.Controls.Add(addNewBlackBoardWindow);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
