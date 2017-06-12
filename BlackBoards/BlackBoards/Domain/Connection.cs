using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class Connection
    {
        private Item from;
        private Item to;
        private DirectionType direction;
        private string name;
        private string description;

        public Connection(Item anItem, Item anotherItem, string aName, string aDescripton, DirectionType aDirection)
        {
            this.from = anItem;
            this.to = anotherItem;
            this.name = aName;
            this.description = aDescripton;
            this.direction = aDirection;
        }
        public Item From
        {
            get
            {
                return this.from;
            }
            set
            {
                this.from = value;
            }
        }
        public Item To
        {
            get
            {
                return this.to;
            }
            set
            {
                this.to = value;
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public DirectionType Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }
        public ValidationReturn isValid()
        {
            ValidationReturn valid = new ValidationReturn(true, "");
            if (this.From == null || this.To == null)
            {
                valid.Validation = false;
                valid.Message = "null";
                return valid;
            }
            if (this.To.Equals(this.From))
            {
                valid.Validation = false;
                valid.Message = "No se puede conectar el elemento con si mismo";
            }
            
            if (this.Name.Length < 3)
            {
                valid.Validation = false;
                valid.Message = "El nombre debe tener almenos 3 caracteres";
            }
            return valid;
        }
    }
}
