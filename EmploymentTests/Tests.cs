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
    /// the employer controller instance to test
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
      ActionResult result = this.RunTest(() => this.employeeController.Index(), 2);
      ViewResult moreData = (ViewResult)result;
      List<Employee> data = (List<Employee>)moreData.Model;
      Employee one = data.ElementAt(0);
      Assert.Equal(one.FullName, "Mr. Mcgoo");
    }

    /// <summary>
    /// the save test
    /// </summary>
    [Fact]
    public void TestSave()
    {
      this.RunTest(() => this.employeeController.Create(new Employee { ID = 3, FullName = "A really cool dude", Number = 9999, StartDate = new DateTime(2016, 4, 1) }), 3);
    }

    /// <summary>
    /// test delete
    /// </summary>
    [Fact]
    public void TestDelete()
    {
      this.RunTest(() =>  this.employeeController.DeleteConfirmed(3), 2);
    }

    /// <summary>
    /// a helper for my tests
    /// </summary>
    /// <param name="test">the test code to execute</param>
    /// <param name="expectedNumber">the expected number of elements</param>
    /// <returns>the actoin result for more testing</returns>
    private ActionResult RunTest(Func<ActionResult> test, int expectedNumber)
    {
      ActionResult ret = test();
      ActionResult result = this.employeeController.Index();
      Assert.NotNull(result);
      ViewResult moreData = (ViewResult)result;
      List<Employee> data = (List<Employee>)moreData.Model;
      Assert.Equal(data.Count, expectedNumber);
      return ret;
    }
  }
}
