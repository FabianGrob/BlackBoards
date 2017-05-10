using System;
namespace BlackBoards
{
    public class Admin : User
    {
        public Admin(string name, string lastName, string email, DateTime birthDate, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BirthDate = birthDate;
            this.Password = password;
        }
        
    }
}