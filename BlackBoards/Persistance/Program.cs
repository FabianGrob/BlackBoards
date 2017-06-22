using BlackBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Persistance
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var ctx = new BlackBoardsContext())
            {
                User stud = new Admin();
                ctx.users.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
