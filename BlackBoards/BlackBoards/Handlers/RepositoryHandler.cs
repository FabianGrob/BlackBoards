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

        public bool CheckPassword(string lookUpEmail, string password)
        {
            User wantedUser = new Collaborator();
            wantedUser.Email = lookUpEmail;
            if (UserAlreadyExists(wantedUser))
            {
                User user = getSepcificUser(lookUpEmail);
                return user.Password.Equals(password);
            }
            else return false;    
        }
        public List<Comment> resolvedCommentsByUser(User anUser) {
            List<Comment> resolvedCommentsUser = new List<Comment>();
            List<Team> teamsUserMember = this.getUserTeams(anUser);

            List<Item> allItemsInTeamsUser = new List<Item>();
            foreach (Team actualTeam in teamsUserMember )
            {
                foreach (BlackBoard board in actualTeam.Boards)
                {
                    foreach (Item actualItem in board.ItemList)
                    {
                        foreach (Comment actualComment in actualItem.Comments)
                        {
                            if (actualComment.ResolvingUser.Equals(anUser))
                            {
                                resolvedCommentsUser.Add(actualComment);
                            }

                        }
                    }
                }
            }
            return resolvedCommentsUser;
        }
        public List<Comment> filterCreationDate(List<Comment> comments,DateTime creationDate) {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (creationDate.Equals(actualComment.CommentingDate))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;

        }
        public List<Comment> filterResolvingDate(List<Comment> comments, DateTime resolvingnDate)
        {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (resolvingnDate.Equals(actualComment.ResolvingDate))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;

        }
        public List<Comment> filterCommentingUser(List<Comment> comments, User commentingUser)
        {
            List<Comment> filtered = new List<Comment>();
            foreach (Comment actualComment in comments)
            {
                if (commentingUser.Equals(actualComment.CommentingUser))
                {
                    filtered.Add(actualComment);
                }
            }
            return filtered;
        }
        public void loadTestData() {
            if (!this.repository.TestData)
            {
                this.Repository.TestData = true;
                Admin adm = this.GetSpecificAdmin("Admin@Admin.com");
                AdminHandler admHandler = new AdminHandler(adm);
                admHandler.CreateCollaborator("Roberto", "Gonzales", "rGonzales@testEmail.com", DateTime.Today, "password", this.Repository);
                admHandler.CreateCollaborator("Rodrigo", "Rodriguez", "rodriguezRodrigo@testEmail.com", DateTime.Today, "password", this.Repository);
                admHandler.CreateCollaborator("Alberto", "Gomez", "AlbertoG@testEmail.com", DateTime.Today, "password", this.Repository);
                admHandler.CreateAdmin("Maria", "Fernandez", "mraFernandez@testEmail.com", DateTime.Today, "password", this.Repository);
                List<User> membersA = new List<User>();
                membersA.Add(this.getSepcificUser("rGonzales@testEmail.com"));
                membersA.Add(this.getSepcificUser("rodriguezRodrigo@testEmail.com"));
                membersA.Add(adm);
                admHandler.CreateTeam("Equipo A", "Equipo de prueba", 4, membersA, new List<BlackBoard>(), this.Repository);
                List<User> membersB = new List<User>();
                membersB.Add(this.getSepcificUser("rGonzales@testEmail.com"));
                Admin secondAdm = this.GetSpecificAdmin("mraFernandez@testEmail.com");
                membersB.Add(secondAdm);
                admHandler.CreateTeam("Equipo B", "Equipo de prueba", 3, membersB, new List<BlackBoard>(), this.Repository);
                UserHandler handlerAdm = new UserHandler(adm);
                UserHandler handlerSndAdm = new UserHandler(secondAdm);
                BlackBoard boardB = new BlackBoard("Trabajo Escritorio", "Es una pizarra de prueba", new Domain.Dimension(600, 500), new List<Item>(), secondAdm);
                handlerSndAdm.CreateBlackBoard(this.GetSpecificTeam("Equipo B"),boardB);
                BlackBoard boardA = new BlackBoard("Trabajo Empresa", "Es una pizarra de prueba", new Domain.Dimension(600, 500), new List<Item>(), adm);
                handlerAdm.CreateBlackBoard(this.GetSpecificTeam("Equipo A"), boardA);
            }
        }
    }
}
