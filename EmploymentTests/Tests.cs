using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using Moq;
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
    /// the mocked database layer
    /// </summary>
    private readonly Mock<IEmployeeManagementContext> employeeDataAccess = new Mock<IEmployeeManagementContext>();

    /// <summary>
    /// the employer controll instance to test
    /// </summary>
    private EmployeesController employeeController;

    /// <summary>
    /// the test data
    /// </summary>
    private Employee[] testdata = new Employee[]
      {
        new Employee
        {
          FullName = "Test Name",
          ID = 1,
          Number = 1,
          StartDate = DateTime.Now
        },
        new Employee
        {
          FullName = "Another test name",
          ID = 2,
          Number = 10,
          StartDate = DateTime.Now.AddDays(-30)
        }
      };

    /// <summary>
    /// the constructor
    /// </summary>
    public Tests()
    {
      MyIOC.Container container = new MyIOC.Container();
      container.RegisterSingleton<IEmployeeManagementContext>(this.employeeDataAccess.Object);
      container.Register<EmployeesController, IController>();

      this.employeeController = container.Resolve<EmployeesController>();
    }

    /// <summary>
    /// test the get
    /// </summary>
    [Fact]
    public void TestGet()
    {
      SetTestData();
      this.employeeController.Index();
    }

    /// <summary>
    /// method to set the test data into my mock
    /// </summary>
    private void SetTestData()
    {
      this.employeeDataAccess.Setup(x => x.Employees.AddRange(testdata));
    }
  }
}
