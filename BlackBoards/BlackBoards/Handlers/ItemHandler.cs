using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Handlers
{
    public class ItemHandler
    {
        private Item item;
        public ItemHandler(Item anItem) {
            this.item = anItem;
        }
        public Item Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }
        public void MoveItem(Coordinate newCoordinate) {
            this.Item.Origin = newCoordinate;
        }
        public void ChangeDimension(Dimension newDimension) {
            this.Item.Dimension = newDimension;
        }
        public void AddComment(Comment aComment) {
            this.Item.Comments.Add(aComment);
        }
    }
}
