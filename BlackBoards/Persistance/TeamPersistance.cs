using BlackBoards;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class TeamPersistance
    {
        public void AddTeam(Team team)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.teams.Add(team);
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
                string error = ex.InnerException.ToString();
                Console.WriteLine("Error de base de datos: No se pudo eliminar el cliente.");
            }

        }
        private User getUser(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    return dbContext.users.Find(id);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error de base de datos: No se pudo eliminar el cliente.");
                return new Admin();
            }

        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<User> users = dbContext.users.ToList();
                    foreach (User actualUser in users)
                    {
                        User toDelete = dbContext.users.Find(actualUser.ID);
                        dbContext.users.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en la base de datos. Imposible vaciar valores de variables");
            }
        }

        public int IDByEmail(string email)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<User> users = dbContext.users.ToList();
                    foreach (User actualUser in users)
                    {
                        if (actualUser.Email.Equals(email))
                        {
                            return actualUser.ID;
                        }
                    }
                    return -1;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error en la base de datos. Imposible vaciar valores de variables");
                return -1;
            }
        }
    }
}
