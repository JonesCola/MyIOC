// <copyright file="IActivator.cs" company="Towers Watson">
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
    /// the activator interface
    /// </summary>
    public interface IActivator
    {
        /// <summary>
        /// activate the instance
        /// </summary>
        /// <param name="context">the resolution context</param>
        /// <returns>the activated object</returns>
        object Activate(ResolutionContext context);
    }
}
