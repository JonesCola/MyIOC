using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmployeeManagement
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      Database.SetInitializer(new EmloyeeDBInit());

      var container = new MyIOC.Container();
      container.Register<EmployeeManagementContext, IEmployeeManagementContext>();
      container.Register<EmployeesController, IController>();
      ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(container));

      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
  }
}
