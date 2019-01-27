using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskManager.API;

using System.Collections;
using System.Web;
using System.Web.Http;
using TaskManager.BusinessLib;

namespace Test
{
    [TestFixture]
    public class TestUserBL
    {
       

        [Test]
        public void TestGetAllUsers()
        {
         
            TaskManager.BusinessLib.UserBL obj = new UserBL();
            int Count= obj.GetAllUsers().Count;
            Assert.Greater(Count, 0);
            
        }
       
        [Test]
        public void TestAddUser()
        {
            Random randm = new Random();
            int rand = randm.Next(1, 10000);
            string FirstName = "First Name1 "+ rand.ToString();
            TaskManager.BusinessLib.UserBL obj = new UserBL();

            obj.AddUser(new TaskManager.Entities.User()
            {
                FirstName = FirstName,
                EmpId="1234",
                LastName="Last Name"               

            }
             );

            TaskManager.Entities.User t = obj.GetUserByName(FirstName);
            Assert.AreEqual(FirstName, t.FirstName);

        }

        [Test]
        public void TestUpdUser()
        {
            Random randm = new Random();
            int rand = randm.Next(1, 10000);
            string FirstName = "First Name1 " + rand.ToString();
            TaskManager.BusinessLib.UserBL obj = new UserBL();
            obj.AddUser(new TaskManager.Entities.User()
            {

                FirstName = FirstName,
                EmpId = "1234",
                LastName = "Last Name"

            }
             );

            TaskManager.Entities.User t1 = obj.GetUserByName(FirstName);
            string updFirstName= FirstName +"_u";
            t1.FirstName = updFirstName;
              obj.UpdateUser(t1); ;
            
            TaskManager.Entities.User t2 = obj.GetUserByName(updFirstName);
            Assert.AreEqual(t2.FirstName, t1.FirstName);

        }

      
    }
}
