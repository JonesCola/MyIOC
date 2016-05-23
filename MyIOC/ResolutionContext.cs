// <copyright file="ResolutionContext.cs" company="Towers Watson">
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
  /// hold the context resolution object
  /// </summary>
  public class ResolutionContext
  {
    /// <summary>
    /// the registration finder
    /// </summary>
    private readonly Func<Type, Registration> registrationFinder;

    /// <summary>
    /// the parent (used to check for cyclic dependencies)
    /// </summary>
    private ResolutionContext parent;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResolutionContext"/> class.
    /// </summary>
    /// <param name="registration">the registration</param>
    /// <param name="registrationFinder">describes how to find the registration</param>
    public ResolutionContext(Registration registration, Func<Type, Registration> registrationFinder)
    {
      this.Registration = registration;
      this.registrationFinder = registrationFinder;
    }

    /// <summary>
    /// Gets the registration instance
    /// </summary>
    public Registration Registration { get; private set; }

    /// <summary>
    /// activate this object
    /// </summary>
    /// <returns>the activated dependency</returns>
    public object Activate()
    {
      return this.Registration.Activator.Activate(this);
    }

    /// <summary>
    /// get the activated instance
    /// </summary>
    /// <returns>the instance</returns>
    public object GetInstance()
    {
      return this.Registration?.Lifetime?.GetInstnce(this);
    }

    /// <summary>
    /// Resolve the dependency
    /// </summary>
    /// <param name="type">the type to resolve</param>
    /// <returns>the activated dependency</returns>
    public object ResolveDependency(Type type)
    {
      var registration = this.registrationFinder(type);
      ResolutionContext context = new ResolutionContext(registration, this.registrationFinder);
      context.CheckForCyclicalRefences(this);
      return context.GetInstance();
    }

    /// <summary>
    /// syntacticly nice way to do this
    /// </summary>
    /// <typeparam name="T">the type to resolve</typeparam>
    /// <returns>the activated dependency</returns>
    public T ResolveDependency<T>()
    {
      return (T)this.ResolveDependency(typeof(T));
    }

    /// <summary>
    /// check for cyclical references
    /// </summary>
    /// <param name="parent">the parent context</param>
    private void CheckForCyclicalRefences(ResolutionContext parent)
    {
      this.parent = parent;
      while (parent != null)
      {
        if (ReferenceEquals(this.Registration, parent.Registration))
        {
          throw new Exception("Cyclical references found");
        }

        parent = parent.parent;
      }
    }
  }
}
