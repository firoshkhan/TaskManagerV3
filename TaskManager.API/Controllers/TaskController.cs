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
           
            TaskBL obj = new TaskBL();
            return Ok(obj.GetAllTasks());
        }
        [Route("GetTasksById/{TaskId}")]
        public IHttpActionResult GetTasksById(int TaskId)
        {

            TaskBL obj = new TaskBL();
            return Ok(obj.GetTaskById(TaskId));
        }
        [Route("GetTasksByProject/{ProjId}")]
        public IHttpActionResult GetTaskByProjectId(int ProjId)
        {

            TaskBL obj = new TaskBL();
            return Ok(obj.GetTaskByProjectId(ProjId));
        }
        [Route("DeleteTask/{TaskId}") ]
        [HttpDelete]
        public IHttpActionResult Delete(int TaskId)
        {
            
            TaskBL obj = new TaskBL();
            Task task= obj.GetTaskById(TaskId);
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
        [Route("AddTask")]
        [HttpPost]
        public IHttpActionResult Post(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TaskBL obj = new TaskBL();
            obj.AddTask(task);
            return Ok(task.TaskId.ToString());
        }
        [Route("UpdateTask")]
        public IHttpActionResult Put(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TaskBL obj = new TaskBL();
            obj.UpdateTask(task);
            return Ok("Task Updated Sucessfully");
        }
        
    }
}