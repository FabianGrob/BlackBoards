﻿using BlackBoards;
using BlackBoards.Handlers;
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
    public partial class MainMenu : Form
    {
        private string logged;
        private Facade theFacade;
        public MainMenu(string anUser, Facade facade)
        {
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            bool isUserAdmin = theFacade.isUserAdmin(logged);
            buttonCreateTeam.Enabled = isUserAdmin;
            buttonModifyTeam.Enabled = isUserAdmin;
            buttonCreateUser.Enabled = isUserAdmin;
            buttonModifyUser.Enabled = isUserAdmin;
            buttonBlackBoardsPerTeam.Enabled = false;
            buttonCommentsInform.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl addUser = new AddNewUser(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(addUser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl userList = new UserList(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(userList);
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl addTeam = new AddNewTeam(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(addTeam);
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogIn windows = new LogIn(theFacade);
            this.Visible = false;
            windows.Visible = true;
        }
        private void buttonModifyTeam_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl modifyTeam = new TeamList(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(modifyTeam);
        }

        private void buttonBlackBoardsPerTeam_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl blackBoardsPerTeam = new BlackBoardsPerTeam(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(blackBoardsPerTeam);
        }

        private void buttonCreatePizarron_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl teamByUser = new TeamListByUser(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(teamByUser);
        }

        private void buttonCommentsInform_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UserControl informComments = new UserListForComments(logged, theFacade, panelContainer);
            panelContainer.Controls.Add(informComments);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          /*  RepositoryHandler handler = new RepositoryHandler(theFacade);
            bool generated = handler.loadTestData();
            if (generated)
            {                
                MessageBox.Show("Se generaron datos de prueba", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Los datos de prueba ya habian sido generados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

        }
    }
}
