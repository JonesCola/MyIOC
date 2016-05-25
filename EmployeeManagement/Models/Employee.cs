using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
  /// <summary>
  /// th employee model
  /// </summary>
  public class Employee
  {
    /// <summary>
    /// the primary key
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// the full name
    /// </summary>
    [Display(Name = "Full Name")]
    public string FullName { get; set; }
  
    /// <summary>
    /// the employee number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// the start date
    /// </summary>
    [Display(Name = "Start Date")]
    ////[DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
  }
}