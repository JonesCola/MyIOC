using MyIOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmployeeManagement.Models
{
  public class ControllerFactory : DefaultControllerFactory
  {
    private readonly Container container;

    public ControllerFactory(Container container)
    {
      this.container = container;
    }

    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
      return container.Resolve(controllerType) as Controller;
    }
  }
}