using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
using System.Text;
using TaskManager.DataLib;
using TaskManager.Entities;


namespace TaskManager.BusinessLib
{
    public class ProjectBL
    {
        /// <summary>
        /// To Add Projectf
        /// </summary>
        /// <param name="item"></param>
        public void AddProject(Project item)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    item.ProjectManager = null;
                    db.Projects.Add(item);
                   
                    db.SaveChanges();
                    int id = item.ProjectId;
                }
            }

            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get all Projects
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProjects()
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    var Projects = db.Projects.Include(c => c.ProjectManager).ToList();
                    foreach (Project P in Projects)
                    {
                        P.TotNoofTasks = db.Tasks.Where(T => T.TaskProject.ProjectId == P.ProjectId).Count();
                        P.NoofTasksCompleted = db.Tasks.Where(T => T.Status == "Completed" && T.TaskProject.ProjectId == P.ProjectId).Count();
                    }
                    return Projects;

                    /*
                                      var  projects= ( from U in db.Users
                                                      join P in db.Projects
                                                      on U.UserId equals P.ProjectManager.UserId
                                                      select new Project
                                                      {
                                                          ProjectId = P.ProjectId
                                                         ,
                                                          ProjectName = P.ProjectName,
                                                          Startdate = P.Startdate,
                                                          Enddate = P.Enddate,
                                                          Priority = P.Priority,                                    
                                                          FirstName = U.FirstName,
                                                          LastName = U.LastName,
                                                          UserId=U.UserId
                                                      }).ToList<dynamic>;
                                        return projects;*/
                    // return project.ToList();

                }

            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To Get specific Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Project GetProjectByName(string ProjectName)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Projects.SingleOrDefault(k => k.ProjectName == ProjectName);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// To Get specific Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        public Project GetProjectById(int ProjectId)
        {

            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    return db.Projects.SingleOrDefault(k => k.ProjectId == ProjectId);
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Tp update the Project
        /// </summary>
        /// <param name="Project"></param>
        public void UpdateProject(Project project)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {
                    project.ProjectManager = null;
                    db.Entry(project).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception exception)
            {

                throw;
            }
        }

        /// <summary>
        /// To delete the Project
        /// </summary>
        /// <param name="ProjectId"></param>
        public void DeleteProject(int ProjectId)
        {
            try
            {
                using (TaskMangerContext db = new TaskMangerContext())
                {

                    Project project = new Project { ProjectId = ProjectId };
                    db.Entry(project).State = EntityState.Deleted;
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
