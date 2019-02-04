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
            try
            {
                UserBL obj = new UserBL();
            return Ok(obj.GetAllUsers());
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
        [Route("GetUsersById/{UserId}")]
        public IHttpActionResult GetUsersById(int UserId)
        {
            try
            {
                UserBL obj = new UserBL();
            return Ok(obj.GetUserById(UserId));
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
        [Route("DeleteUser/{UserId}") ]
        [HttpDelete]
        public IHttpActionResult Delete(int UserId)
        {

            try
            {

                UserBL obj = new UserBL();
                User user = obj.GetUserById(UserId);
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
        [Route("AddUser")]
        [HttpPost]
        public  IHttpActionResult Post(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                UserBL obj = new UserBL();
                obj.AddUser(user);
                return Ok(obj.GetAllUsers());
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
        [Route("UpdateUser")]
        public IHttpActionResult Put(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                UserBL obj = new UserBL();


                obj.UpdateUser(user);
                return Ok(obj.GetAllUsers());

            }
            catch ( Exception ex)
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