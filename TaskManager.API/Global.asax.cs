using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using TaskManager.BusinessLib;
using TaskManager.DataLib;
using TaskManager.Entities;
namespace TaskManager.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            Database.SetInitializer<TaskMangerContext>(new DropCreateDatabaseIfModelChanges<TaskMangerContext>());
            Database.SetInitializer<TaskMangerContext>(null);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        
        }
    }
}
