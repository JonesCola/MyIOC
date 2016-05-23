// <copyright file="ILifetime.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOC
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// the interface for the lifetime
  /// </summary>
  public interface ILifetime
  {
    /// <summary>
    /// get the instance of the object from the resolution context
    /// </summary>
    /// <param name="context">the resolution context</param>
    /// <returns>the object instance</returns>
    object GetInstnce(ResolutionContext context);
  }
}
