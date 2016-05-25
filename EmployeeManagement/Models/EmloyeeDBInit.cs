using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
  public class EmloyeeDBInit : DropCreateDatabaseAlways<EmployeeManagementContext>
  {
    protected override void Seed(EmployeeManagementContext context)
    {
      context.Employees.AddRange(new Employee[]
        {
          new Employee { FullName = "Aaron Baum", Number = 123, StartDate = DateTime.Now.AddMonths(2) },
          new Employee { FullName = "Paul Stegler", Number = 777, StartDate = new DateTime(2016, 5, 1) },
        });
    }
  }
}