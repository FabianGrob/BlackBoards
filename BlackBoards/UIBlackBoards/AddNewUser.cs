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
    public partial class AddNewUser : UserControl
    {
        private User logged;
        private Repository theRepository;
        private Panel panelContainer;
        public AddNewUser(User anUser, Repository aRepository, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            panelContainer = container;
            dateTimePicker.Value = DateTime.Today;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public bool isValid(string email, string fstPass, string sndPass, string name, string lastName,DateTime birthDate) {
            string[] splited = email.Split('@');
            bool valid = true;
            if (!(splited.Length == 2 && splited[0].Length > 0 && splited[1].Length > 0))
            {
                valid = false;
                MessageBox.Show("El formato de Email es incorrecto", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!fstPass.Equals(sndPass) || fstPass.Length < 4)
            {
                valid = false;
                MessageBox.Show("Las contraseñas no coinciden o tienen menos de 4 carácteres", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (name.Length < 3) {
                valid = false;
                MessageBox.Show("El nombre debe tener almenos 4 letras", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (lastName.Length < 3) {
                valid = false;
                MessageBox.Show("El apellido debe tener almenos 4 letras", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (birthDate > DateTime.Today) {
                valid = false;
                MessageBox.Show("La fecha de nacimiento seleccionada pertenece al futuro", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string fstPass = textBoxFstPass.Text;
            string sndPass = textBoxSndPass.Text;
            string name = textBoxName.Text;
            string lastName = textBoxLastN.Text;
            bool isAdmin = checkBoxAdmin.Checked;
            DateTime birthDate = dateTimePicker.Value;
            RepositoryHandler repHandler = new RepositoryHandler(theRepository);
            AdminHandler adminHandler = new AdminHandler((Admin)logged);
            bool created = false;
            if (isValid(email,fstPass,sndPass,name,lastName,birthDate))
            {

                if (isAdmin)
                {
                    created = adminHandler.CreateAdmin(name, lastName, email, birthDate, fstPass, theRepository);
                }
                else
                {
                    created = adminHandler.CreateCollaborator(name, lastName, email, birthDate, fstPass, theRepository);

                }
                if (created)
                {
                    MessageBox.Show("El usuario fue creado correctamente", "Error de autentificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelContainer.Controls.Clear();
                }
                else
                {
                    MessageBox.Show("El usuario no fue creado porque ya existe", "Error de autentificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
