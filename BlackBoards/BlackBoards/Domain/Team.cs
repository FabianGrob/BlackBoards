using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTeam { get; set; }
        private string name;
        private string description;
        private DateTime creationDate;
        private int maxUsers;
        public virtual List<User> members { set; get; }
        public virtual List<BlackBoard> boards { set; get; }
        public virtual EstablishedScoreTeam establishedScore { set; get; }
        public virtual List<ScoreUserInTeam> scoresOfUsers { get; set; }
        public Team()
        {
            this.name = "Default name";
            this.creationDate = DateTime.Today;
            this.description = "Default description";
            this.maxUsers = 10;
            this.members = new List<User>();
            this.boards = new List<BlackBoard>();
        }
        public Team(string aName, DateTime aCreationDate, string aDescription, int maximumUsers, List<User> someMembers, List<BlackBoard> someBoards)
        {
            this.name = aName;
            this.creationDate = aCreationDate;
            this.description = aDescription;
            this.maxUsers = maximumUsers;
            this.members = someMembers;
            this.boards = someBoards;
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
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return this.creationDate;
            }
            set
            {
                this.creationDate = value;
            }
        }
        public int MaxUsers
        {
            get
            {
                return this.maxUsers;
            }
            set
            {
                this.maxUsers = value;
            }
        }
        public List<User> Members
        {
            get
            {
                return this.members;
            }
            set
            {
                this.members = value;
            }
        }
        public List<BlackBoard> Boards
        {
            get
            {
                return this.boards;
            }
            set
            {
                this.boards = value;
            }
        }
        private bool EmptyBlackBoard()
        {
            return (this.boards != null || this.boards.Count > 0);
        }
        public bool doesBlackBoardExists(BlackBoard aBoard)
        {
            if (this.EmptyBlackBoard())
            {
                return this.boards.Contains(aBoard);
            }
            return false;
        }
        public BlackBoard getSpecificBlackBoard(BlackBoard aBoard)
        {
            BlackBoard returningBoard = null;
            foreach (BlackBoard board in this.boards)
            {
                if (board.Equals(aBoard))
                {
                    returningBoard = aBoard;
                }
            }
            return returningBoard;
        }
        public override bool Equals(object aTeam)
        {
            if (aTeam == null)
            {
                return false;
            }
            Team anotherTeam = aTeam as Team;
            if ((System.Object)anotherTeam == null)
            {
                return false;
            }
            return this.Name.Equals(anotherTeam.Name);
        }
        private bool validName()
        {
            return (this.name.Length >= 0);
        }
        private bool validDescription()
        {
            return (this.description.Length >= 0);
        }
        private bool validMaxUsers()
        {
            return (this.maxUsers > 0);
        }
        private bool validMembers()
        {
            return (this.members.Count > 0);
        }
        private bool validCantOfMembers()
        {
            return (this.members.Count <= this.maxUsers);
        }
        public ValidationReturn IsValid()
        {
            ValidationReturn validation = new ValidationReturn(true, "OK");
            if (!this.validName())
            {
                validation.RedefineValues(false, "El nombre ingresado es vacio.");
            }
            if (!this.validDescription())
            {
                validation.RedefineValues(false, "La descripcion ingresada es vacia.");
            }
            if (!this.validMaxUsers())
            {
                validation.RedefineValues(false, "La cantidad maxima de usuarios no puede ser menor a 1.");
            }
            if (!this.validMembers())
            {
                validation.RedefineValues(false, "No se seleccionaron usuarios.");
            }
            if (!this.validCantOfMembers())
            {
                validation.RedefineValues(false, "El equipo alcanzo la cantidad maxima de usuarios.");
            }
            return validation;
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
