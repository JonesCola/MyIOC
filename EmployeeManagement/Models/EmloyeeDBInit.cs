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
          new Employee { FullName = "Aaron Baum", Number = 123, StartDate = DateTime.Now.AddMonths(1) },
          new Employee { FullName = "Paul Stegler", Number = 777, StartDate = new DateTime(2016, 5, 1) },
          new Employee { FullName = "Michael Henriquez", Number = 987, StartDate = new DateTime(2016, 6, 3) },
        });
    }
  }
}