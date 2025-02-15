﻿using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using BlackBoards.Handlers;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class UserHandler
    {
        private User user;
        public UserHandler(User anUser)
        {
            this.user = anUser;
        }
        public User User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }
        public bool CreateBlackBoard(Team aTeam, BlackBoard aBlackBoard)
        {
            TeamPersistance teamContext = new TeamPersistance();
            Team fullTeam = teamContext.GetTeamByName(aTeam.Name);
            TeamHandler teamHandler = new TeamHandler(fullTeam);
            aBlackBoard.creatorUser = this.User;
            bool userInTeam = teamHandler.IsUserInTeam(this.user);
            if (userInTeam)
            {
                BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
                ValidationReturn validation = teamHandler.AddBlackBoard(aBlackBoard, blackBoardContext, this.user);
                bool isABlackBoardValid = validation.Validation;
                return isABlackBoardValid;
            }
            return userInTeam;
        }
        public bool ModifyBlackBoard(Team aTeam, BlackBoard oldBlackBoard, BlackBoard newBlackBoard)
        {
            TeamHandler teamHandler = new TeamHandler(aTeam);
            bool userInTeam = teamHandler.IsUserInTeam(this.user);
            if (userInTeam)
            {
                bool isABlackBoardValid = teamHandler.ModifyBlackBoard(oldBlackBoard, newBlackBoard);
                return isABlackBoardValid;
            }
            return userInTeam;
        }
        public ValidationReturn RemoveBlackBoard(Team aTeam, BlackBoard aBlackBoard)
        {
            ValidationReturn wasRemoved = new ValidationReturn(false, "El usuario no es ni creador del pizarrón ni administrador.");
            bool isUserAdmin = this.User is Admin;
            if (aBlackBoard.creatorUser.Equals(this.user) || isUserAdmin)
            {
                TeamHandler teamHandler = new TeamHandler(aTeam);
                BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
                wasRemoved = teamHandler.RemoveBlackBoard(aBlackBoard, blackBoardContext);
            }
            return wasRemoved;
        }
        public ValidationReturn AddItemToBlackBoard(BlackBoard aBlackBoard, Item aItem)
        {
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler(aBlackBoard);
            return blackBoardHandler.AddItem(aItem);
        }
        public bool RemoveItemBlackBoard(BlackBoard aBlackBoard, Item aItem)
        {
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler(aBlackBoard);
            return blackBoardHandler.RemoveItem(aItem);
        }
        public bool ResizeItemBlackBoard(BlackBoard aBlackBoard, Item aItem, Dimension newDimension)
        {
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler(aBlackBoard);
            return blackBoardHandler.ReziseItem(aItem, newDimension);
        }
        public bool MoveItemBlackBoard(BlackBoard aBlackBoard, Item aItem, Coordinate newCoordinates)
        {
            BlackBoardHandler blackBoardHandler = new BlackBoardHandler(aBlackBoard);
            return blackBoardHandler.MoveItem(aItem, newCoordinates);
        }
        public ValidationReturn CreateNewComment(Item aItem, string newComment)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido crear el comentario");
            ItemHandler itemHandler = new ItemHandler(aItem);
            validation = itemHandler.AddComment(this.user, newComment);
            return validation;
        }
        public ValidationReturn ResolveComment(Comment aComment)
        {
            ValidationReturn validation = new ValidationReturn(false, "No se ha podido resolver el comentario");
            CommentHandler commentHandler = new CommentHandler(aComment);
            validation = commentHandler.ResolveComment(User);
            return validation;
        }
    }
}