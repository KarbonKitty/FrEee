﻿using FrEee.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using FrEee.Game.Objects.Space;
using FrEee.Utility;
using FrEee.Utility.Extensions;
using FrEee.Modding.Interfaces;

namespace FrEee.Modding.StarSystemPlacementStrategies
{
	/// <summary>
	/// Places stars clustered around the center of the galaxy.
	/// </summary>
	 [Serializable] public class SpiralStarSystemPlacementStrategy : IStarSystemPlacementStrategy
	{
		public Point? PlaceStarSystem(Galaxy galaxy, int buffer, Rectangle bounds, int starsLeft)
		{
			var openPositions = bounds.GetAllPoints();
			foreach (var sspos in galaxy.StarSystemLocations.Select(sspos => sspos.Location))
				openPositions = openPositions.BlockOut(sspos, buffer);
			if (!openPositions.Any())
				return null;

			// sort positions by distance to center
			var ordered = openPositions.OrderBy(p => p.ManhattanDistance(new Point(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2)));

			if (RandomIntHelper.Next(2) == 0)
			{
				// place a star near the center
				return ordered.First();
			}
			else
			{
				// place a star off in the middle of nowhere
				return ordered.Last();
			}
		}
	}
}
