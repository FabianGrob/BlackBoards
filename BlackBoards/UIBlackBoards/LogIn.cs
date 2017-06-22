using System;
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
using BlackBoards.Domain.BlackBoards;

namespace UIBlackBoards
{
    public partial class LogIn : Form
    {
        private Facade theFacade;
        public LogIn(Facade facade)
        {
            InitializeComponent();
            theFacade = facade;
            List<User> allUsers = facade.GetAllUSersInDB();
            foreach (User actualUser in allUsers) {
                comboBoxUsers.Items.Add(actualUser);
            }
            textBoxPassword.PasswordChar = '*';
            comboBoxUsers.SelectedIndex = 0;
        }
        

        private void start_Click(object sender, EventArgs e)
        {
           
           User selectedUser = (User)comboBoxUsers.SelectedItem;
            if (selectedUser == null)
            {
                MessageBox.Show("El usuario no existe", "Error de autentificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string posibleEmail = (string)selectedUser.Email;
                string posiblePassword = textBoxPassword.Text;
                ValidationReturn canLogIn = theFacade.CanLogWithUser(posibleEmail, posiblePassword);
                if (canLogIn.Validation)
                {
                    User entering = theFacade.GetSpecificUser(selectedUser.Email);
                    MainMenu window =new MainMenu(entering.Email,theFacade);
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
