using System;
namespace BlackBoards
{
    public class Admin : User
    {
        public Admin()
        {

        }
        public Admin(String name, String lastName, String email, DateTime birthDate, String password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BirthDate = birthDate;
            this.Password = password;
        }
        
    }
}