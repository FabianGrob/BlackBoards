using System;
namespace BlackBoards
{
    public abstract class User
    {
        private string name;
        private string lastName;
        private string email;
        private DateTime birthDate;
        private string password;


       // [Obsolete("constructor only usable by EntityFramework", true)]
        public User()
        {

        }
        public User(string name, string lastName, string email, DateTime birthDate, string password)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.BirthDate = birthDate;
            this.Password = password;  
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
       
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return this.BirthDate;
            }
            set
            {
                this.BirthDate = value;
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }



    }
}
               
