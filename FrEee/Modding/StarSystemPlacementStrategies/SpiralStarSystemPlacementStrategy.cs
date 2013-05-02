﻿using FrEee.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FrEee.Modding.StarSystemPlacementStrategies
{
	/// <summary>
	/// Places stars clustered around the center of the galaxy.
	/// </summary>
	public class SpiralStarSystemPlacementStrategy : IStarSystemPlacementStrategy
	{
		public Point? PlaceStarSystem(Galaxy galaxy, int buffer, Rectangle bounds, int starsLeft)
		{
			var openPositions = bounds.GetAllPoints();
			foreach (var sspos in galaxy.StarSystemLocations.Keys)
				openPositions = openPositions.BlockOut(sspos, buffer);
			if (!openPositions.Any())
				return null;

			var r = new Random();

			// sort positions by distance to center
			var ordered = openPositions.OrderBy(p => p.ManhattanDistance(new Point(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2)));

			// place a star close to the center
			return ordered.First();
		}
	}
}
