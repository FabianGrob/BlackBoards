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
    public class AdminPersistance : UserPersistance
    {
        public void AddAdmin(Admin anAdmin)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.users.Add(anAdmin);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceAdminException("Error en la base de datos: no se pudo registrar el administrador");
            }

        }
        public bool ExistsAdmin(User anUser) {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<User> users = dbContext.users.ToList<User>();
                    bool existsAdmin = users.Contains(anUser);

                    return (anUser is Admin && existsAdmin);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceAdminException("Error de base de datos: No se pudo determinar si el administrador existe.");
                return false;
            }
        }
        public void DeleteAdmin(Admin anAdmin)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    dbContext.users.Attach(anAdmin);
                    dbContext.Entry(anAdmin).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string error = ex.InnerException.ToString();
                throw new PersistanceAdminException("Error en la base de datos. Imposible vaciar valores del admin");
            }

        }
    }
}
