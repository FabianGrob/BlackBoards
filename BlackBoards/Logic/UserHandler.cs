using BlackBoards.Domain;
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
            TeamHandler teamHandler = new TeamHandler(aTeam);
            aBlackBoard.CreatorUser = this.User;
            
            bool userInTeam = teamHandler.IsUserInTeam(this.user);
            if (userInTeam)
            {
                BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
                ValidationReturn validation = teamHandler.AddBlackBoard(aBlackBoard,blackBoardContext);
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
        public bool RemoveBlackBoard(Team aTeam, BlackBoard aBlackBoard, Repository aRepository)
        {

            RepositoryHandler repositoryHandler = new RepositoryHandler(aRepository);
            bool userAdmin = repositoryHandler.IsUserAnAdmin(User.Email);
            if (aBlackBoard.CreatorUser.Equals(this.user) || userAdmin)
            {
                TeamHandler teamHandler = new TeamHandler(aTeam);
                BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
                ValidationReturn wasRemoved = teamHandler.RemoveBlackBoard(aBlackBoard,blackBoardContext);
                return wasRemoved.Validation;
            }
            return false;
        }
        public bool AddItemToBlackBoard(BlackBoard aBlackBoard, Item aItem)
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
        public bool CreateNewComment(Item aItem, string newComment)
        {
            CommentHandler commentHandler = new CommentHandler();
            commentHandler.CreateComment(User, newComment);
            ItemHandler itemHandler = new ItemHandler(aItem);
            return itemHandler.AddComment(commentHandler.Comment);
        }
        public bool ResolveComment(Comment aComment)
        {
            CommentHandler commentHandler = new CommentHandler(aComment);
            return commentHandler.ResolveComment(User);
        }
    }
}