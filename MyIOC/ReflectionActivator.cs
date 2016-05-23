// <copyright file="ReflectionActivator.cs" company="Towers Watson">
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
  /// activates the dependency using reflection
  /// </summary>
  public class ReflectionActivator : IActivator
  {
    /// <summary>
    /// Activate the context
    /// </summary>
    /// <param name="context">the resolution activator</param>
    /// <returns>the instantiated object</returns>
    public object Activate(ResolutionContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException(nameof(context), "Invalid context passed into Activate method");
      }

      var ctor = context.Registration.ConcreteType.GetConstructors()
                      .OrderByDescending(c => c.GetParameters().Length)
                      .First();

      ParameterInfo[] parameters = ctor.GetParameters();
      var args = new object[parameters.Length];
      for (int i = 0; i < args.Length; i++)
      {
        args[i] = context.ResolveDependency(parameters[i].ParameterType);
      }

      return ctor?.Invoke(args);
    }
  }
}
