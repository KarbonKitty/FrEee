﻿using FrEee.Game.Enumerations;
using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Space;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrEee.Modding
{
	/// <summary>
	/// A size of stellar objects from PlanetSize.txt.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public class StellarObjectSize : INamed
	{
		/// <summary>
		/// The name of this size.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Should be "Planet" or "Asteroids".
		/// </summary>
		public string StellarObjectType { get; set; }

		/// <summary>
		/// Stellar size of this size.
		/// </summary>
		public StellarSize StellarSize { get; set; }

		/// <summary>
		/// Maximum facilities for a colony.
		/// </summary>
		public int MaxFacilities { get; set; }

		/// <summary>
		/// Maximum population in millions for a colony.
		/// </summary>
		public int MaxPopulation { get; set; }

		/// <summary>
		/// Maximum kT cargo for a colony.
		/// </summary>
		public int MaxCargo { get; set; }

		/// <summary>
		/// Maximum facilities for a domed colony.
		/// </summary>
		public int MaxFacilitiesDomed { get; set; }

		/// <summary>
		/// Maximum population in millions for a domed colony.
		/// </summary>
		public int MaxPopulationDomed { get; set; }

		/// <summary>
		/// Maximum kT cargo for a domed colony.
		/// </summary>
		public int MaxCargoDomed { get; set; }

		/// <summary>
		/// Is this a constructed world?
		/// Constructed worlds should not appear in galaxy generation.
		/// </summary>
		public bool IsConstructed { get; set; }

		/// <summary>
		/// ID value for the ability on the component used to construct this world around a star.
		/// </summary>
		public string ConstructionAbilityID { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
