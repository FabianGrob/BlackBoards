using BlackBoards;
using BlackBoards.Domain;
using Persistance.PersistanceException;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class BlackBoardPersistance
    {
        public void AddBlackBoard(BlackBoard blackBoard, User creatorUser)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    UserPersistance userContext = new UserPersistance();
                    dbContext.teams.Attach(blackBoard.teamBelongs);
                    User creator = dbContext.users.Where(u => u.ID == creatorUser.ID).Include(u => u.belongInteams).FirstOrDefault();
                    blackBoard.creatorUser = creator;
                    dbContext.blackBoards.Add(blackBoard);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new PersistanceBlackBoardException("Error en la base de datos. Imposible agregar pizarron");
            }
        }
        public bool Exists(BlackBoard aBlackBoard)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<BlackBoard> blackBoard = dbContext.blackBoards.ToList<BlackBoard>();
                    return blackBoard.Contains(aBlackBoard);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceBlackBoardException("Error de base de datos: No se pudo determinar si el pizarron existe.");
                return false;
            }
        }
        public void Delete(BlackBoard aBlackBoard)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    ItemPersistance itemContext = new ItemPersistance();
                    foreach (Item actualItem in aBlackBoard.itemList)
                    {
                        itemContext.Delete(actualItem);
                    }
                    dbContext.blackBoards.Attach(aBlackBoard);
                    dbContext.Entry(aBlackBoard).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceBlackBoardException("Error de base de datos: No se pudo eliminar el pizarron.");
            }
        }
        public BlackBoard GetBlackBoard(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    BlackBoard completeBlackBoard = dbContext.blackBoards.Include(bb => bb.creatorUser).Include(bb => bb.itemList).Include(bb => bb.teamBelongs).FirstOrDefault(bb => bb.IDBlackBoard == id);
                    return completeBlackBoard;
                }
            }
            catch (Exception)
            {
                throw new PersistanceBlackBoardException("Error de base de datos: No se pudo obtener el pizarron.");
            }

        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<BlackBoard> blackBoards = dbContext.blackBoards.ToList();
                    foreach (BlackBoard actualBlackBoard in blackBoards)
                    {
                        BlackBoard toDelete = dbContext.blackBoards.Find(actualBlackBoard.IDBlackBoard);
                        dbContext.blackBoards.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceBlackBoardException("Error en la base de datos. Imposible vaciar valores de pizarron");
            }
        }

        public int IDByBlackBoard(string name)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<BlackBoard> blackBoards = dbContext.blackBoards.ToList();
                    foreach (BlackBoard actualBlackBoard in blackBoards)
                    {
                        if (actualBlackBoard.Name.Equals(name))
                        {
                            return actualBlackBoard.IDBlackBoard;
                        }
                    }
                    return -1;
                }
            }
            catch (Exception)
            {
                throw new PersistanceBlackBoardException("Error en la base de datos. Imposible obtener id del pizarron");
                return -1;
            }
        }
        public BlackBoard GetBlackBoardByName(string name)
        {
            return this.GetBlackBoard(this.IDByBlackBoard(name));
        }
        public void ModifyBlackBoard(string oldName, string name, string description, Dimension aDimension)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    BlackBoard oldBoard = new BlackBoard();
                    oldBoard.Name = oldName;
                    if (this.Exists(oldBoard))
                    {
                        BlackBoard anotherBoard = this.GetBlackBoardByName(oldBoard.Name);
                        anotherBoard.Name = name;
                        anotherBoard.Description = description;
                        anotherBoard.Dimension = aDimension;
                        dbContext.blackBoards.Attach(anotherBoard);
                        dbContext.Entry(anotherBoard).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new PersistanceUserException("Error en la base de datos. Imposible Modificar el pizazrrón");
            }
        }
        

    }
}
