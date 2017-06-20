using BlackBoards;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class AdminPersistance : UserPersistance
    {
        public void AddAdmin(Admin anAdmin)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.admins.Add(anAdmin);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

        }
        public bool ExistsAdmin(User anUser) {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<User> admins = dbContext.admins.ToList<User>();
                    return admins.Contains(anUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de base de datos: No se pudo determinar si el administrador existe.");
                return false;
            }
        }
        public void DeleteAdmin(Admin anAdmin)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    dbContext.admins.Attach(anAdmin);
                    dbContext.Entry(anAdmin).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
                Console.WriteLine("Error de base de datos: No se pudo eliminar el cliente.");
            }

        }
    }
}
