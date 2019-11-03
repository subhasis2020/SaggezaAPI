using RailwayService.Controllers;
using RailwayService.Helper;
using RailwayService.Service;
using RailwayService.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace RailwayService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EnableIOContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void EnableIOContainer()
        {            
            DependencyInjector.Register<IRailwayService, Service.RailwayService>();
            DependencyInjector.Register<IStationRepository, StationRepository>();            
        }
    }
}
