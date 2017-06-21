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
    public class CommentPersistance
    {
        public void AddComment(Comment aComment)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.users.Attach(aComment.commentingUser);
                    dbContext.users.Attach(aComment.resolvingUser);
                    dbContext.items.Attach(aComment.itemBelong);
                    dbContext.comments.Add(aComment);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceCommentException("Error en la base de datos. Imposible agregar el Comentario");
            }
        }
        public void Delete(Comment aComment)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    dbContext.comments.Attach(aComment);
                    dbContext.Entry(aComment).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceCommentException("Error de base de datos: No se pudo eliminar el Comentario.");
            }
        }
        public void Empty()
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Comment> listOfComments = dbContext.comments.ToList();
                    foreach (Comment actualComment in listOfComments)
                    {
                        Comment toDelete = dbContext.comments.Find(actualComment.IDComment);
                        dbContext.comments.Remove(toDelete);
                    }
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceCommentException("Error en la base de datos. Imposible vaciar valores de comentarios.");
            }
        }
        public bool Exists(Comment aComment)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    List<Comment> listOfComments = dbContext.comments.ToList<Comment>();
                    return listOfComments.Contains(aComment);
                }
            }
            catch (Exception ex)
            {
                throw new PersistanceCommentException("Error de base de datos: No se pudo determinar si el comentarios existe.");
            }
        }
        public Comment GetComment(int id)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    return dbContext.comments.Find(id);
                }
            }
            catch (Exception)
            {
                throw new PersistanceCommentException("Error de base de datos: No se pudo obtener el Comentario.");

            }
        }
        public void ResolveComment(Comment aComment)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {

                    if (this.Exists(aComment))
                    {
                        Comment anotherComment = this.GetComment(aComment.IDComment);
                        dbContext.comments.Attach(anotherComment);
                        UserPersistance userContext = new UserPersistance();
                        User resolvingUser = userContext.GetUserByEmail(aComment.resolvingUser.Email);
                        anotherComment.resolvingUser = resolvingUser;
                        dbContext.users.Attach(anotherComment.resolvingUser);
                        anotherComment.ResolvingDate = DateTime.Now;
                        dbContext.Entry(anotherComment).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new PersistanceCommentException("Error en la base de datos. Imposible Modificar el Comentario. ");
            }
        }
    }
}
