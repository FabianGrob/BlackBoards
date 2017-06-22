using BlackBoards.Domain;
using Persistance;
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
        public ItemHandler(Item anItem)
        {
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
        public void MoveItem(Coordinate newCoordinate)
        {
            ItemPersistance itemContext = new ItemPersistance();
            this.item.Origin = newCoordinate;
            itemContext.ModifyItem(this.item);
        }
        public void ChangeDimension(Dimension newDimension)
        {
            ItemPersistance itemContext = new ItemPersistance();
            this.item.Dimension=newDimension;
            itemContext.ModifyItem(this.item);
        }
        public bool AddComment(Comment aComment)
        {
            return this.Item.AddNewComment(aComment);
        }
    }
}
