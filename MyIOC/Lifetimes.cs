// <copyright file="Lifetimes.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

/// <summary>
/// the different types of lifetimes
/// </summary>
public enum Lifetime
{
  /// <summary>
  /// the default is transient
  /// </summary>
  Transient = 1,

  /// <summary>
  /// there is only one implementation of this
  /// </summary>
  Singleton,
}