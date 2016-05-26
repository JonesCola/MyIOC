// <copyright file="ILogicLayer.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  /// <summary>
  /// the interface for legacy parts
  /// </summary>
  public interface ILogicLayer
  {
    /// <summary>
    /// retrieve the connection string
    /// </summary>
    /// <returns>normally would never do this but this is a good test</returns>
    string GetConnection();
  }
}
