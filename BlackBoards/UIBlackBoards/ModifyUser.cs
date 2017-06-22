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
using BlackBoards.Handlers;

namespace UIBlackBoards
{
    public partial class ModifyUser : UserControl
    {
        private string logged;
        private Repository theRepository;
        private Panel panelContainer;
        private User userToModify;
        public ModifyUser(string anUser, Repository aRepository, Panel container, User modifyingUser)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            userToModify = modifyingUser;

            textBoxEmail.Text = userToModify.Email;
            textBoxFstPass.Text = userToModify.Password;
            textBoxSndPass.Text = userToModify.Password;
            textBoxName.Text = userToModify.Name;
            textBoxLastN.Text = userToModify.LastName;
            dateTimePicker.Value = userToModify.BirthDate;

        }

        private void buttonGeneratePassword_Click(object sender, EventArgs e)
        {
            string posibleChars = "0123456789abcdefghijlkmnopqrstuvwxyz";
            string generatedPassword = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                generatedPassword = generatedPassword + posibleChars.ElementAt(rnd.Next(1, 34));
            }
            textBoxFstPass.Text = generatedPassword;
            textBoxSndPass.Text = generatedPassword;
        }

        private void buttonModify_Click_1(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string fstPass = textBoxFstPass.Text;
            string sndPass = textBoxSndPass.Text;
            string name = textBoxName.Text;
            string lastName = textBoxLastN.Text;
            DateTime birthDate = dateTimePicker.Value;
            Facade facade = new Facade();
            BlackBoards.Domain.BlackBoards.ValidationReturn validation = facade.modifyUser(logged, email, fstPass, name, lastName, birthDate);
            if (validation.Validation)
            {
                MessageBox.Show("Usuario modificado correctamente", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelContainer.Controls.Clear();
            }
            else
            {
                MessageBox.Show("El email nuevo ya esta registrado como otro usuario", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
