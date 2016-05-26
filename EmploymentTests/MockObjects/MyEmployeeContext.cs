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
  /// my mock for the database context
  /// </summary>
  internal class MyEmployeeContext : IEmployeeManagementContext
  {
    /// <summary>
    /// the collection of dummy data
    /// </summary>
    private TestEmployeeDbSet employees = new TestEmployeeDbSet();

    /// <summary>
    /// create a new instance
    /// </summary>
    public MyEmployeeContext()
    {
      this.employees.Add(new Employee { FullName = "Mr. Mcgoo", ID = 1, Number = 17 });
      this.employees.Add(new Employee { FullName = "Pink Panther", ID = 2, Number = 123 });
    }

    /// <summary>
    /// the Employees
    /// </summary>
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

    /// <summary>
    /// cleanup the thing
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public DbEntityEntry Entry(object entity)
    {
      return (DbEntityEntry<Employee>)this.employees.Where(x => x == entity);
    }

    public int SaveChanges()
    {
      return 0;
    }
  }
}
