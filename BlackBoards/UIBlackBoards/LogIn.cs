﻿using System;
using BlackBoards;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackBoards.Handlers;

namespace UIBlackBoards
{
    public partial class LogIn : Form
    {
        private Repository theRepository;
        public LogIn(Repository aRepository)
        {
            InitializeComponent();
            theRepository = aRepository;
            foreach (User actualUser in theRepository.UserList) {
                comboBoxUsers.Items.Add(actualUser);
            }
            textBoxPassword.PasswordChar = '*';
            comboBoxUsers.SelectedIndex = 0;
        }
        

        private void start_Click(object sender, EventArgs e)
        {
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
           
           User selectedUser = (User)comboBoxUsers.SelectedItem;
            if (selectedUser == null)
            {
                MessageBox.Show("El usuario no existe", "Error de autentificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string posibleEmail = (string)selectedUser.Email;
                string posiblePassword = textBoxPassword.Text;
                if (repHandler.CheckPassword(posibleEmail, posiblePassword))
                {
                    User entering = repHandler.getSepcificUser(posibleEmail);
                    MainMenu window =new MainMenu(entering,theRepository);
                    window.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Usuario inválido o contraseña incorrecta", "Error de autentificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
