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
using BlackBoards.Domain.BlackBoards;

namespace UIBlackBoards
{
    public partial class AddNewTeam : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public AddNewTeam(User anUser, Repository aRepository, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            foreach (User actualUser in theRepository.UserList)
            {
                listBoxAllUsers.Items.Add(actualUser);
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
        private bool isInListBox(User user, ListBox listBoxSelectedUsers)
        {
            return (listBoxSelectedUsers.Items.Contains(user));
        }
        public List<User> getSelectedUsers(ListBox listBoxSelectedUsers)
        {
            List<User> userList = new List<User>();
            foreach (User actualUser in theRepository.UserList)
            {
                if (isInListBox(actualUser, listBoxSelectedUsers))
                {
                    userList.Add(actualUser);
                }
            }
            return userList;
        }
        public ValidationReturn stringNumeric(string aString)
        {
            ValidationReturn validation = new ValidationReturn(true, "OK");
            int n;
            if (int.TryParse(aString, out n) == false)
            {
                validation.RedefineValues(false, "La cantidad de usuarios maxima no puede tener letras.");
            }
            return validation;
        }
        ValidationReturn addNewItem(string teamName, string description, int maxUsers, List<User> members, List<BlackBoard> blackBoards)
        {
            ValidationReturn validation = new ValidationReturn(false, "El equipo ha sido ingresado");
            AdminHandler handler = new AdminHandler((Admin)logged);
            ValidationReturn added = handler.CreateTeam(teamName, description, maxUsers, members, blackBoards, theRepository);
            return added;
        }
        private ValidationReturn validationNewItem()
        {
            List<User> members = getSelectedUsers(listBoxSelectedUsers);
            string teamName = textBoxName.Text;
            string description = richTextBoxDescription.Text;
            int maxUsers = Int32.Parse(textBoxCantMaxUsers.Text);
            List<BlackBoard> blackBoards = new List<BlackBoard>();
            Team newTeam = new Team();
            newTeam.Name = teamName;
            newTeam.Members = members;
            newTeam.MaxUsers = maxUsers;
            newTeam.Boards = blackBoards;
            newTeam.Description = description;
            ValidationReturn validation = newTeam.IsValid();
            bool isValid = validation.Validation;
            if (isValid)
            {
                validation = addNewItem(teamName, description, maxUsers, members, blackBoards);
            }
            bool wasAdded = validation.Validation;
            if (wasAdded)
            {
                MessageBox.Show(validation.Message, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelContainer.Controls.Clear();
            }
            else
            {
                MessageBox.Show(validation.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return validation;
        }
        private void buttonCreateTeam_Click(object sender, EventArgs e)
        {
            ValidationReturn stringValidation = stringNumeric(textBoxCantMaxUsers.Text);
            if (stringValidation.Validation)
            {
                ValidationReturn validation = validationNewItem();
            }
            else
            {
                MessageBox.Show(stringValidation.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteMember_Click(object sender, EventArgs e)
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
    }
}
