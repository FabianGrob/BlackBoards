using System;
using BlackBoards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackBoardsTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String name = "testName";
            String lastName = "testLastName";
            String email = "testEmail";
            DateTime birthDate= new DateTime();
            String password = "testPassword";
            Admin anAdmin = new Admin(name,lastName,email,birthDate,password);
            Admin otherAdmin = new Admin();
            otherAdmin.Name = name;
            otherAdmin.LastName = lastName;
            otherAdmin.Email = email;
            otherAdmin.BirthDate = birthDate;
            otherAdmin.Password = password;
            Assert.Equals(anAdmin,otherAdmin);
        }
    }
}
