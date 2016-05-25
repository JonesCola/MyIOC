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
    /// <param name="interfaceType">the interface type</param>
    /// <param name="concreteObject">the type to register</param>
    public Registration(object concreteObject, Type interfaceType)
    {
      if (concreteObject == default(object))
      {
        throw new ArgumentNullException(nameof(concreteObject));
      }

      if (interfaceType == default(Type))
      {
        throw new ArgumentNullException(nameof(interfaceType));
      }

      this.InterfaceType = interfaceType;
      this.ConcreteObject = concreteObject;
      this.Lifetime = Lifetime.Singleton;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Registration"/> class.
    /// </summary>
    /// <param name="interfaceType">the interface type</param>
    /// <param name="concreteType">the type to register</param>
    public Registration(Type concreteType, Type interfaceType)
    {
      if (concreteType == default(object))
      {
        throw new ArgumentNullException(nameof(concreteType));
      }

      if (interfaceType == default(Type))
      {
        throw new ArgumentNullException(nameof(interfaceType));
      }

      this.InterfaceType = interfaceType;
      this.ConcreteType = concreteType;
      this.Lifetime = Lifetime.Transient;
    }

    /// <summary>
    /// Gets or sets the interface type
    /// </summary>
    public Type InterfaceType { get; set; }

    /// <summary>
    /// Gets the actual type
    /// </summary>
    public Type ConcreteType { get; private set; }

    /// <summary>
    /// Gets or sets the instance of the object
    /// </summary>
    public object ConcreteObject { get; set; }

    /// <summary>
    /// Gets the life-cycle tracking agent
    /// </summary>
    public Lifetime Lifetime { get; private set; }
  }
}
