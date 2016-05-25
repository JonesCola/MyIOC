using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EmploymentTests
{
  /// <summary>
  /// 
  /// </summary>
  internal class MyEmployeeContext : IEmployeeManagementContext
  {
    private TestDbSet<Employee> employees = new TestDbSet<Employee>();

    public MyEmployeeContext()
    {
      this.employees.Add(new Employee { FullName = "Mr. Mcgoo", ID = 1, Number = 17 });
    }

    public DbSet<Employee> Employees
    {
      get
      {
        return employees;
      }

      set
      {
      }
    }

    public void Dispose()
    {
    }

    public DbEntityEntry Entry(object entity)
    {
      return (DbEntityEntry)this.employees.Where(x => x == entity);
    }

    public int SaveChanges()
    {
      return 1;
    }
  }
}
