using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
  public class EmployeeManagementContext : DbContext, IEmployeeManagementContext
  {
    /// <summary>
    /// the constructor for the employee management context
    /// </summary>
    public EmployeeManagementContext() : base("name=EmployeeManagementContext")
    {
    }

    /// <summary>
    /// the data set
    /// </summary>
    public System.Data.Entity.DbSet<EmployeeManagement.Models.Employee> Employees { get; set; } 
  }
}
