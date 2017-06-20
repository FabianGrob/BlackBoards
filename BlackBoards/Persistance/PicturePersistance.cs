using BlackBoards;
using Persistance.PersistanceException;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class PicturePersistance : ItemPersistance
    {
        public void ModifyTextBox(Picture aPicture)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    if (this.Exists(aPicture))
                    {
                        Picture anotherPicture = this.GetItem(aPicture.IDItem) as Picture;
                        anotherPicture.Dimension = aPicture.Dimension;
                        anotherPicture.Origin = aPicture.Origin;
                        anotherPicture.Description = aPicture.Description;
                        dbContext.items.Attach(anotherPicture);
                        dbContext.Entry(anotherPicture).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible Modificar el Elemento ");
            }
        }
    }
}
