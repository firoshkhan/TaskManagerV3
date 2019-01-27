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
    public class TestProjectBL
    {


        [Test]
        public void TestGetAllProjects()
        {
            TaskManager.BusinessLib.ProjectBL obj = new ProjectBL();
            int Count = obj.GetAllProjects().Count;
            Assert.Greater(Count, 0);
        }
           
        [Test]
        public void TestAddProject()
        {
            Random randm = new Random();
            int rand = randm.Next(1, 10000);
            string ProjectName1 = "Test Project2"+ rand.ToString();
            TaskManager.BusinessLib.ProjectBL obj = new ProjectBL();
            obj.AddProject(new TaskManager.Entities.Project()
            {
                
                ProjectName = ProjectName1,
                Startdate = DateTime.Now,
                Enddate = DateTime.Now,
                Priority = 10

            }
             );

            TaskManager.Entities.Project t = obj.GetProjectByName(ProjectName1);
            Assert.AreEqual(ProjectName1, t.ProjectName);

        }

     
    [Test]
    public void TestUpdProject()
    {
        Random randm = new Random();
        int rand = randm.Next(1, 10000);
        string ProjectName1 = "ProjectName Name1 " + rand.ToString();
        TaskManager.BusinessLib.ProjectBL obj = new ProjectBL();
        obj.AddProject(new TaskManager.Entities.Project()
        {
            ProjectName = ProjectName1,
            Startdate = DateTime.Now,
            Enddate = DateTime.Now,
            Priority = 10
        }
         );

        TaskManager.Entities.Project t1 = obj.GetProjectByName(ProjectName1);
        string updProjectName1 = ProjectName1 + "_u";
        t1.ProjectName = updProjectName1;
        obj.UpdateProject(t1); 
        TaskManager.Entities.Project t2 = obj.GetProjectByName(updProjectName1);
        Assert.AreEqual(t2.ProjectName, t1.ProjectName);

    }
}

}
