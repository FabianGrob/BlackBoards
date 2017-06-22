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
        public void AddComment(User creatorUser, DateTime date, string message, Item iteam)
        {
            try
            {
                using (BlackBoardsContext dbContext = new BlackBoardsContext())
                {
                    Comment aComment = new Comment();
                    UserPersistance userContext = new UserPersistance();
                    User commenting = dbContext.users.Where(t => t.ID == creatorUser.ID).Include(u => u.createdComments).FirstOrDefault();
                    aComment.commentingUser = commenting;
                    User resolving = dbContext.users.Where(t => t.ID == creatorUser.ID).Include(u => u.createdComments).FirstOrDefault();
                    aComment.resolvingUser = resolving;
                    aComment.WrittenComment = message;
                    aComment.CommentingDate = date;
                    aComment.itemBelong = iteam;
                    ItemPersistance itemContext = new ItemPersistance();
                    Item itemBelongs = dbContext.items.Where(t => t.IDItem == aComment.itemBelong.IDItem).Include(u => u.comments).FirstOrDefault();
                    aComment.itemBelong = itemBelongs;
                    aComment.ResolvingDate = aComment.CommentingDate.AddDays(-1);
                    dbContext.comments.Add(aComment);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
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
                    UserPersistance userContext = new UserPersistance();
                    User commenting = dbContext.users.Where(t => t.ID == aComment.commentingUser.ID).Include(u => u.createdComments).FirstOrDefault();
                    ItemPersistance itemContext = new ItemPersistance();
                    Item itemBelongs = dbContext.items.Where(t => t.IDItem == aComment.itemBelong.IDItem).Include(u => u.comments).FirstOrDefault();
                    User resolving = dbContext.users.Where(t => t.ID == aComment.resolvingUser.ID).Include(u => u.createdComments).FirstOrDefault();
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
            catch (Exception ex)
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
                    Comment completeComent = dbContext.comments.Include(c => c.commentingUser).Include(c => c.itemBelong).Include(c => c.resolvingUser).FirstOrDefault(c => c.IDComment == id);
                    return completeComent;
                }
            }
            catch (Exception ex)
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
                    UserPersistance userContext = new UserPersistance();
                    Comment anotherComment = dbContext.comments.Where(t => t.IDComment == aComment.IDComment).FirstOrDefault();
                    anotherComment.resolvingUser = aComment.resolvingUser;
                    anotherComment.ResolvingDate = aComment.ResolvingDate;
                    User resolving = dbContext.users.Where(t => t.ID == aComment.resolvingUser.ID).Include(u => u.resolvedComments).FirstOrDefault();
                    dbContext.comments.Attach(anotherComment);
                    dbContext.Entry(anotherComment).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw new PersistanceCommentException("Error en la base de datos. Imposible Modificar el Comentario. ");
            }
        }
    }
}
