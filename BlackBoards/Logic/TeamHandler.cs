﻿using BlackBoards.Domain.BlackBoards;
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

        public TeamHandler(Team aTeam) {
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
        public ValidationReturn AddBlackBoard(BlackBoard aBoard, BlackBoardPersistance blackBoardContext, User creatorUser) {
            bool valid = aBoard.isValid();
            bool notExists = !this.team.doesBlackBoardExists(aBoard);
            bool validBlackBoard = valid && notExists;
            aBoard.teamBelongs = this.team;
            aBoard.creatorUser = creatorUser;
            if (validBlackBoard)
            {
                blackBoardContext.AddBlackBoard(aBoard);
            }
            ValidationReturn validation = new ValidationReturn(validBlackBoard, "");
            return validation;
        }
        public ValidationReturn RemoveBlackBoard(BlackBoard aBoard, BlackBoardPersistance blackBoardContext) {
            TeamPersistance teamContext = new TeamPersistance();
            bool exists = blackBoardContext.Exists(aBoard);
            ValidationReturn validation = new ValidationReturn(exists,"No se ha podido eliminar el pizarron.");
            if (exists)
            {
               /* Team removedBB = teamContext.GetTeamByName(this.Team.Name);
                removedBB.boards.Remove(aBoard);
                teamContext.ModifyTeam(removedBB);*/
                blackBoardContext.Delete(aBoard);
                validation.Message = "El pizarron se ha borrado con exito.";
            }
            return validation;
        }
        public bool ModifyBlackBoard(BlackBoard oldBoard, BlackBoard newBoard)
        {

            BlackBoardHandler handler = new BlackBoardHandler(oldBoard);
            bool modified = false;
            bool exists =this.Team.boards.Contains(oldBoard);
            if (exists && newBoard.isValid())
            {
                handler.Modify(newBoard.Name,newBoard.Description,newBoard.Dimension);
                modified = true;
            }
            return modified;
        }
        public bool AddMember(User anUser) {
            bool added = false;
            bool userNotMember = !this.Team.members.Contains(anUser);
            if (userNotMember)
            {
                this.Team.members.Add(anUser);
                added = true;
            }
            return added;
        }
        public bool RemoveMember(User anUser) {
            bool removed = false;
            bool userMember = this.Team.members.Contains(anUser);
            if (userMember)
            {
                this.Team.members.Remove(anUser);
                removed = true;
            }
            return removed;
        }
        public bool IsUserInTeam(User anUser) {
            return this.Team.members.Contains(anUser);
        }
        public bool HasAnyMember()
        {
            return !(this.Team.members.Count == 0);
        }
    }
}
