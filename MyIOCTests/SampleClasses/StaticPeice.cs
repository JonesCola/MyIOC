// <copyright file="StaticPeice.cs" company="Towers Watson">
// Copyright (c) Towers Watson. All rights reserved.
// </copyright>

namespace MyIOCTests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// the static piece implementation
  /// </summary>
  public class StaticPeice : IStaticPiece
  {
    /// <summary>
    /// Gets or sets the static data value
    /// </summary>
    public string StaticCheck { get; set; } = "This is default";
  }
}
