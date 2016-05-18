using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Community2.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
                new { id=RouteParameter.Optional });


            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}