using BlackBoards;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UserPersistance
    {
        public void AddUser(User user)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.users.Add(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
               // throw new DeviceException("Error en la base de datos. Imposible agregar dispositivo");
            }

        }
        public bool Exists(User anUser)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<User> users = dbContext.users.ToList<User>();
                    return users.Contains(anUser);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de base de datos: No se pudo determinar si el cliente existe.");
                return false;
            }
        }
        public void Delete(User anUser)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    dbContext.users.Attach(anUser);
                    dbContext.Entry(anUser).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de base de datos: No se pudo eliminar el cliente.");
            }

        }
            
           
    }
}
