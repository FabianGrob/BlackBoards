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
    public class ItemPersistance
    {
        public void AddItem(Item anItem)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.blackBoards.Attach(anItem.blackBoardBelongs);
                    dbContext.items.Add(anItem);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible agregar el Elemento");
            }
        }
        public void Delete(Item anItem)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.items.Attach(anItem);
                    dbContext.Entry(anItem).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceItemException("Error de base de datos: No se pudo eliminar el Elemento.");
            }
        }




        public void ModifyItem(Item anItem)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    if (this.Exists(anItem))
                    {
                        Item anotherItem = this.GetItem(anItem.IDItem);
                        anotherItem.Dimension = anItem.Dimension;
                        anotherItem.Origin = anItem.Origin;
                        dbContext.items.Attach(anotherItem);
                        dbContext.Entry(anotherItem).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible Modificar el Elemento ");
            }
        }
        public Item GetItem(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    return dbContext.items.Include(t => t.comments).Include(t => t.blackBoardBelongs).FirstOrDefault(t => t.IDItem == id);
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error de base de datos: No se pudo obtener el Elemento.");

            }
        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Item> items = dbContext.items.ToList();
                    foreach (Item actualItem in items)
                    {
                        Item toDelete = dbContext.items.Find(actualItem.IDItem);
                        dbContext.items.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible vaciar valores de elementos");
            }
        }
        public bool Exists(Item anItem)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Item> items = dbContext.items.ToList<Item>();
                    return items.Contains(anItem);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceItemException("Error de base de datos: No se pudo determinar si el elemento existe.");
            }
        }
    }
}
