using BlackBoards.Domain.BlackBoards;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class TeamHandler
    {
        private Team team;

        public TeamHandler(Team aTeam)
        {
            this.team = aTeam;
        }
        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
            }
        }
        public void SetBoards(List<BlackBoard> boards)
        {
            this.team.boards = new List<BlackBoard>();
            foreach (BlackBoard actualBlackBoard in boards)
            {
                this.team.boards.Add(actualBlackBoard);
            }
        }
        public ValidationReturn AddBlackBoard(BlackBoard aBoard, BlackBoardPersistance blackBoardContext, User creatorUser)
        {
            bool valid = aBoard.isValid();
            TeamPersistance teamContext = new TeamPersistance();
            UserPersistance userContext = new UserPersistance();
            List<BlackBoard> blackBoardsInTeam = teamContext.GetBlackBoardsById(team.IDTeam);
            bool notExists = !blackBoardsInTeam.Contains(aBoard);
            bool validBlackBoard = valid && notExists;
            aBoard.teamBelongs = teamContext.GetTeam(this.team.IDTeam);
            aBoard.CreatorUser = userContext.GetUserByEmail(creatorUser.Email);
            if (validBlackBoard)
            {
                blackBoardContext.AddBlackBoard(aBoard);
            }
            ValidationReturn validation = new ValidationReturn(validBlackBoard, "");
            return validation;
        }
        public ValidationReturn RemoveBlackBoard(BlackBoard aBoard, BlackBoardPersistance blackBoardContext)
        {
            TeamPersistance teamContext = new TeamPersistance();
            aBoard = blackBoardContext.GetBlackBoardByName(aBoard.Name);

            bool exists = blackBoardContext.Exists(aBoard);
            ValidationReturn validation = new ValidationReturn(exists, "No se ha podido eliminar el pizarron.");
            if (exists)
            {
                Team creatorTeam = teamContext.TeamWhichContainsBB(aBoard);
                Team creatorTeamToContext = new Team();
                creatorTeamToContext.IDTeam = creatorTeam.IDTeam;
                creatorTeamToContext.Name = creatorTeam.Name;
                creatorTeamToContext.IDTeam = creatorTeam.IDTeam;
                List<BlackBoard> bBoards = teamContext.GetBlackBoardsById(creatorTeam.IDTeam);
                List<User> teamMembers = teamContext.GetMembersById(creatorTeam.IDTeam);
                bBoards.Remove(aBoard);
                creatorTeam.boards = bBoards;
                teamContext.ModifyTeam(creatorTeam,teamMembers,bBoards);
                blackBoardContext.Delete(aBoard);
                validation.Message = "El pizarron se ha borrado con exito.";
            }
            return validation;
        }
        public bool ModifyBlackBoard(BlackBoard oldBoard, BlackBoard newBoard)
        {

            BlackBoardHandler handler = new BlackBoardHandler(oldBoard);
            bool modified = false;
            bool exists = this.Team.Boards.Contains(oldBoard);
            if (exists && newBoard.isValid())
            {
                handler.Modify(newBoard.Name, newBoard.Description, newBoard.Dimension);
                modified = true;
            }
            return modified;
        }
        public bool AddMember(User anUser)
        {
            bool added = false;
            bool userNotMember = !this.Team.Members.Contains(anUser);
            if (userNotMember)
            {
                this.Team.Members.Add(anUser);
                added = true;
            }
            return added;
        }
        public bool RemoveMember(User anUser)
        {
            bool removed = false;
            bool userMember = this.Team.Members.Contains(anUser);
            if (userMember)
            {
                this.Team.Members.Remove(anUser);
                removed = true;
            }
            return removed;
        }
        public bool IsUserInTeam(User anUser)
        {
            return this.Team.Members.Contains(anUser);
        }
        public bool HasAnyMember()
        {
            return !(this.Team.Members.Count == 0);
        }
    }
}
