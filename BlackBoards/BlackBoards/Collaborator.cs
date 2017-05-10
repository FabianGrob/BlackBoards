using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Collaborator : User
    {

        public Collaborator()
        {
            this.Name = "Default name";
            this.LastName = "Default last name";
            this.Email = "Default email";
            this.BirthDate = new DateTime();
            this.Password = "Default password";

        }

        public Collaborator(String name, String lastName, String email, DateTime birthDate, String password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BirthDate = birthDate;
            this.Password = password;
        }

    }
}
