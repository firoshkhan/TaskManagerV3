using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using TaskManager.DataLib;
using TaskManager.Entities;


namespace TaskManager.BusinessLib
{
    public class UserBL
    {
        /// <summary>
        /// To Add User
        /// </summary>
        /// <param name="item"></param>
        public void AddUser(User item)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {

                    db.Users.Add(item);
                    db.SaveChanges();
                    int id = item.UserId;
                }
            }

            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get all Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Users.ToList();
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To Get specific User
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public User GetUserByName(string Name)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Users.SingleOrDefault(k => k.FirstName == Name);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get specific User
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public User GetUserById(int UserId)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Users.SingleOrDefault(k => k.UserId == UserId);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Tp update the User
        /// </summary>
        /// <param name="User"></param>
        public void UpdateUser(User user)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To delete the User
        /// </summary>
        /// <param name="UserId"></param>
        public void DeleteUser(int UserId)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {

                    User user = new User { UserId = UserId };
                    db.Entry(user).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
    }
}
