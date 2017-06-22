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
    public partial class TeamBlackBoards : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        private Team actualTeam;
        public TeamBlackBoards(User anUser, Repository aRepository, Panel container, Team aTeam)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            actualTeam = aTeam;
            dateTimePicker.Value = DateTime.Today;
            List<BlackBoard> boardsToShow = actualTeam.boards;
            foreach (BlackBoard actualBoard in boardsToShow)
            {
                string line = "Equipo creador: " + actualTeam + "Fecha creación: " + actualBoard.CreationDate + " Última modificación: " + actualBoard.LastModificationDate + " Cantidad de elementos: " + actualBoard.itemList.Count;

                listBoxBoards.Items.Add(line);
            }
        }

        private void buttonfilter_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha seleccionada pertenece al futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime date = dateTimePicker.Value;
                List<BlackBoard> boardsToShow = actualTeam.boards;
                listBoxBoards.Items.Clear();
                foreach (BlackBoard actualBoard in boardsToShow)
                {
                    if (date.Equals(actualBoard.CreationDate))
                    {
                        string line = "Equipo creador: " + actualTeam + "Fecha creación: " + actualBoard.CreationDate + " Última modificación: " + actualBoard.LastModificationDate + " Cantidad de elementos: " + actualBoard.itemList.Count;
                        listBoxBoards.Items.Add(line);
                    }

                }


            }
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            List<BlackBoard> boardsToShow = actualTeam.boards;
            listBoxBoards.Items.Clear();
            foreach (BlackBoard actualBoard in boardsToShow)
            {
                string line = "Equipo creador: " + actualTeam + "Fecha creación: " + actualBoard.CreationDate + " Última modificación: " + actualBoard.LastModificationDate + " Cantidad elementos: " + actualBoard.itemList.Count;

                listBoxBoards.Items.Add(line);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
        }
    }
}
