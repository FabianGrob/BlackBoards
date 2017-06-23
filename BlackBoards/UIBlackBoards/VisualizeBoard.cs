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
        private string logged;
        private BlackBoard blackBoard;
        private Facade theFacade;
        public VisualizeBoard(BlackBoard tBlackBoards, string uLogged, Facade facade)
        {
            InitializeComponent();
            blackBoard = tBlackBoards;
            logged = uLogged;
            theFacade = facade;
            panelOptions.Controls.Clear();
            panelBoard.Controls.Clear();
            ManageBlackBoard manageBlackBoards = new ManageBlackBoard(logged, theFacade, panelOptions, panelBoard, blackBoard);
            VisualizeBlackBoard visualizeBoards = new VisualizeBlackBoard(blackBoard, logged, panelBoard,theFacade);
            panelBoard.Controls.Add(visualizeBoards);
            panelOptions.Controls.Add(manageBlackBoards);
        }
    }
}
