using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.API
{
    public class ProjectController : ApiController
    {

        [Route("GetAllProjects")]
        public IHttpActionResult Get()
        {
            try
            {
                ProjectBL obj = new ProjectBL();
                return Ok(obj.GetAllProjects());
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.InnerException.InnerException.Message.ToString()),
                    ReasonPhrase = "Action Failed !"
                };
                throw new HttpResponseException(resp);

            }
        }
        [Route("GetProjectsById/{ProjectId}")]
        public IHttpActionResult GetProjectsById(int ProjectId)
        {
            try
            {
                ProjectBL obj = new ProjectBL();
                return Ok(obj.GetProjectById(ProjectId));
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.InnerException.InnerException.Message.ToString()),
                    ReasonPhrase = "Action Failed !"
                };
                throw new HttpResponseException(resp);

            }
        }
        [Route("DeleteProject/{ProjectId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int ProjectId)
        {
            try
            {
                ProjectBL obj = new ProjectBL();
                Project project = obj.GetProjectById(ProjectId);
                if (project == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No Project  with ID = {0}", ProjectId)),
                        ReasonPhrase = "Project ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }

                obj.DeleteProject(ProjectId);
                return Ok(obj.GetAllProjects());
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.InnerException.InnerException.Message.ToString()),
                    ReasonPhrase = "Action Failed !"
                };
                throw new HttpResponseException(resp);

            }
        }
        [Route("AddProject")]
        [HttpPost]
        public IHttpActionResult Post(Project project)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ProjectBL obj = new ProjectBL();
                obj.AddProject(project);
                return Ok(obj.GetAllProjects());
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.InnerException.InnerException.Message.ToString()),
                    ReasonPhrase = "Action Failed !"
                };
                throw new HttpResponseException(resp);

            }
        }
        [Route("UpdateProject")]
        public IHttpActionResult Put(Project project)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                ProjectBL obj = new ProjectBL();
                obj.UpdateProject(project);
                return Ok(obj.GetAllProjects());
            }
            catch (Exception ex)
            {

                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.InnerException.InnerException.Message.ToString()),
                    ReasonPhrase = "Action Failed !"
                };
                throw new HttpResponseException(resp);

            }

        }
    }
}