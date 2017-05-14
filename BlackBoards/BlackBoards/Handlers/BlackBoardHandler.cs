using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBoards.Domain;

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

        public void Modify(string aName, string aDescription, Dimension aDimension)
        {
            this.blackBoard.Description = aDescription;
            this.blackBoard.Name = aName;
            this.blackBoard.Dimension = aDimension;
        }

        public bool AddItem(Item aItem)
        {
            bool itemFitsInBlackBoard = ItemOutOfBands(aItem,aItem.Origin);
            if (itemFitsInBlackBoard)
            {
                this.blackBoard.ItemList.Add(aItem);
            }
            return itemFitsInBlackBoard;
        }

        public bool RemoveItem(Item aItem)
        {
            bool existsItemInList = blackBoard.ItemList.Contains(aItem);
            if (existsItemInList)
            {
                this.blackBoard.ItemList.Remove(aItem);

            }
            return existsItemInList;
        }

        public bool MoveItem(Item aItem, Coordinate coordinates)
        {
            bool itemFitsInBlackBoard = ItemOutOfBands(aItem, coordinates);
            if (itemFitsInBlackBoard)
            {
                ItemHandler itemHandler = new ItemHandler(aItem);
                itemHandler.MoveItem(coordinates);
            }
            return itemFitsInBlackBoard;
        }
        public bool ReziseItem(Item aItem, Dimension dimension)
        {
            bool itemFitsInBlackBoard = ItemSizeFitsInBlackBoard(aItem, dimension);
            if (itemFitsInBlackBoard)
            {
                ItemHandler itemHandler = new ItemHandler(aItem);
                itemHandler.ChangeDimension(dimension);
            }
            return itemFitsInBlackBoard;

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
        private bool ItemOutOfBands(Item aItem, Coordinate coordinates)
        {
            int maxXAxisValue = coordinates.XAxis + aItem.Dimension.Width;
            int maxYAxisValue = coordinates.YAxis + aItem.Dimension.Height;
            bool itemFitsInBlackBoard = true;
            if (maxXAxisValue > blackBoard.Dimension.Height || maxYAxisValue > blackBoard.Dimension.Width)
            {
                itemFitsInBlackBoard = false;
            }
            return itemFitsInBlackBoard;
        }
    }
}
