using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace EmploymentTests
{
  /// <summary>
  /// a class for unit tests
  /// </summary>
  public class Tests
  {
    /// <summary>
    /// the employer controll instance to test
    /// </summary>
    private EmployeesController employeeController;

    /// <summary>
    /// the constructor
    /// </summary>
    public Tests()
    {
      MyIOC.Container container = new MyIOC.Container();
      container.Register<MyEmployeeContext, IEmployeeManagementContext>();
      container.Register<EmployeesController, IController>();

      this.employeeController = container.Resolve<EmployeesController>();
    }

    /// <summary>
    /// test the get
    /// </summary>
    [Fact]
    public void TestGet()
    {
      ActionResult result = this.employeeController.Index();
      Assert.NotNull(result);
      ViewResult moreData = (ViewResult)result;
      List<Employee> data = (List<Employee>)moreData.Model;
      Assert.Equal(data.Count, 1);
      Employee one = data.ElementAt(0);
      Assert.Equal(one.FullName, "Mr. Mcgoo");
    }
  }
}
