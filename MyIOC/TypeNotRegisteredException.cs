// <copyright file="TypeNotRegisteredException.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOC
{
  using System;
  using System.Runtime.Serialization;

  /// <summary>
  /// the type was not registered
  /// </summary>
  [Serializable]
  public class TypeNotRegisteredException : Exception
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TypeNotRegisteredException"/> class.
    /// </summary>
    public TypeNotRegisteredException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeNotRegisteredException"/> class.
    /// </summary>
    /// <param name="message">the error message</param>
    public TypeNotRegisteredException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TypeNotRegisteredException"/> class.
    /// </summary>
    /// <param name="message">the error message</param>
    /// <param name="innerException">the inner exception</param>
    public TypeNotRegisteredException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}