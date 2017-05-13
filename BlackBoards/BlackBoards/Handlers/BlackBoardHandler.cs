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

        public void CreateBlackBoard(Team aTeam, string aName, string aDescription, Dimension aDimension)
        {
            this.blackBoard.Description = aDescription;
            this.blackBoard.Team = aTeam;
            this.blackBoard.Name = aName;
            this.blackBoard.Dimension = aDimension;
        }

        public void Modify(Team aTeam, string aName, string aDescription, Dimension aDimension)
        {
            this.blackBoard.Description = aDescription;
            this.blackBoard.Team = aTeam;
            this.blackBoard.Name = aName;
            this.blackBoard.Dimension = aDimension;
        }

        public void AddItem(Item aItem)
        {
            bool itemFitsInBlackBoard = ItemOutOfBands(aItem,aItem.Origin);
            if (itemFitsInBlackBoard)
            {
                this.blackBoard.ItemList.Add(aItem);
            }
        }

        public void RemoveItem(Item aItem)
        {
            this.blackBoard.ItemList.Remove(aItem);
        }

        public void MoveItem(Item aItem, Coordinate coordinates)
        {
            bool itemFitsInBlackBoard = ItemOutOfBands(aItem, coordinates);
            if (itemFitsInBlackBoard)
            {
                this.blackBoard.ItemList.Remove(aItem);
                aItem.Origin = coordinates;
                this.blackBoard.ItemList.Add(aItem);
            }

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
