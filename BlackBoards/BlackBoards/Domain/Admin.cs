using System;
namespace BlackBoards
{
    public class Admin : User
    {
        public Admin()
        {
            this.Name = "Default name";
            this.LastName = "Default last name";
            this.Email = "Default email";
            this.BirthDate = new DateTime();
            this.Password = "Default password";
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