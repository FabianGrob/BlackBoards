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
    public class TextBoxPersistance : ItemPersistance
    {
        public void AddTextBox(TextBox aTextBox)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.blackBoards.Attach(aTextBox.blackBoardBelongs);
                    dbContext.items.Add(aTextBox);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible agregar el cuadro de texto");
            }

        }
        public void DeleteTextBox(TextBox aTextBox)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    dbContext.items.Attach(aTextBox);
                    dbContext.Entry(aTextBox).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceItemException("Error de base de datos: No se pudo eliminar el cuadro de texto.");
            }

        }
        public void ModifyTextBox(TextBox aTextBox)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    if (this.Exists(aTextBox))
                    {
                        TextBox anotherTextBox = this.GetItem(aTextBox.IDItem) as TextBox;
                        anotherTextBox.Dimension = aTextBox.Dimension;
                        anotherTextBox.Origin = aTextBox.Origin;
                        anotherTextBox.Content = aTextBox.Content;
                        anotherTextBox.Font = aTextBox.Font;
                        anotherTextBox.FontSize = aTextBox.FontSize;
                        dbContext.items.Attach(anotherTextBox);
                        dbContext.Entry(anotherTextBox).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible Modificar el cuadro de texto ");
            }
        }
    }
}
