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
        public void AddPicture(Picture aPicture)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.blackBoards.Attach(aPicture.blackBoardBelongs);
                    dbContext.items.Add(aPicture);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible agregar el cuadro de texto");
            }

        }
        public void DeletePicture(Picture aPicture)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.items.Attach(aPicture);
                    dbContext.Entry(aPicture).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceItemException("Error de base de datos: No se pudo eliminar el cuadro de texto.");
            }
        }
        public void ModifyPicture(Picture aPicture)
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
                        anotherPicture.ImgPath = aPicture.ImgPath;
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
