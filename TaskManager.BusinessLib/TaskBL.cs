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
    public class TaskBL
    {
        /// <summary>
        /// To Add Task
        /// </summary>
        /// <param name="item"></param>
        public void AddTask(Task item)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {

                    db.Tasks.Add(item);
                    db.SaveChanges();
                    int id = item.TaskId;
                }
            }

            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get all Tasks
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAllTasks()
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    //  return db.Tasks.ToList();
                    return db.Tasks.Include(c => c.TaskUser).Include(d => d.TaskProject).ToList();
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To Get specific task
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public Task GetTaskByName(string Name)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Tasks.SingleOrDefault(k => k.TaskName == Name);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get specific task
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public Task GetTaskById(int TaskId)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Tasks.Include(c => c.TaskUser).Include(d => d.TaskProject).Include(a => a.TaskParent).SingleOrDefault(k => k.TaskId == TaskId);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }


        /// <summary>
        /// To Get specific task
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        public List<Task> GetTaskByProjectId(int ProjId)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Tasks.Where(k => k.TaskProjectId == ProjId).ToList();
                    //  return db.Tasks.SingleOrDefault(k => k.TaskProjectId == ProjId);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Tp update the Task
        /// </summary>
        /// <param name="task"></param>
        public void UpdateTask(Task task)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To delete the task
        /// </summary>
        /// <param name="TaskId"></param>
        public void DeleteTask(int TaskId)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {

                    Task task = new Task { TaskId = TaskId };
                    db.Entry(task).State = EntityState.Deleted;
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
