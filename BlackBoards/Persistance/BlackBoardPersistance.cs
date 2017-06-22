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
    public class BlackBoardPersistance
    {
        public void AddBlackBoard(BlackBoard blackBoard)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.teams.Attach(blackBoard.teamBelongs);
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
                    TeamPersistance teamContext = new TeamPersistance();
                    ItemPersistance itemContext = new ItemPersistance();
                    foreach (Item actualItem in aBlackBoard.itemList)
                    {
                        itemContext.Delete(actualItem);
                    }
                    Team teamWhichBelongs = teamContext.GetTeamByName(aBlackBoard.teamBelongs.Name);
                    teamWhichBelongs.boards.Remove(aBlackBoard);
                    aBlackBoard.teamBelongs = teamWhichBelongs;

                    dbContext.teams.Attach(teamWhichBelongs);
                    dbContext.Entry(teamWhichBelongs).State = EntityState.Modified;
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
                return new BlackBoard();
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
    }
}
