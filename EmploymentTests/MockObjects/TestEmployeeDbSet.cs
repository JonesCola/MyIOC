using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentTests
{
  /// <summary>
  /// my specific version of the TestDbSet class
  /// </summary>
  public class TestEmployeeDbSet : TestDbSet<Employee>
  {
    /// <summary>
    /// override of the find
    /// </summary>
    /// <param name="keyValues">the key value to look up (ID)</param>
    /// <returns>the found employee object</returns>
    public override Employee Find(params object[] keyValues)
    {
      return this.SingleOrDefault(employee => employee.ID == (int)keyValues.Single());
    }
  }
}
