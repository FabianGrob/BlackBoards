using System;
using System.Collections.Generic;

namespace BlackBoards
{
    public abstract class User
    {
        public int ID { get; set; }
        private string name;
        private string lastName;
        private string email;
        private DateTime birthDate;
        
        public string password;
       // public virtual List<Team> teams { get; set; }
        // [Obsolete("constructor only usable by EntityFramework", true)]
        public User()
        {
           
            this.ID = 1;
            this.Name = "Default name";
            this.LastName = "Default lastname";
            this.Email = "Default email";
            this.BirthDate = DateTime.Now;
          
            this.Password = "Default password";
          //  this.teams = new List<Team>();
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
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
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
        public override bool Equals(object anUser)
        {
            if (anUser == null)
            {
                return false;
            }
            User anotherUser = anUser as User;
            if ((System.Object)anotherUser == null)
            {
                return false;
            }

            return (this.Email.Equals(anotherUser.Email));
        }
        public override string ToString()
        {
            return this.email;
        }
    }
}

