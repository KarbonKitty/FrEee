using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Civilization;
using System.Collections.Generic;

#nullable enable

namespace FrEee.Game.Objects.Commands
{
	/// <summary>
	/// A command to create a new waypoint.
	/// </summary>
	public class CreateWaypointCommand : Command<Empire>
	{
		public CreateWaypointCommand(Waypoint waypoint)
			: base(Empire.Current)
		{
			Waypoint = waypoint;
		}

		/// <summary>
		/// A hotkey from zero to nine used to access this waypoint, or null to create a waypoint with no hotkey.
		/// </summary>
		public int? Hotkey { get; private set; }

		public override IEnumerable<IReferrable?> NewReferrables
		{
			get
			{
				foreach (var r in base.NewReferrables)
					yield return r;
				yield return Waypoint;
			}
		}

		/// <summary>
		/// The waypoint being created.
		/// </summary>
		public Waypoint Waypoint { get; set; }

		public override void Execute()
		{
			if (Executor != null && !Executor.Waypoints.Contains(Waypoint))
				Executor.Waypoints.Add(Waypoint); // add new waypoint
		}
	}
}
