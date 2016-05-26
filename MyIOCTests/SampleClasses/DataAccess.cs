// <copyright file="DataAccess.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// the data access class
  /// </summary>
  public class DataAccess : IDataAccess
  {
    /// <summary>
    /// the connection string
    /// </summary>
    private string conStr;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataAccess"/> class.
    /// </summary>
    /// <param name="connection">the connection string to the data</param>
    public DataAccess(string connection)
    {
      this.conStr = connection;
    }

    /// <summary>
    /// Gets or sets the connection string
    /// </summary>
    public string ConStr
    {
      get { return this.conStr; }
      set { this.conStr = value; }
    }
  }
}
