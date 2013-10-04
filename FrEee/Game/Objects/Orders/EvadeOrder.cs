﻿using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Space;
using FrEee.Game.Objects.Vehicles;
using FrEee.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrEee.Utility.Extensions;
using System.Drawing;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Enumerations;
using FrEee.Game.Objects.LogMessages;

namespace FrEee.Game.Objects.Orders
{
	/// <summary>
	/// An order to move a mobile space object away from another space object.
	/// The direction will be chosen at random
	/// </summary>
	[Serializable]
	public class EvadeOrder<T> : IMovementOrder<T>
		where T : ISpaceVehicle<T>, IReferrable
	{

		public EvadeOrder(ISpaceObject target, bool avoidEnemies)
		{
			Target = target;
			AvoidEnemies = avoidEnemies;
			// TODO - add flag for "avoid damaging sectors"? but how to specify in UI?
		}

		/// <summary>
		/// The target we are evading.
		/// </summary>
		[DoNotSerialize]
		public ISpaceObject Target { get { return target.Value; } set { target = value.Reference(); } }

		private Reference<ISpaceObject> target { get; set; }

		/// <summary>
		/// Should pathfinding avoid enemies?
		/// </summary>
		public bool AvoidEnemies { get; set; }

		/// <summary>
		/// Finds the path for executing this order.
		/// </summary>
		/// <param name="sobj">The space object executing the order.</param>
		/// <returns></returns>
		public IEnumerable<Sector> Pathfind(ISpaceVehicle me, Sector start)
		{
			if (Target is ISpaceVehicle)
			{
				if (me.CanWarp && !Target.CanWarp)
				{
					// warping via any warp point that leads outside the system should be safe, so prioritize those!
					var sys = me.FindStarSystem();
					var paths = sys.FindSpaceObjects<WarpPoint>().Flatten()
						.Where(wp => wp.TargetStarSystemLocation.Item != sys)
						.Select(wp => new { WarpPoint = wp, Path = Pathfinder.Pathfind(me, start, wp.FindSector(), AvoidEnemies, true, me.DijkstraMap) });
					if (paths.Any())
					{
						// found a warp point to flee to!
						var shortest = paths.WithMin(path => path.Path.Count()).PickRandom();
						return shortest.Path.Concat(new Sector[] { shortest.WarpPoint.Target });
					}
				}

				// see how he can reach us, and go somewhere away from him (that would take longer for him to get to than 
				var dijkstraMap = Pathfinder.CreateDijkstraMap((ISpaceVehicle)Target, Target.FindSector(), me.FindSector(), false, true);
				var canMoveTo = Pathfinder.GetPossibleMoves(me.FindSector(), me.CanWarp, me.Owner);
				var goodMoves = canMoveTo.Where(s => !dijkstraMap.Values.SelectMany(set => set).Any(n => n.Location == s));

				if (goodMoves.Any())
				{
					// just go there and recompute the path next time we can move - the enemy may have moved too
					return new Sector[] { goodMoves.PickRandom() };
				}
				else
				{
					// trapped...
					return Enumerable.Empty<Sector>();
				}
			}
			else
			{
				// target is immobile! no need to flee, unless it's in the same sector
				if (Target.FindSector() == me.FindSector())
				{
					// don't need to go through warp points to evade it, the warp points might be one way!
					var moves = Pathfinder.GetPossibleMoves(me.FindSector(), false, me.Owner);
					return new Sector[] { moves.PickRandom() };
				}
				else
					return Enumerable.Empty<Sector>();
			}
		}

		public void Execute(T sobj)
		{
			// TODO - movement logs
			if (sobj.CanWarp && !Target.CanWarp && sobj.FindStarSystem() != Target.FindStarSystem())
				IsComplete = true;
			else
			{
				var gotoSector = Pathfind(sobj, sobj.FindSector()).FirstOrDefault();
				if (gotoSector != null)
				{
					// move
					sobj.FindSector().Remove(sobj);
					gotoSector.Place(sobj);
					sobj.RefreshDijkstraMap();
				}
				else if (!LoggedPathfindingError)
				{
					// log pathfinding error
					sobj.Owner.Log.Add(sobj.CreateLogMessage(sobj + " could not evade " + Target + " because there is no available path available leading away from " + Target + "."));
					LoggedPathfindingError = true;
				}
			}

			// spend time
			sobj.SpendTime(sobj.TimePerMove);
		}

		public bool IsComplete
		{
			get;
			private set;
		}

		public override string ToString()
		{
			return "Evade " + Target;
		}

		/// <summary>
		/// Did we already log a pathfinding error this turn?
		/// </summary>
		[DoNotSerialize]
		public bool LoggedPathfindingError { get; private set; }

		public void Dispose()
		{
			// TODO - remove from queue, but we don't know which object we're on...
			Galaxy.Current.UnassignID(this);
		}

		private Reference<Empire> owner { get; set; }

		/// <summary>
		/// The empire which issued the order.
		/// </summary>
		[DoNotSerialize]
		public Empire Owner { get { return owner; } set { owner = value; } }

		/// <summary>
		/// Orders are visible only to their owners.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public Visibility CheckVisibility(Empire emp)
		{
			if (emp == Owner)
				return Visibility.Visible;
			return Visibility.Unknown;
		}

		public void ReplaceClientIDs(IDictionary<long, long> idmap)
		{
			// This type does not use client objects, so nothing to do here.
		}

		public long ID { get; set; }

		public Sector Destination
		{
			get { return Target.FindSector(); }
		}

		public IDictionary<PathfinderNode<Sector>, ISet<PathfinderNode<Sector>>> CreateDijkstraMap(ISpaceVehicle me, Sector start)
		{
			return Pathfinder.CreateDijkstraMap(me, start, Destination, AvoidEnemies, true);
		}

		public bool CheckCompletion(T v)
		{
			return IsComplete;
		}

		public IEnumerable<LogMessage> GetErrors(T v)
		{
			// this order doesn't error
			yield break;
		}
	}
}
