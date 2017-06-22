using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBoards.Domain;
using BlackBoards.Domain.BlackBoards;
using Persistance;

namespace BlackBoards.Handlers
{
    public class BlackBoardHandler
    {
        private BlackBoard blackBoard;
        public BlackBoardHandler()
        {
            this.blackBoard = new BlackBoard();
        }
        public BlackBoardHandler(BlackBoard aBoard)
        {
            this.blackBoard = aBoard;
        }
        public BlackBoard BlackBoard
        {
            get
            {
                return this.blackBoard;
            }
            set
            {
                this.blackBoard = value;
            }
        }
        public void CreateBlackBoard(string aName, string aDescription, Dimension aDimension)
        {
            this.blackBoard.Description = aDescription;
            this.blackBoard.Name = aName;
            this.blackBoard.Dimension = aDimension;
        }
        private bool CanModifyTheDimension(Dimension newDimension)
        {
            BlackBoard fakeBlackBoard = new BlackBoard();
            fakeBlackBoard.Dimension = BlackBoard.Dimension;
            bool canModify = true;
            foreach (Item actualItem in BlackBoard.itemList)
            {
                BlackBoardHandler fakeHandler = new BlackBoardHandler(fakeBlackBoard);
                if (fakeHandler.ItemOutOfBands(actualItem, actualItem.Origin).Validation)
                {
                    canModify = false;
                }
            }
            return canModify;
        }

        public bool Modify(string oldName,string aName, string aDescription, Dimension aDimension)
        {
            if (CanModifyTheDimension(aDimension))
            {
                BlackBoardPersistance blackBoardContext = new BlackBoardPersistance();
                blackBoardContext.ModifyBlackBoard(oldName, aName, aDescription, aDimension);
                return true;
            }
            return false;
        }
        public ValidationReturn AddItem(Item anItem)
        {
            ValidationReturn itemFitsInBlackBoard = ItemOutOfBands(anItem, anItem.Origin);
            if (itemFitsInBlackBoard.Validation)
            {
                ItemPersistance itemContext = new ItemPersistance();
                itemContext.AddItem(anItem);
                itemFitsInBlackBoard.Message = "El elemento ha sido añadido";
            }
            return itemFitsInBlackBoard;
        }

        public bool RemoveItem(Item aItem)
        {
            bool existsItemInList = blackBoard.itemList.Contains(aItem);
            if (existsItemInList)
            {
                this.blackBoard.itemList.Remove(aItem);

            }
            return existsItemInList;
        }

        public bool MoveItem(Item aItem, Coordinate coordinates)
        {
            bool itemFitsInBlackBoard = ItemOutOfBands(aItem, coordinates).Validation;
            if (itemFitsInBlackBoard)
            {
                ItemHandler itemHandler = new ItemHandler(aItem);
                itemHandler.MoveItem(coordinates);
            }
            return itemFitsInBlackBoard;
        }
        public bool ReziseItem(Item aItem, Dimension dimension)
        {
            bool validSize = aItem.Dimension.Height > 0 && aItem.Dimension.Width > 0;
            bool itemFitsInBlackBoard = ItemSizeFitsInBlackBoard(aItem, dimension);
            if (itemFitsInBlackBoard && validSize)
            {
                ItemHandler itemHandler = new ItemHandler(aItem);
                itemHandler.ChangeDimension(dimension);
            }
            return itemFitsInBlackBoard && validSize;

        }
        private bool ItemSizeFitsInBlackBoard(Item aItem, Dimension dimension)
        {
            int maxXAxisValue = aItem.Origin.XAxis + dimension.Width;
            int maxYAxisValue = aItem.Origin.YAxis + dimension.Height;
            bool itemSizeFitsInBlackBoard = true;
            if (maxXAxisValue > blackBoard.Dimension.Height || maxYAxisValue > blackBoard.Dimension.Width)
            {
                itemSizeFitsInBlackBoard = false;
            }
            return itemSizeFitsInBlackBoard;
        }
        private ValidationReturn ItemOutOfBands(Item aItem, Coordinate coordinates)
        {
            int maxXAxisValue = coordinates.XAxis + aItem.Dimension.Width;
            int maxYAxisValue = coordinates.YAxis + aItem.Dimension.Height;
            ValidationReturn itemFitsInBlackBoard = new ValidationReturn(true, "El item se puede agregar al pizarron.");
            if (maxXAxisValue > blackBoard.Dimension.Height || maxYAxisValue > blackBoard.Dimension.Width)
            {
                itemFitsInBlackBoard.RedefineValues(false, "El item no cabe en el pizarron."); ;
            }
            return itemFitsInBlackBoard;
        }
    }
}
