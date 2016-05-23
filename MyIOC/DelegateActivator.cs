// <copyright file="DelegateActivator.cs" company="Towers Watson">
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
  /// the delegate based activator
  /// </summary>
  public class DelegateActivator : IActivator
  {
    /// <summary>
    /// the activator delegate
    /// </summary>
    private readonly Func<ResolutionContext, object> activator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DelegateActivator"/> class.
    /// </summary>
    /// <param name="activator">the delegate used for activation</param>
    public DelegateActivator(Func<ResolutionContext, object> activator)
    {
      if (activator == null)
      {
        throw new ArgumentNullException(nameof(activator), "invalid parameter on DelegateActivator constructor");
      }

      this.activator = activator;
    }

    /// <summary>
    /// Activate the object using the delegate
    /// </summary>
    /// <param name="context">the resolution context</param>
    /// <returns>the activated instance</returns>
    public object Activate(ResolutionContext context)
    {
      return this.activator(context);
    }
  }
}
