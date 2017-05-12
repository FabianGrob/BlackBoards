using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBoards.Interfaces
{
    public interface ICommentHandler
    {
        void CreateComment(User anUser, string newComment);
        void ResolveComment(User anUser);
        void AddResolvingUser(User anUser);
        void AddCommentingUser(User anUser);
        void AddCommentingDate(DateTime aDate);
        void AddResolvingDate(DateTime aDate);
        void WriteComment(string commentToAdd);
    }
}
