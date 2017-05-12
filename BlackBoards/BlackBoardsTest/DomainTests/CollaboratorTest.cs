using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackBoards;
using System.Threading.Tasks;

namespace BlackBoardsTest
{
    [TestClass]
    public class CollaboratorTest
    {

        [TestMethod]
        public void TestCollaboratorEquals()
        {
            Collaborator aCollaborator = new Collaborator();
            aCollaborator.Email = "Email A";
            Collaborator otherCollaborator = new Collaborator();
            otherCollaborator.Email = "Email B";
            Assert.IsFalse(aCollaborator.Equals(otherCollaborator));
        }
  

    [TestMethod]
        public void TestCollaboratorBuilder()
        {
            String name = "testName";
            String lastName = "testLastName";
            String email = "testEmail";
            DateTime birthDate = new DateTime();
            String password = "testPassword";
            Collaborator anCollaborator = new Collaborator(name, lastName, email, birthDate, password);
            Collaborator otherCollaborator = new Collaborator();
            otherCollaborator.Name = name;
            otherCollaborator.LastName = lastName;
            otherCollaborator.Email = email;
            otherCollaborator.BirthDate = birthDate;
            otherCollaborator.Password = password;
            Assert.IsTrue(anCollaborator.Equals(otherCollaborator));
        }
    }
}
