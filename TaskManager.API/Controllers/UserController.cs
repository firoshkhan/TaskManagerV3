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
    public class UserController : ApiController
    {
     
        [Route("GetAllUsers")]
        public IHttpActionResult Get()  
        {
           
            UserBL obj = new UserBL();
            return Ok(obj.GetAllUsers());
        }
        [Route("GetUsersById/{UserId}")]
        public IHttpActionResult GetUsersById(int UserId)
        {

            UserBL obj = new UserBL();
            return Ok(obj.GetUserById(UserId));
        }
        [Route("DeleteUser/{UserId}") ]
        [HttpDelete]
        public IHttpActionResult Delete(int UserId)
        {
            
            UserBL obj = new UserBL();
            User user= obj.GetUserById(UserId);
            if (user == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No user  with ID = {0}", UserId)),
                    ReasonPhrase = "User ID Not Found"
                };
                throw new HttpResponseException(resp);
            }

            obj.DeleteUser(UserId);
            return Ok("User Deleted Sucessfully");
        }
        [Route("AddUser")]
        [HttpPost]
        public  IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserBL obj = new UserBL();
            obj.AddUser(user);
            return Ok(obj.GetAllUsers());
        }
        [Route("UpdateUser")]
        public IHttpActionResult Put(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserBL obj = new UserBL();
            obj.UpdateUser(user);
            return Ok(obj.GetAllUsers());
        }
        
    }
}