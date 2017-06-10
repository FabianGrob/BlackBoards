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
    public partial class TeamList : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public TeamList(User anUser, Repository aRepository, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            foreach (Team actualteam in theRepository.TeamList)
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
                Team selectedTeam = (Team)listBoxTeams.SelectedItem;
                panelContainer.Controls.Clear();
                UserControl modifyTeamWindow = new ModifyTeam(logged, theRepository, panelContainer, selectedTeam);
                panelContainer.Controls.Add(modifyTeamWindow);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (hasSelectedATeam())
            {
                Team selectedTeam = (Team)listBoxTeams.SelectedItem;
                AdminHandler handler = new AdminHandler((Admin)logged);
                bool hasDeletedTheTeam = handler.DeleteTeam(selectedTeam.Name, theRepository);
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
