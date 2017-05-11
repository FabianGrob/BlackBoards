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
            administratorList.Add(admin);
            userList.Add(collaborator);

            //assert
            Repository repository = new Repository(administratorList, userList);
            bool compareAdministratorList = repository.AdministratorList.Equals(administratorList);
            bool compareUserList = repository.UserList.Equals(userList);
            Assert.IsTrue(compareAdministratorList && compareUserList);
        }

    }
}
