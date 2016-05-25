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
    /// the backing field for the start date
    /// </summary>
    private DateTime startDate;

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
    [Display(AutoGenerateFilter = true)]
    public DateTime StartDate
    {
      get { return this.startDate; }
      set { this.startDate = value; }
    }

    /// <summary>
    /// the Display Start Date
    /// </summary>
    [Display(Name = "Start Date")]
    public string DisplayStartDate
    {
      get
      {
        return this.startDate.ToShortDateString();
      }
      set
      {
        this.startDate = DateTime.Parse(value);
      }
    }
  }
}