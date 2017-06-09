﻿using System;
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
    public partial class ModifyTeam : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        private Team team;
        public ModifyTeam(User anUser, Repository aRepository, Panel container, Team teamToModify)
        {
            InitializeComponent();
            team = teamToModify;
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            foreach (User actualUser in theRepository.UserList)
            {
                TeamHandler handler = new TeamHandler(teamToModify);
                if(handler.IsUserInTeam(actualUser)){
                    listBoxSelectedUsers.Items.Add(actualUser);
                } else
                {
                    listBoxAllUsers.Items.Add(actualUser);
                }             
            }
            textBoxName.Text = team.Name;
            richTextBoxDescription.Text = team.Description;
            textBoxCantMaxUsers.Text = team.MaxUsers+"";
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonModifyTeam_Click(object sender, EventArgs e)
        {
            AddNewTeam validations = new AddNewTeam(logged,theRepository,panelContainer);
            bool validationsOk = validations.validations(textBoxName.Text, richTextBoxDescription.Text, textBoxCantMaxUsers.Text, validations.getSelectedUsers(listBoxSelectedUsers));
            if (validationsOk)
            {
                List<User> members= validations.getSelectedUsers(listBoxSelectedUsers);
                string teamName = textBoxName.Text;
                string description = richTextBoxDescription.Text;
                int maxUsers = Int32.Parse(textBoxCantMaxUsers.Text);
                List<BlackBoard> blackBoards = team.Boards;
                AdminHandler handler = new AdminHandler((Admin)logged);
     
                bool existingTeam = handler.ModifyTeam(team.Name,teamName, description, maxUsers, members, blackBoards, theRepository);
                if (!existingTeam)
                {
                    MessageBox.Show("El equipo ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El equipo ha sido modificado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxAllUsers.SelectedIndex;
            if (selectedIndex != -1)
            {
                User selectedUser = (User)listBoxAllUsers.SelectedItem;
                listBoxAllUsers.Items.Remove(selectedUser);
                listBoxSelectedUsers.Items.Add(selectedUser);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSelectedUsers.SelectedIndex;
            if (selectedIndex != -1)
            {
                User selectedUser = (User)listBoxSelectedUsers.SelectedItem;
                listBoxSelectedUsers.Items.Remove(selectedUser);
                listBoxAllUsers.Items.Add(selectedUser);
            }
            else
            {
                MessageBox.Show("No se selecciono ningun usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModifyTeam_Load(object sender, EventArgs e)
        {

        }

        private void labelSelectedUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
