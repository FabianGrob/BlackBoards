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
                throw new PersistanceUserException("Error en la base de datos. Imposible agregar usuario");
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
                throw new PersistanceUserException("Error de base de datos: No se pudo determinar si el usuario existe.");
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
                throw new PersistanceUserException("Error de base de datos: No se pudo eliminar el usuario.");
            }

        }
        private User GetUser(int id)
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
                throw new PersistanceUserException("Error de base de datos: No se pudo obtener el usuario.");
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
                throw new PersistanceUserException("Error en la base de datos. Imposible vaciar valores de usuario");
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
                throw new PersistanceUserException("Error en la base de datos. Imposible obtener id del usuario con email: " + email);
                return -1;
            }
        }
        public User GetUserByEmail(string lookUpEmail)
        {
            return this.GetUser(this.IDByEmail(lookUpEmail));
        }
        public void ModifyUser(string lookUpEmail, string name, string lastName, string newEmail, DateTime birthDate, string password)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    User anUser = new Collaborator();
                    anUser.Email = lookUpEmail;
                    if (this.Exists(anUser))
                    {
                        User anotherUser = this.GetUserByEmail(lookUpEmail);
                        anotherUser.Name = name;
                        anotherUser.Email = newEmail;
                        anotherUser.LastName = lastName;
                        anotherUser.BirthDate = birthDate;
                        anotherUser.passwordUser = password;
                        dbContext.users.Attach(anotherUser);
                        dbContext.Entry(anotherUser).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                throw new PersistanceUserException("Error en la base de datos. Imposible Modificar el usuario " + lookUpEmail);
            }
        }
    }
}
