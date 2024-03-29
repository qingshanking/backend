﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Web.App_Start;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //注册WEBAPI路由
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //注册控制器路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
