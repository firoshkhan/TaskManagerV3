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
using System.Web.Http.Results;

namespace Test
{
    [TestFixture]
    class TestUserServices
    {

        [Test]
        public void UserControllerGetAllUsers()
        {
            var controller = new UserController();
            var CreateResult = controller.Get() as OkNegotiatedContentResult<List<TaskManager.Entities.User>>;
            int cnt = CreateResult.Content.Count();
            Assert.GreaterOrEqual( cnt,1);
        }


        [Test]
    public void UserTestCreateAction()

    {
        Random randm = new Random();
        int rand = randm.Next(1, 1000);
        string UserName1 = "Test UserName1" + rand.ToString();
        UserController controller = new UserController();
        TaskManager.Entities.User User = new TaskManager.Entities.User();
        User.FirstName = UserName1;
        User.EmpId = "1234";
        User.LastName = "Last Name";
        var CreateResult = controller.Post(User) as OkNegotiatedContentResult<List<TaskManager.Entities.User>>;
        int cnt= CreateResult.Content.Where(p => p.FirstName == UserName1).Count();
        Assert.GreaterOrEqual(cnt,1 );           

    }

    [Test]
    public void UserTestEditAction()
    {
        Random randm = new Random();
        int rand = randm.Next(1, 1000);

        string UserName1 = "Test UserName1" + rand.ToString();
        UserController controller = new UserController();
        TaskManager.Entities.User User = new TaskManager.Entities.User();
        User.FirstName = UserName1;
        User.EmpId = "1234";
        User.LastName = "Last Name";

        var CreateResult = controller.Post(User) as OkNegotiatedContentResult<List<TaskManager.Entities.User>>;
        string updUserName= User.FirstName + "U";
        User.FirstName = updUserName;
        var updResult = controller.Put(User) as OkNegotiatedContentResult<List<TaskManager.Entities.User>>;
        int cnt = updResult.Content.Where(p => p.FirstName == updUserName).Count();

        Assert.GreaterOrEqual(cnt,1 );

        }
    }
}