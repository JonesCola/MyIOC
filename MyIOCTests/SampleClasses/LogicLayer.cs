// <copyright file="LogicLayer.cs" company="Towers Watson">
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
  /// the logic layer implementation
  /// </summary>
  public class LogicLayer : ILogicLayer
  {
    /// <summary>
    /// the data access
    /// </summary>
    private IDataAccess dataAccess;

    /// <summary>
    /// Initializes a new instance of the <see cref="LogicLayer"/> class.
    /// </summary>
    /// <param name="dataAccess">the data access layer</param>
    /// <param name="legacy">the legacy part</param>
    public LogicLayer(IDataAccess dataAccess, ILegacyPart legacy)
    {
      this.dataAccess = dataAccess;
    }

    /// <summary>
    /// retrieve the connection string
    /// </summary>
    /// <returns>normally would never do this but this is a good test</returns>
    public string GetConnection()
    {
      return this.dataAccess.ConStr;
    }
  }
}
