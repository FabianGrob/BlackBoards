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
    public class EstablishedScoreTeamPersistance
    {
        public void AddComment(Score scores, Team team)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    EstablishedScoreTeam toAdd = new EstablishedScoreTeam();
                    Team teamScores = dbContext.teams.Where(t => t.IDTeam == team.IDTeam).FirstOrDefault();
                    toAdd.teamScore = teamScores;
                    toAdd.score = scores;
                    dbContext.establishedScoresTeam.Add(toAdd);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceScoresException("Error en la base de datos. Imposible agregar puntajes establecidos");
            }
        }
        public void Delete(EstablishedScoreTeam scores)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Team teamScores = dbContext.teams.Where(t => t.IDTeam == scores.teamScore.IDTeam).FirstOrDefault();
                    dbContext.establishedScoresTeam.Attach(scores);
                    dbContext.Entry(scores).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceScoresException("Error de base de datos: No se pudo eliminar puntajes establecidos.");
            }
        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<EstablishedScoreTeam> scores = dbContext.establishedScoresTeam.ToList();
                    foreach (EstablishedScoreTeam score in scores)
                    {
                        EstablishedScoreTeam toDelete = dbContext.establishedScoresTeam.Find(score.ID);
                        dbContext.establishedScoresTeam.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceScoresException("Error en la base de datos. Imposible vaciar valores de puntajes establecidos.");
            }
        }
        public bool Exists(EstablishedScoreTeam score)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<EstablishedScoreTeam> scores = dbContext.establishedScoresTeam.ToList();
                    return scores.Contains(score);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceScoresException("Error de base de datos: No se pudo determinar si los valores de puntajes establecidos existen.");
            }
        }
        public EstablishedScoreTeam GetEstablishedScoreTeam(int idTeam)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    EstablishedScoreTeam score = dbContext.establishedScoresTeam.Include(c => c.teamScore).Include(c => c.score).Include(c => c.ID).FirstOrDefault();
                    return score;
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceScoresException("Error de base de datos: No se pudo obtener los valores de puntajes establecidos.");

            }
        }
        public void ModifyEstablishedScoreTeam(int id, Score newScores)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    UserPersistance userContext = new UserPersistance();
                    EstablishedScoreTeam scores = dbContext.establishedScoresTeam.Where(t => t.ID == id).Include(t => t.teamScore).FirstOrDefault();
                    scores.score = newScores;
                    dbContext.establishedScoresTeam.Attach(scores);
                    dbContext.Entry(scores).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceScoresException("Error en la base de datos. Imposible Modificar puntajes establecidos. ");
            }
        }
    }
}
