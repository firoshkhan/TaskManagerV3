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
    public class TaskController : ApiController
    {

        [Route("GetAllTasks")]
        public IHttpActionResult Get()
        {
            try
            {
                TaskBL obj = new TaskBL();
                return Ok(obj.GetAllTasks());
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
        [Route("GetTasksById/{TaskId}")]
        public IHttpActionResult GetTasksById(int TaskId)
        {
            try
            {
                TaskBL obj = new TaskBL();
                return Ok(obj.GetTaskById(TaskId));
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
        [Route("GetTasksByProject/{ProjId}")]
        public IHttpActionResult GetTaskByProjectId(int ProjId)
        {
            try
            {
                TaskBL obj = new TaskBL();
                return Ok(obj.GetTaskByProjectId(ProjId));
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
        [Route("DeleteTask/{TaskId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int TaskId)
        {
            try
            {
                TaskBL obj = new TaskBL();
                Task task = obj.GetTaskById(TaskId);
                if (task == null)
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("No task  with ID = {0}", TaskId)),
                        ReasonPhrase = "Task ID Not Found"
                    };
                    throw new HttpResponseException(resp);
                }

                obj.DeleteTask(TaskId);
                return Ok("Task Deleted Sucessfully");
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
        [Route("AddTask")]
        [HttpPost]
        public IHttpActionResult Post(Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                TaskBL obj = new TaskBL();
                obj.AddTask(task);
                return Ok(task.TaskId.ToString());
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
        [Route("UpdateTask")]
        public IHttpActionResult Put(Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                TaskBL obj = new TaskBL();
                obj.UpdateTask(task);
                return Ok("Task Updated Sucessfully");
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