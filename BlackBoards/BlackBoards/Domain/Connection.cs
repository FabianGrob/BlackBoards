using BlackBoards.Domain.BlackBoards;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Domain
{
    public class Connection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDConnection { get; set; }
        [Column("Id_From")]
        public virtual Item from { get; set; }
        [Column("Id_To")]
        public virtual Item to { get; set; }
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
        private bool IsAnyItemNull()
        {
            return this.from == null || this.to == null;
        }
        private bool ItemsAreTheSame()
        {
            return this.to.Equals(this.from);
        }
        private bool IsNameShort()
        {
            return this.Name.Length < 3;
        }
        public ValidationReturn isValid()
        {
            ValidationReturn valid = new ValidationReturn(true, "");
            if (IsAnyItemNull())
            {
                valid.RedefineValues(false, "Se debe seleccionar dos Items");
                return valid;
            }
            if (ItemsAreTheSame())
            {
                valid.RedefineValues(false, "No se puede conectar el elemento con si mismo");
            }
            if (IsNameShort())
            {
                valid.RedefineValues(false, "El nombre debe tener almenos 3 caracteres");
            }
            return valid;
        }
    }
}
