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
        private string logged;
        private Facade theFacade;
        private Panel panelContainer;
        public AddNewUser(string anUser, Facade facade, Panel container)
        {
            InitializeComponent();
            logged = anUser;
            theFacade = facade;
            panelContainer = container;
            dateTimePicker.Value = DateTime.Today;
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
            Facade facade = new Facade();
            BlackBoards.Domain.BlackBoards.ValidationReturn validation;
            if (isAdmin)
            {
                validation = facade.newAdmin(logged, email, fstPass, name, lastName, birthDate);
            }
            else
            {
                validation = facade.newUser(logged, email, fstPass, name, lastName, birthDate);
            }
            if (validation.Validation)
            {
                MessageBox.Show(validation.Message, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelContainer.Controls.Clear();
            }
            else
            {
                MessageBox.Show(validation.Message, "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
