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
    public partial class AddNewTeam : UserControl
    {
        private User logged;
        private Repository theRepository;
        public AddNewTeam(User anUser, Repository aRepository)
        {
            InitializeComponent();
            logged = anUser;
            theRepository = aRepository;
            foreach (User actualUser in theRepository.UserList)
            {

            }
        }
        private void AddNewTeam_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
