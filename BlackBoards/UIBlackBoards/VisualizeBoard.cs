using BlackBoards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIBlackBoards
{
    public partial class VisualizeBoard : Form
    {
        private User logged;
        private BlackBoard blackBoard;
        private Repository theRepository;
        public VisualizeBoard(BlackBoard tBlackBoards, User uLogged, Repository thRepository)
        {
            InitializeComponent();
            blackBoard = tBlackBoards;
            logged = uLogged;
            theRepository = thRepository;
            panelOptions.Controls.Clear();
            panelBoard.Controls.Clear();
            ManageBlackBoard manageBlackBoards = new ManageBlackBoard(logged, theRepository, panelOptions,panelBoard,blackBoard);
            VisualizeBlackBoard visualizeBoards = new VisualizeBlackBoard(blackBoard, logged, panelBoard);
            panelBoard.Controls.Add(visualizeBoards);
            panelOptions.Controls.Add(manageBlackBoards);
        }

        private void VisualizeBoard_Load(object sender, EventArgs e)
        {

        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
