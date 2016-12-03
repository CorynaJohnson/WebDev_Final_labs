using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MyAppService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Users\Coryna\Documents\Visual Studio 2015\Projects\lab_2_web_design\lab_2_web_design\App_Data");
        }
    }
}
