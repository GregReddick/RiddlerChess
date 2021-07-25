// --------------------------------------------------------------------------------------------------
// <copyright file="Extensions.cs" company="Xoc Software">
// Copyright © 2021 Xoc Software
// </copyright>
// --------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>An extensions.</summary>
public static class Extensions
{
	/// <summary>An IList&lt;T&gt; extension method that makes a deep copy of this object.</summary>
	/// <typeparam name="T">Generic type parameter.</typeparam>
	/// <param name="listToClone">The listToClone to act on.</param>
	/// <returns>A copy of this object.</returns>
	public static IList<T> Clone<T>(this IList<T> listToClone)
		where T : ICloneable
	{
		return listToClone.Select(item => (T)item.Clone()).ToList();
	}
}