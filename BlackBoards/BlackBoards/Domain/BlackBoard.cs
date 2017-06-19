using BlackBoards.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards
{
    public class BlackBoard
    {
        public int ID { get; set; }
        private List<Item> itemList;
        private string name;
        private string description;
        private Dimension dimension;
        private User creatorUser;
        private DateTime creationDate;
        private DateTime lastModificationDate;
        public virtual Team team { get; set; }

        public BlackBoard()
        {
            this.name = "Default name";
            this.description = "Default description";
            this.dimension = new Dimension(350, 350);
            this.itemList = new List<Item>();
            this.creatorUser = new Admin();
            this.creationDate = DateTime.Today;
            this.lastModificationDate = this.creationDate;
        }
        public BlackBoard(string aName, string aDescription, Dimension aDimension, List<Item> itemList, User anUser)
        {
            this.name = aName;
            this.description = aDescription;
            this.dimension = aDimension;
            this.itemList = itemList;
            this.creatorUser = anUser;
            this.creationDate = DateTime.Today;
            this.lastModificationDate = this.creationDate;
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
        public Dimension Dimension
        {
            get
            {
                return this.dimension;
            }
            set
            {
                this.dimension = value;
            }
        }

        public List<Item> ItemList
        {
            get
            {
                return this.itemList;
            }
            set
            {
                this.itemList = value;
            }
        }
        public User CreatorUser
        {
            get
            {
                return this.creatorUser;
            }
            set
            {
                this.creatorUser = value;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return this.creationDate;
            }
            set
            {
                this.creationDate = value;
            }
        }
        public DateTime LastModificationDate
        {
            get
            {
                return this.lastModificationDate;
            }
            set
            {
                this.lastModificationDate = value;
            }
        }
        public bool isValid()
        {
            bool topRestriction = this.Dimension.Height <= 500 && this.Dimension.Width <= 750;
            return topRestriction && this.Dimension.Height > 50 && this.Dimension.Width > 50;
        }
        public override bool Equals(object aBlackBoard)
        {
            if (aBlackBoard == null)
            {
                return false;
            }
            BlackBoard anotherBlackBoard = aBlackBoard as BlackBoard;
            if ((System.Object)anotherBlackBoard == null)
            {
                return false;
            }
            return this.Name.Equals(anotherBlackBoard.Name);
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
