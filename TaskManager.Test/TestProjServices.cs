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
    class TestProjServices
    {

        [Test]
        public void ProjectControllerGetProjectsByIdTest2()
        {
            var controller = new ProjectController();
            var getresult = controller.Get() as OkNegotiatedContentResult<List<TaskManager.Entities.Project>>;
            int cnt = getresult.Content.Count();
            Assert.GreaterOrEqual(cnt, 1);
        }
            [Test]
    public void ProjectTestCreateAction()

    {
            Random randm = new Random();
            int rand = randm.Next(1, 1000);
            string ProjectName1 = "ProjectName1 Test" + rand.ToString();
            ProjectController controller = new ProjectController();
            TaskManager.Entities.Project Project = new TaskManager.Entities.Project();
            Project.Priority = 10;
            Project.ProjectName = ProjectName1;
            Project.Startdate = DateTime.Now;       
            var CreateResult = controller.Post(Project) as OkNegotiatedContentResult<List<TaskManager.Entities.Project>>;
           int cnt = CreateResult.Content.Where(p => p.ProjectName == ProjectName1).Count();
           Assert.GreaterOrEqual(1, cnt);
        }

    [Test]
    public void ProjectTestEditAction()
    {
            Random randm = new Random();
            int rand = randm.Next(1, 1000);
            string ProjectName1 = "ProjectName1 Test" + rand.ToString();
            ProjectController controller = new ProjectController();
            TaskManager.Entities.Project Project = new TaskManager.Entities.Project();
            Project.Priority = 10;
            Project.ProjectName = ProjectName1;
            Project.Startdate = DateTime.Now;
            var CreateResult = controller.Post(Project) as OkNegotiatedContentResult<List<TaskManager.Entities.Project>>;
             
            string updProjectName =Project.ProjectName + "U";
            Project.ProjectName = updProjectName;
            var updResult = controller.Put(Project) as OkNegotiatedContentResult<List<TaskManager.Entities.Project>>;
            int cnt = updResult.Content.Where(p => p.ProjectName == updProjectName).Count();
            Assert.GreaterOrEqual(cnt, 1);

        }
    }
}