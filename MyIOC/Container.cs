// <copyright file="Container.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOC
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;
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
    /// collection of data type objects to use for resolving objects
    /// </summary>
    private Dictionary<string, object> dataRegistrations = new Dictionary<string, object>();

    /// <summary>
    /// register a new type
    /// </summary>
    /// <param name="type">the type to add</param>
    /// <param name="interfaceType">the interface type</param>
    /// <param name="lifetime">the lifetime type</param>
    /// <returns>the registration</returns>
    public Registration Register(Type type, Type interfaceType, Lifetime lifetime)
    {
      lock (locker)
      {
        Registration registration = new Registration(type, interfaceType, lifetime);
        this.registrations.Add(registration);
        return registration;
      }
    }

    /// <summary>
    /// register a value type
    /// </summary>
    /// <typeparam name="T">a value type</typeparam>
    /// <param name="name">the name of the data point</param>
    /// <param name="value">the data value</param>
    public void RegisterValue<T>(string name, T value)
    {
      this.dataRegistrations.Add(name, value);
    }

    /// <summary>
    /// syntacticly nice way
    /// </summary>
    /// <typeparam name="TypeToRegister">the concrete type</typeparam>
    /// <typeparam name="InterfaceType">the interface type to tie it to</typeparam>
    /// <param name="lifetime">the lifetime type, defaults to transient</param>
    /// <returns>the registration object</returns>
    public Registration Register<TypeToRegister, InterfaceType>(Lifetime lifetime = Lifetime.Transient)
    {
      return this.Register(typeof(TypeToRegister), typeof(InterfaceType), lifetime);
    }

    /// <summary>
    /// register a new type
    /// </summary>
    /// <typeparam name="T">the type to register</typeparam>
    /// <param name="implementation">implementation of the registered object</param>
    /// <returns>the registration object</returns>
    public Registration RegisterSingleton<T>(object implementation)
    {
      lock (locker)
      {
        Registration registration = new Registration(implementation, typeof(T));
        this.registrations.Add(registration);
        return registration;
      }
    }

    /// <summary>
    /// resolve the type
    /// </summary>
    /// <param name="type">the type</param>
    /// <returns>the created instance</returns>
    public object Resolve(Type type)
    {
      Registration registration = this.FindRegistration(type);
      return this.GetInstance(registration);
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
        Registration registration = this.registrations.FirstOrDefault(r => r.ConcreteType == type || r.InterfaceType == type);

        if (registration == null)
        {
          throw new TypeNotRegisteredException($"No relationship could be found for {type.ToString()}");
        }

        return registration;
      }
    }

    /// <summary>
    /// get the instance of the object from the registration
    /// </summary>
    /// <param name="registration">the registration</param>
    /// <returns>the instance</returns>
    private object GetInstance(Registration registration)
    {
      if (registration.ConcreteObject != null)
      {
        // the object was a singleton so return the cached object
        return registration.ConcreteObject;
      }

      ConstructorInfo ctor = registration.ConcreteType.GetConstructors()
                            .OrderByDescending(c => c.GetParameters().Length)
                            .First();

      var parameters = ctor.GetParameters();
      var args = new object[parameters.Length];
      for (int i = 0; i < args.Length; i++)
      {
        args[i] = this.GetArgData(parameters[i]);
      }

      object ret = ctor.Invoke(args);
      if (registration.ConcreteObject == null && registration.Lifetime == Lifetime.Singleton)
      {
        registration.ConcreteObject = ret;
      }

      return ret;
    }

    /// <summary>
    /// get the argument data
    /// </summary>
    /// <param name="parameter">the constructor parameter</param>
    /// <returns>the value for the constructor</returns>
    private object GetArgData(ParameterInfo parameter)
    {
      if (parameter.ParameterType.IsValueType || parameter.ParameterType.Name == "String")
      {
        object data;
        if (!this.dataRegistrations.TryGetValue(parameter.Name, out data))
        {
          throw new TypeNotRegisteredException($"No data value could be found for {parameter.Name}");
        }

        return data;
      }
      else
      {
        return this.Resolve(parameter.ParameterType);
      }
    }
  }
}
