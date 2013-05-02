﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FrEee
{
	public static class Extensions
	{
		private static Random rand = new Random();

		/// <summary>
		/// Adds SI prefixes to a value and rounds it off.
		/// e.g. 25000 becomes 25.00k
		/// </summary>
		/// <param name="value"></param>
		public static string ToUnitString(this int value)
		{
			if (Math.Abs(value) >= 1e13)
				return Math.Round(value / 1e12, 2) + "T";
			if (Math.Abs(value) >= 1e12)
				return Math.Round(value / 1e12, 3) + "T";
			if (Math.Abs(value) >= 1e10)
				return Math.Round(value / 1e9, 2) + "G";
			if (Math.Abs(value) >= 1e9)
				return Math.Round(value / 1e9, 3) + "G";
			if (Math.Abs(value) >= 1e7)
				return Math.Round(value / 1e6, 2) + "M";
			if (Math.Abs(value) >= 1e6)
				return Math.Round(value / 1e6, 3) + "M";
			if (Math.Abs(value) >= 1e4)
				return Math.Round(value / 1e3, 2) + "k";
			return value.ToString();
		}

		/// <summary>
		/// Picks a random element from a sequence.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="src"></param>
		/// <returns></returns>
		public static T PickRandom<T>(this IEnumerable<T> src)
		{
			return src.ElementAt(rand.Next(src.Count()));
		}

		/// <summary>
		/// Picks a random element from a weighted sequence.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="src"></param>
		/// <returns></returns>
		public static T PickWeighted<T>(this IDictionary<T, int> src)
		{
			var total = src.Sum(kvp => kvp.Value);
			var num = rand.Next(total);
			int sofar = 0;
			foreach (var kvp in src)
			{
				sofar += kvp.Value;
				if (num < sofar)
					return kvp.Key;
			}
			return default(T); // nothing to pick...
		}

		public static T MinOrDefault<T>(this IEnumerable<T> stuff)
		{
			if (!stuff.Any())
				return default(T);
			return stuff.Min();
		}

		public static TProp MinOrDefault<TItem, TProp>(this IEnumerable<TItem> stuff, Func<TItem, TProp> selector)
		{
			return stuff.Select(selector).MinOrDefault();
		}

		public static T MaxOrDefault<T>(this IEnumerable<T> stuff)
		{
			if (!stuff.Any())
				return default(T);
			return stuff.Max();
		}

		public static TProp MaxOrDefault<TItem, TProp>(this IEnumerable<TItem> stuff, Func<TItem, TProp> selector)
		{
			return stuff.Select(selector).MaxOrDefault();
		}

		public static T Find<T>(this IEnumerable<T> stuff, string name) where T : INamed
		{
			return stuff.FirstOrDefault(item => item.Name == name);
		}

		/// <summary>
		/// Gets the points on the border of a rectangle.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static IEnumerable<Point> GetBorderPoints(this Rectangle r)
		{
			for (var x = r.Left; x <= r.Right; x++)
			{
				if (x == r.Left || x == r.Right)
				{
					// get left and right sides
					for (var y = r.Top; y <= r.Bottom; y++)
						yield return new Point(x, y);
				}
				else
				{
					// just get top and bottom
					yield return new Point(x, r.Top);
					if (r.Top != r.Bottom)
						yield return new Point(x, r.Bottom);
				}
			}
		}

		/// <summary>
		/// Gets points in the interior of a rectangle.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static IEnumerable<Point> GetInteriorPoints(this Rectangle r)
		{
			for (var x = r.Left + 1; x < r.Right; x++)
			{
				for (var y = r.Top + 1; y < r.Bottom; y++)
					yield return new Point(x, y);
			}
		}

		/// <summary>
		/// Gets points both on the border and in the interior of a rectangle.
		/// </summary>
		/// <param name="r"></param>
		/// <returns></returns>
		public static IEnumerable<Point> GetAllPoints(this Rectangle r)
		{
			for (var x = r.Left; x <= r.Right; x++)
			{
				for (var y = r.Top; y <= r.Bottom; y++)
					yield return new Point(x, y);
			}
		}

		/// <summary>
		/// Computes the Manhattan (grid) distance between two points.
		/// </summary>
		/// <param name="p"></param>
		/// <param name="target"></param>
		/// <returns></returns>
		public static int ManhattanDistance(this Point p, Point target)
		{
			return Math.Abs(target.X - p.X) + Math.Abs(target.Y - p.Y);
		}

		/// <summary>
		/// Removes points within a certain Manhattan distance of a certain point.
		/// </summary>
		/// <param name="points">The points to start with.</param>
		/// <param name="center">The point to block out.</param>
		/// <param name="distance">The distance to block out from the center.</param>
		/// <returns>The points that are left.</returns>
		public static IEnumerable<Point> BlockOut(this IEnumerable<Point> points, Point center, int distance)
		{
			foreach (var p in points)
			{
				if (center.ManhattanDistance(p) > distance)
					yield return p;
			}
		}
	}
}
