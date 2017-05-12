using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackBoardsTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestBuilderRepository()
        {
            String name = "testBoard";
            String description = "this is a board";
            int heigth = 5;
            int width = 5;
            Team team = new Team();
            team.Name = "testTeam";

            //objects instance
            BlackBoard board = new BlackBoard(name, description, heigth, width, team);
            Admin admin = new Admin("nameTest", "lastNameTest", "emailTest", new DateTime(), "passwordTest");
            Collaborator collaborator = new Collaborator("nameTest", "lastNameTest", "emailTest", new DateTime(), "passwordTest");

            List<Admin> administratorList = new List<Admin>();
            List<User> userList = new List<User>();
            
            administratorList.Add(admin);
            userList.Add(collaborator);

            Repository repository = new Repository(administratorList, userList);
            bool compareAdministratorList = repository.AdministratorList.Equals(administratorList);
            bool compareCollaboratorList = repository.UserList.Equals(userList);
            
            Assert.IsTrue(compareAdministratorList && compareCollaboratorList);
        }

    }
}
