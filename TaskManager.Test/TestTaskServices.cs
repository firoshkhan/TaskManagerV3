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
    class TestTaskServices
    {

        [Test]
        public void TaskControllerGetAllTasks()
        {
            var controller = new TaskController();
            var getresult = controller.Get() as OkNegotiatedContentResult<List<TaskManager.Entities.Task>>;
            int cnt = getresult.Content.Count();
            Assert.GreaterOrEqual( cnt,1);

        }


    [Test]
    public void TaskTestCreateAction()

    {
            Random randm = new Random();
            int rand = randm.Next(1, 1000);

            string TaskName1 = "TaskName Test2" + rand.ToString();
            TaskController controller = new TaskController();
            TaskManager.Entities.Task task = new TaskManager.Entities.Task();
            task.Priority = 10;
            task.TaskName = TaskName1;
            task.Startdate = DateTime.Now;       
            var CreateResult = controller.Post(task) as OkNegotiatedContentResult<string>;
            Assert.IsNotEmpty( CreateResult.Content);
            

    }

    [Test]
    public void TaskTestEditAction()
    {

        Random randm = new Random();
        int rand = randm.Next(1, 1000);

        string TaskName1 = "TaskName Test2" + rand.ToString();
        TaskController controller = new TaskController();
        TaskManager.Entities.Task task = new TaskManager.Entities.Task();
        task.Priority = 10;
        task.TaskName = TaskName1;
        task.Startdate = DateTime.Now;

        var CreateResult = controller.Post(task) as OkNegotiatedContentResult<string>;
        var UpdateResult = controller.Put(task) as  OkNegotiatedContentResult<string>;
        Assert.AreEqual("Task Updated Sucessfully", UpdateResult.Content);
           


        }
    }
}