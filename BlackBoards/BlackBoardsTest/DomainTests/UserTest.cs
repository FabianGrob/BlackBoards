using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlackBoards;


namespace BlackBoardsTest
{
    [TestClass]
    public class UserTest
    {
        public UserTest()
        {
            Assert.IsTrue(true);
         
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    
    }
}
