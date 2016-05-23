// <copyright file="Registration.cs" company="Towers Watson">
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
  /// the registration class
  /// </summary>
  public class Registration
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Registration"/> class.
    /// </summary>
    /// <param name="concreteType">the type to register</param>
    public Registration(Type concreteType)
    {
      this.ConcreteType = concreteType;
      this.Activator = new ReflectionActivator();
      this.Lifetime = new TransientLifetime();
    }

    /// <summary>
    /// Gets the actual type
    /// </summary>
    public Type ConcreteType { get; private set; }

    /// <summary>
    /// Gets the activator
    /// </summary>
    public IActivator Activator { get; private set; }

    /// <summary>
    /// Gets the life-cycle tracking agent
    /// </summary>
    public ILifetime Lifetime { get; private set; }

    /// <summary>
    /// describes how to activate
    /// </summary>
    /// <param name="activator">the activator to use</param>
    /// <returns>the registration object</returns>
    public Registration ActivateWith(IActivator activator)
    {
      this.Activator = activator;
      return this;
    }

    /// <summary>
    /// describes how to activate
    /// </summary>
    /// <param name="activator">the activator delegate</param>
    /// <returns>the registration object</returns>
    public Registration ActivateWith(Func<ResolutionContext, object> activator)
    {
      this.Activator = new DelegateActivator(activator);
      return this;
    }

    /// <summary>
    /// register as a singleton
    /// </summary>
    /// <returns>the registration object</returns>
    public Registration Singleton()
    {
      this.Lifetime = new SingletonLifetime();
      return this;
    }

    /// <summary>
    /// register a transient
    /// </summary>
    /// <returns>returns the registration</returns>
    public Registration Transient()
    {
      this.Lifetime = new TransientLifetime();
      return this;
    }
  }
}
