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
        }

        private void BlackBoardsPerTeam_Load(object sender, EventArgs e)
        {

        }
    }
}
