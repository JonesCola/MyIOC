// <copyright file="SingletonLifetime.cs" company="Towers Watson">
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
  /// the singleton lifetime implementation
  /// </summary>
  public class SingletonLifetime : ILifetime
  {
    /// <summary>
    /// cached instance
    /// </summary>
    private object instance;

    /// <summary>
    /// get the cached instance if it exists otherwise activate and cache it
    /// </summary>
    /// <param name="context">the context</param>
    /// <returns>the instance</returns>
    public object GetInstnce(ResolutionContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException(nameof(context), "invalid resolution context passed into the Singleton Lifetime constructor");
      }

      if (this.instance == null)
      {
        this.instance = context.Activate();
      }

      return this.instance;
    }
  }
}
