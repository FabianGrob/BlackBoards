﻿using System;
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
        public bool AddBlackBoard(BlackBoard aBoard) {
            bool valid = aBoard.isValid();
            bool notExists = !this.team.doesBlackBoardExists(aBoard);
            if (valid && notExists)
            {
                this.Team.Boards.Add(aBoard);
            }
            return valid && notExists;
        }
        public bool RemoveBlackBoard(BlackBoard aBoard) {
            bool exists = this.Team.Boards.Contains(aBoard);
            if (exists)
            {
                this.Team.Boards.Remove(aBoard);
            }
            return exists;
            
        }
        public bool ModifyBlackBoard(BlackBoard oldBoard, BlackBoard newBoard)
        {

            BlackBoardHandler handler = new BlackBoardHandler(oldBoard);
            bool modified = false;
            bool exists =this.Team.Boards.Contains(oldBoard);
            if (exists && newBoard.isValid())
            {
                handler.Modify(newBoard.Name,newBoard.Description,newBoard.Dimension);
                modified = true;
            }
            return modified;
        }
        public bool AddMember(User anUser) {
            bool added = false;
            bool userNotMember = !this.Team.Members.Contains(anUser);
            if (userNotMember)
            {
                this.Team.Members.Add(anUser);
                added = true;
            }

            return added;
        }
        public bool RemoveMember(User anUser) {
            bool removed = false;
            bool userMember = this.Team.Members.Contains(anUser);
            if (userMember)
            {
                this.Team.Members.Remove(anUser);
                removed = true;
            }
            return removed;
        }
        public bool IsUserInTeam(User anUser) {
            return this.Team.Members.Contains(anUser);
        }
        public bool HasAnyMember()
        {
            return !(this.Team.Members.Count == 0);
        }
    }
}