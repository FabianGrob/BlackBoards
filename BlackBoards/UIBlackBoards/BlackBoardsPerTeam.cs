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
    public partial class BlackBoardsPerTeam : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public BlackBoardsPerTeam(User anUser, Repository aRepository, Panel container)
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

        private void BlackBoardsPerTeam_Load(object sender, EventArgs e)
        {

        }

        private void buttonChooseTeam_Click(object sender, EventArgs e)
        {
            if (listBoxTeams.SelectedIndex != -1)
            {
                Team selectedTeam = (Team)listBoxTeams.SelectedItem;
                panelContainer.Controls.Clear();
                TeamBlackBoards content = new TeamBlackBoards(logged, theRepository, panelContainer,selectedTeam);
                panelContainer.Controls.Add(content);
            }
            else {
                MessageBox.Show("No se selecciono ningun equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
