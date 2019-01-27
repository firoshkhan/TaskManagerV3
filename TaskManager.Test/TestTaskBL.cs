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
    public class TestTaskBL
    {
       

        [Test]
        public void TestGetAlltasks()
        {      

            TaskManager.BusinessLib.TaskBL obj = new TaskBL();
            int Count= obj.GetAllTasks().Count;
            Assert.Greater(Count, 0);           
        }
       
        [Test]
        public void TestAddTask()
        {
            Random randm = new Random();
            int rand = randm.Next(1, 10000);
            string TaskName1 = "Task Name1" + rand.ToString();
            TaskManager.BusinessLib.TaskBL obj = new TaskBL();

            obj.AddTask(new TaskManager.Entities.Task()
            {
                
                TaskName = TaskName1,
                Startdate = DateTime.Now,
                Enddate = DateTime.Now,
                Priority = 10

            }
             );
            TaskManager.Entities.Task t = obj.GetTaskByName(TaskName1);
            Assert.AreEqual(TaskName1, t.TaskName);
        }

  
        [Test]
        public void TestUpdTask()
        {
            Random randm = new Random();
            int rand = randm.Next(1, 10000);
            string TaskName1 = "Task Name1 " + rand.ToString();
            TaskManager.BusinessLib.TaskBL obj = new TaskBL();
            obj.AddTask(new TaskManager.Entities.Task()          {
                 TaskName = TaskName1,
                Startdate = DateTime.Now,
                Enddate = DateTime.Now,
                Priority = 10

            }
             );

            TaskManager.Entities.Task t1 = obj.GetTaskByName(TaskName1);
            string updTaskName1 = TaskName1 + "_u";
            t1.TaskName = updTaskName1;
            obj.UpdateTask(t1); ;

            TaskManager.Entities.Task t2 = obj.GetTaskByName(updTaskName1);
            Assert.AreEqual(t2.TaskName, t1.TaskName);

        }

    }
}
