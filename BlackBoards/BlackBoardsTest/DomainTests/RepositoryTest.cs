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
            //instance variables
            Admin admin = new Admin("nameTest", "lastNameTest", "emailTest", new DateTime(), "passwordTest");
            Collaborator collaborator = new Collaborator("nameTest", "lastNameTest", "emailTest", new DateTime(), "passwordTest");

            //objects instance
            List<Admin> administratorList= new List<Admin>();
            List<User> userList = new List<User>();
            List<Team> teamList = new List<Team>();
            administratorList.Add(admin);
            userList.Add(collaborator);

            //assert
            Repository repository = new Repository(administratorList, userList,teamList);
            bool compareAdministratorList = repository.AdministratorList.Equals(administratorList);
            bool compareUserList = repository.UserList.Equals(userList);
            bool compareTeamList = repository.TeamList.Equals(teamList);
            Assert.IsTrue(compareAdministratorList && compareUserList && compareTeamList);
        }

    }
}
