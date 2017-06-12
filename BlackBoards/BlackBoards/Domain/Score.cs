using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class Score
    {
        private int createBlackBoard;
        private int deleteBlackBoard;
        private int addItem;
        private int addComment;
        private int solveComment;
        public Score()
        {
            this.createBlackBoard = 0;
            this.deleteBlackBoard = 0;
            this.addItem = 0;
            this.addComment = 0;
            this.solveComment = 0;
        }
        public Score(int createBlackBoard, int deleteBlackBoard, int addItem, int addComment, int solveComment)
        {
            this.createBlackBoard = createBlackBoard;
            this.deleteBlackBoard = deleteBlackBoard;
            this.addItem = addItem;
            this.addComment = addComment;
            this.solveComment = solveComment;
        }
        public int CreateBlackBoard
        {
            get
            {
                return this.createBlackBoard;
            }
            set
            {
                this.createBlackBoard = value;
            }
        }
        public int DeleteBlackBoard
        {
            get
            {
                return this.deleteBlackBoard;
            }
            set
            {
                this.deleteBlackBoard = value;
            }
        }
        public int AddItem
        {
            get
            {
                return this.addItem;
            }
            set
            {
                this.addItem = value;
            }
        }
        public int AddComment
        {
            get
            {
                return this.addComment;
            }
            set
            {
                this.addComment = value;
            }
        }
        public int SolveComment
        {
            get
            {
                return this.solveComment;
            }
            set
            {
                this.solveComment = value;
            }
        }

        private bool ValidCreateBlackBoard()
        {
            return this.createBlackBoard < 0;
        }
        private bool ValidDeleteBlackBoard()
        {
            return this.deleteBlackBoard < 0;
        }
        private bool ValidAddItem()
        {
            return this.addItem < 0;
        }
        private bool ValidAddComment()
        {
            return this.addComment < 0;
        }
        private bool ValidSolveComment()
        {
            return this.solveComment < 0;
        }
        public ValidationReturn IsValid()
        {
            ValidationReturn validation = new ValidationReturn(true, "OK");
            if (this.ValidCreateBlackBoard())
            {
                validation.Validation = false;
                validation.Message = ("La puntuacion de crear pizarron no puede ser menor a 0");
            }
            if (this.ValidDeleteBlackBoard())
            {
                validation.Validation = false;
                validation.Message = ("La puntuacion de borrar pizarron no puede ser menor a 0");
            }
            if (this.ValidAddItem())
            {
                validation.Validation = false;
                validation.Message = ("La puntuacion de añadir un item no puede ser menor a 0");
            }
            if (this.ValidAddComment())
            {
                validation.Validation = false;
                validation.Message = ("La puntuacion de añadir un comentario no puede ser menor a 0");
            }
            if (this.ValidSolveComment())
            {
                validation.Validation = false;
                validation.Message = ("La puntuacion de resolver un comentario no puede ser menor a 0");
            }
            return validation;
        }
        public override bool Equals(object anotherScore)
        {
            if (anotherScore == null)
            {
                return false;
            }
            Score otherScore = anotherScore as Score;
            if ((System.Object)otherScore == null)
            {
                return false;
            }
            bool createBlackBoardBool = (this.createBlackBoard == otherScore.CreateBlackBoard);
            bool deleteBlackBoardBool = (this.deleteBlackBoard == otherScore.DeleteBlackBoard);
            bool addItemBool = (this.addItem == otherScore.AddItem);
            bool addCommentBool = (this.addComment == otherScore.AddComment);
            bool solveCommentBool = (this.solveComment == otherScore.SolveComment);
            return (createBlackBoardBool && deleteBlackBoardBool && addItemBool && addCommentBool && solveCommentBool);
        }
    }
}
