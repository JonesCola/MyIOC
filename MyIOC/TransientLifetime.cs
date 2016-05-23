// <copyright file="TransientLifetime.cs" company="Towers Watson">
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
  /// the transient lifetime
  /// </summary>
  public class TransientLifetime : ILifetime
  {
    /// <summary>
    /// get the instance of a transient object
    /// </summary>
    /// <param name="context">the context</param>
    /// <returns>the activated instance</returns>
    public object GetInstnce(ResolutionContext context)
    {
      return context.Activate();
    }
  }
}
