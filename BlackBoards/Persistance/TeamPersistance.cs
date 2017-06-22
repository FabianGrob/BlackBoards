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
                    foreach (User actualUser in team.members)
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
        public Team GetTeam(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Team completeTeam = dbContext.teams.Include(t => t.boards).Include(t => t.members).Include(t => t.scoresOfUsers).Include(t => t.EstablishedScoreTeam).FirstOrDefault(t => t.IDTeam == id);
                    return completeTeam;
                }
            }
            catch (Exception)
            {
                throw new PersistanceTeamException("Error de base de datos: No se pudo obtener el equipo.");
                return new Team();
            }

        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Team> users = dbContext.teams.ToList();
                    foreach (Team actualTeam in users)
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
        public List<User> GetMembersById(int id)
        {
            using (BlackBoardsContext dbContext = new BlackBoardsContext())
            {
                List<Team> allTeams = dbContext.teams.ToList();
                foreach (Team actualTeam in allTeams)
                {
                    if (actualTeam.IDTeam == id)
                    {
                        return actualTeam.members;
                    }
                }
                return new List<User>();
            }
        }
        public Team GetTeamByName(string name)
        {
            return this.GetTeam(this.IDByName(name));
        }
        public void updateMembers(Team theTeam, List<User> updatedMembers)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Team anotherTeam = dbContext.teams.Where(t => t.Name == theTeam.Name).Include(u => u.members).FirstOrDefault();
                    anotherTeam.members = new List<User>();
                    foreach (User actualUser in updatedMembers)
                    {
                        User userFromDB = dbContext.users.Where(t => t.ID == actualUser.ID).Include(u => u.belongInteams).FirstOrDefault();
                        anotherTeam.members.Add(userFromDB);
                    }
                    dbContext.Entry(anotherTeam).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new PersistanceUserException("Error en la base de datos. Imposible Modificar el Equipo ");
            }
        }
        public void ModifyTeam(Team aTeam, Team oldTeam)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    if (this.Exists(oldTeam))
                    {
                        Team anotherTeam = dbContext.teams.Where(t => t.Name == oldTeam.Name).Include(u => u.members).FirstOrDefault();
                        anotherTeam.Name = aTeam.Name;
                        anotherTeam.Description = aTeam.Description;
                        anotherTeam.MaxUsers = aTeam.MaxUsers;
                        dbContext.teams.Attach(anotherTeam);
                        dbContext.Entry(anotherTeam).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        updateMembers(anotherTeam,aTeam.members);
                    }
                }
            }
            catch (Exception e)
            {
                throw new PersistanceUserException("Error en la base de datos. Imposible Modificar el Equipo ");
            }
        }
    }
}
