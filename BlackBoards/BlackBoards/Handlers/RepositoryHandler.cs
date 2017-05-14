using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
   public class RepositoryHandler
    {
        private Repository repository;

        public RepositoryHandler(Repository theRepository) {
            this.repository = theRepository;
        }
        public Repository Repository
        {
            get
            {
                return this.repository;
            }
            set
            {
                this.repository = value;
            }
        }

        public void AddUser(User anUser) {
            this.repository.UserList.Add(anUser);
        }
        public void AddAdmin(Admin anAdmin)
        {
            this.repository.AdministratorList.Add(anAdmin);
            this.AddUser(anAdmin);
        }
        public void AddTeam(Team aTeam) {
            this.repository.TeamList.Add(aTeam);
        }
        public bool UserAlreadyExists(User anUser) {
            return this.repository.UserList.Contains(anUser);
        }
        public bool TeamAlreadyExists(Team aTeam) {
            return this.repository.TeamList.Contains(aTeam);
        }
        public List<Team> getUserTeams(User user)
        {
            List<Team> userTeams = new List<Team>();
            foreach (Team actualTeam in Repository.TeamList)
            {
                TeamHandler handler = new TeamHandler(actualTeam);
                if (handler.IsUserInTeam(user))
                {
                    userTeams.Add(actualTeam);
                }
            }
            return userTeams;
        }
        public User getSepcificUser(string lookUpEmail) {
            User u = null;
            foreach (User user in this.Repository.UserList) {
                if (user.Email.Equals(lookUpEmail))
                {
                    u = user;
                }
            }
            return u;
        }
        public void ModifyUser(string lookUpEmail, string name, string lastName, string email, DateTime birthDate, string password) {
            User mod = this.getSepcificUser(lookUpEmail);
            mod.Name = name;
            mod.LastName = lastName;
            mod.Email = email;
            mod.BirthDate = birthDate;
            mod.Password = password;
            if (IsUserAnAdmin(lookUpEmail))
            {
               mod= this.GetSpecificAdmin(lookUpEmail);
                mod.Name = name;
                mod.LastName = lastName;
                mod.Email = email;
                mod.BirthDate = birthDate;
                mod.Password = password;
            }

        }
        public bool IsUserAnAdmin(string lookUpEmail) {
            bool isAnAdmin = false;
            foreach (Admin admin in this.Repository.AdministratorList) {
                if (admin.Email.Equals(lookUpEmail))
                {
                    isAnAdmin = true;
                }
            }
            return isAnAdmin;

        }
        private Admin GetSpecificAdmin(string lookUpEmail) {
            Admin admin = null;
            foreach (Admin actualAdmin in this.Repository.AdministratorList)
            {
                if (actualAdmin.Email.Equals(lookUpEmail))
                {
                    admin = actualAdmin;
                }
            }
            return admin;
        }
        private void DeleteUsersFromTeams(User delete)
        {
            foreach (Team actualTeam in this.Repository.TeamList)
            {
                if (actualTeam.Members.Contains(delete))
                {
                    actualTeam.Members.Remove(delete);
                } 
            }
        }
        public void DeleteUser(string email) {
            User delete = this.getSepcificUser(email);
            DeleteUsersFromTeams(delete);
            this.Repository.UserList.Remove(delete);
            if (this.IsUserAnAdmin(email))
            {
                Admin deleteAdmin = this.GetSpecificAdmin(email);
                this.Repository.AdministratorList.Remove(deleteAdmin);
            }
            CleanEmptyTeams();
        }
        public Team GetSpecificTeam(string name) {
            Team teamToReturn = null;
            foreach (Team actualTeam in this.Repository.TeamList) {
                if (actualTeam.Name.Equals(name))
                {
                    teamToReturn = actualTeam;
                }
            }
            return teamToReturn;
        }
        public bool TeamAlreadyExists(string name) {
            bool exists = false;
            foreach (Team actualTeam in this.Repository.TeamList) {
                if (actualTeam.Name.Equals(name))
                {
                    exists = true;
                }
              }
            return exists;
        }
        private void RemoveTeamFromRepository(Team teamToDelete)
        {
            this.Repository.TeamList.Remove(teamToDelete);
        }
        private void RemoveTeamsFromRepository(List<Team> teamsToDelete)
        {
            foreach (Team actualTeam in teamsToDelete)
            {
                RemoveTeamFromRepository(actualTeam);
            }
        }
        private void CleanEmptyTeams()
        {
            List<Team> teamsToDelete = new List<Team>();
            foreach (Team actualTeam in this.Repository.TeamList)
            {   
                TeamHandler actualTeamHandler = new TeamHandler(actualTeam);
                if (!actualTeamHandler.HasAnyMember())
                {
                    teamsToDelete.Add(actualTeam);
                }
            }
            RemoveTeamsFromRepository(teamsToDelete);
        }
    }
}
