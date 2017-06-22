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
    public class TeamPersistance
    {
        public void AddTeam(Team team)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    foreach (User actualUser in team.Members)
                    {
                        dbContext.users.Attach(actualUser);
                    }
                    dbContext.teams.Add(team);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceTeamException("Error en la base de datos. Imposible agregar equipo");
            }

        }
        public bool Exists(Team aTeam)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Team> teams = dbContext.teams.ToList<Team>();
                    return teams.Contains(aTeam);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceTeamException("Error de base de datos: No se pudo determinar si el equipo existe.");
                return false;
            }
        }
        public void Delete(Team aTeam)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    dbContext.teams.Attach(aTeam);
                    dbContext.Entry(aTeam).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceTeamException("Error de base de datos: No se pudo eliminar el equipo.");
            }
        }

        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Team> teams = dbContext.teams.ToList();
                    foreach (Team actualTeam in teams)
                    {
                        Team toDelete = dbContext.teams.Find(actualTeam.IDTeam);
                        dbContext.teams.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceTeamException("Error en la base de datos. Imposible vaciar valores de variables");
            }
        }

        public int IDByName(string name)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Team> teams = dbContext.teams.ToList();
                    foreach (Team actualTeam in teams)
                    {
                        if (actualTeam.Name.Equals(name))
                        {
                            return actualTeam.IDTeam;
                        }
                    }
                    return -1;
                }
            }
            catch (Exception)
            {
                throw new PersistanceTeamException("Error en la base de datos. Imposible obtener id de equipo");
                return -1;
            }
        }

        public Team GetTeam(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Team lookUpTeam = dbContext.teams.Find(id);
                   /* Team returningTeam = new Team();
                    returningTeam.IDTeam = lookUpTeam.IDTeam;
                    returningTeam.members = this.GetMembersById(id);*/

                    return lookUpTeam;
                }
            }
            catch (Exception)
            {
                throw new PersistanceUserException("Error de base de datos: No se pudo obtener el equipo.");
                return new Team();
            }
        }

        public List<User> GetMembersById(int id)
        {
            using (BlackBoardsContext dbContext = new BlackBoardsContext())
            {
                List<Team> allTeams = dbContext.teams.ToList();
                foreach (Team actualTeam in allTeams)
                {
                    if (actualTeam.IDTeam == id)
                    {
                        return actualTeam.Members;
                    }
                }
                return new List<User>();
            }
        }
        public List<BlackBoard> GetBlackBoardsById(int id)
        {
            using (BlackBoardsContext dbContext = new BlackBoardsContext())
            {
                List<Team> allTeams = dbContext.teams.ToList();
                foreach (Team actualTeam in allTeams)
                {
                    if (actualTeam.IDTeam == id)
                    {
                        if (actualTeam.boards.Count > 0)
                        {
                            return actualTeam.boards;
                        }
                    }
                }
                return new List<BlackBoard>();
            }
        }
        public Team GetTeamByName(string name)
        {
            return this.GetTeam(this.IDByName(name));
        }
        public void ModifyTeam(Team aTeam, List<User> members, List<BlackBoard> boards)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    if (this.Exists(aTeam))
                    {

                        Team attachedTeam = this.GetTeam(aTeam.IDTeam);
                        attachedTeam.IDTeam = aTeam.IDTeam;
                        attachedTeam.Members = members;
                        attachedTeam.boards = boards;
                        attachedTeam.MaxUsers = aTeam.MaxUsers;
                        attachedTeam.Name = aTeam.Name;
                        
                        
                        dbContext.teams.Attach(attachedTeam);
                        dbContext.Entry(attachedTeam).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }

                }
            }
            catch (Exception e)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible Modificar el Elemento ");
            }
        }
        public Team TeamWhichContainsBB(BlackBoard aBlackBoard)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Team container = new Team();
                    container.Name = "InvalidTeam";
                    List<Team> teams = dbContext.teams.ToList<Team>();
                    foreach (Team actualTeam in teams)
                    {
                        if (this.GetBlackBoardsById(actualTeam.IDTeam).Contains(aBlackBoard))
                        {
                            container = actualTeam;
                        }

                    }
                    return container;

                }
            }
            catch (Exception)
            {
                throw new PersistanceItemException("Error en la base de datos. Imposible Modificar el Elemento ");
            }

            }
        }
    }


