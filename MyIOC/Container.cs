// <copyright file="Container.cs" company="Towers Watson">
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
  /// the container class holds my dependencies
  /// </summary>
  public class Container
  {
    /// <summary>
    /// my locking object
    /// </summary>
    private static object locker = new object();

    /// <summary>
    /// collection of registered dependencies
    /// </summary>
    private List<Registration> registrations = new List<Registration>();

    /// <summary>
    /// register a new type
    /// </summary>
    /// <param name="type">the type to add</param>
    /// <returns>the registration</returns>
    public Registration Register(Type type)
    {
      lock (locker)
      {
        Registration registration = new Registration(type);
        this.registrations.Add(registration);
        return registration;
      }
    }

    /// <summary>
    /// register a new type
    /// </summary>
    /// <typeparam name="T">the type to register</typeparam>
    /// <returns>the registration object</returns>
    public Registration Register<T>()
    {
      return this.Register(typeof(T));
    }

    /// <summary>
    /// resolve the type
    /// </summary>
    /// <param name="type">the type</param>
    /// <returns>the created instance</returns>
    public object Resolve(Type type)
    {
      Registration registration = this.FindRegistration(type);
      ResolutionContext context = new ResolutionContext(registration, this.FindRegistration);
      return context.GetInstance();
    }

    /// <summary>
    /// Resolve the type
    /// </summary>
    /// <typeparam name="T">the type</typeparam>
    /// <returns>the created type</returns>
    public T Resolve<T>()
    {
      return (T)this.Resolve(typeof(T));
    }

    /// <summary>
    /// find the registration of the given type
    /// </summary>
    /// <param name="type">the type to look for</param>
    /// <returns>the registration</returns>
    private Registration FindRegistration(Type type)
    {
      lock (locker)
      {
        Registration registration = this.registrations.FirstOrDefault(r => r.ConcreteType == type);
        if (registration == null)
        {
          registration = this.Register(type);
        }

      return registration;
      }
    }
  }
}
