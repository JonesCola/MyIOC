using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
  /// <summary>
  /// the interface for the data context
  /// </summary>
  public interface IEmployeeManagementContext : IDisposable
  {
    /// <summary>
    /// the data set
    /// </summary>
    System.Data.Entity.DbSet<EmployeeManagement.Models.Employee> Employees { get; set; }

    /// <summary>
    /// save changes
    /// </summary>
    /// <returns>the id of the changed entry</returns>
    int SaveChanges();

    /// <summary>
    /// get the entry
    /// </summary>
    /// <param name="entity">the lookup entity</param>
    /// <returns>the database entry</returns>
    DbEntityEntry Entry(object entity);
  }
}
