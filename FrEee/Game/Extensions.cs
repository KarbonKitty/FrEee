﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace FrEee.Game
{
	public static class Extensions
	{
		/// <summary>
		/// Clones an object.
		/// </summary>
		/// <typeparam name="T">The type of object to clone.</typeparam>
		/// <param name="obj">The object to clone.</param>
		/// <returns>The clone.</returns>
		public static T Clone<T>(this T obj) where T : new()
		{
			return Mapper.Map(obj, new T());
		}

		/// <summary>
		/// Finds the largest space object out of a group of space objects.
		/// Stars are the largest space objects, followed by planets, asteroid fields, storms, fleets, ships/bases, and finally unit groups.
		/// Within a category, space objects are sorted by size or tonnage as appropriate.
		/// </summary>
		/// <param name="objects">The group of space objects.</param>
		/// <returns>The largest space object.</returns>
		public static ISpaceObject Largest(this IEnumerable<ISpaceObject> objects)
		{
			if (objects.OfType<Star>().Any())
			{
				return objects.OfType<Star>().OrderByDescending(obj => obj.Size).First();
			}
			if (objects.OfType<Planet>().Any())
			{
				return objects.OfType<Planet>().OrderByDescending(obj => obj.Size).First();
			}
			if (objects.OfType<AsteroidField>().Any())
			{
				return objects.OfType<AsteroidField>().OrderByDescending(obj => obj.Size).First();
			}
			if (objects.OfType<Storm>().Any())
			{
				return objects.OfType<Storm>().OrderByDescending(obj => obj.Size).First();
			}
			if (objects.OfType<WarpPoint>().Any())
			{
				return objects.OfType<WarpPoint>().OrderByDescending(obj => obj.Size).First();
			}
			// TODO - fleets, ships/bases, unit groups
			return null;
		}
	}
}
