// <copyright file="ITestController.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  /// <summary>
  /// the interface for the test controller
  /// </summary>
  public interface ITestController
  {
    /// <summary>
    /// set the static data to something else
    /// </summary>
    /// <param name="data">the new static data</param>
    void SetStaticData(string data);
  }
}
