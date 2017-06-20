using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackBoards
{
    public abstract class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        private string nameUser;
        private string lastNameUser;
        private string emailUser;
        private DateTime birthDateUser;
        public string passwordUser;
        public virtual List<Team> belongInteams { get; set; }
        public virtual List<Comment> createdComments { get; set; }
        public virtual List<Comment> resolvedComments { get; set; }
        public virtual List<ScoreUserInTeam> scoresInTeams { get; set; }
        // [Obsolete("constructor only usable by EntityFramework", true)]
        public User()
        {         
            this.ID = 1;
            this.Name = "Default name";
            this.LastName = "Default lastname";
            this.Email = "Default email";
            this.BirthDate = DateTime.Now;
            this.Password = "Default password";
            this.belongInteams = new List<Team>();
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
                return this.nameUser;
            }
            set
            {
                this.nameUser = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastNameUser;
            }
            set
            {
                this.lastNameUser = value;
            }
        }
        public string Email
        {
            get
            {
                return this.emailUser;
            }
            set
            {
                this.emailUser = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return this.birthDateUser;
            }
            set
            {
                this.birthDateUser = value;
            }
        }
        public string Password
        {
            get
            {
                return this.passwordUser;
            }
            set
            {
                this.passwordUser = value;
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


        private bool validEmail()
        {
            return (this.emailUser.Length > 0);
        }
        public ValidationReturn IsValid()
        {
            ValidationReturn validation = new ValidationReturn(true,"OK");
            if (!this.validEmail())
            {
                validation.RedefineValues(false, "No se ha introducido un correo");
            }
            return validation;
        }
        public override string ToString()
        {
            return this.emailUser;
        }
    }
}

