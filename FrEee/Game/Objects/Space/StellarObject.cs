using FrEee.Game.Enumerations;
using FrEee.Game.Interfaces;
using FrEee.Game.Objects.Abilities;
using FrEee.Game.Objects.Civilization;
using FrEee.Modding;
using FrEee.Utility;
using FrEee.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

#nullable enable

namespace FrEee.Game.Objects.Space
{
	/// <summary>
	/// A (typically) naturally occurring, large, immobile space object.
	/// </summary>
	[Serializable]
	public abstract class StellarObject : IStellarObject, IAbstractDataObject
	{
		public StellarObject()
		{
			IntrinsicAbilities = new List<Ability>();
			StoredResources = new ResourceQuantity();
		}

		// TODO - rename to IntrinsicAbilities in IAbilityContainer and remove DoNotSerialize
		[DoNotSerialize]
		public IList<Ability> Abilities
		{
			get => IntrinsicAbilities;
			set => IntrinsicAbilities = value;
		}

		public abstract AbilityTargets AbilityTarget { get; }

		public virtual bool CanBeInFleet => false;

		public abstract bool CanBeObscured { get; }

		/// <summary>
		/// Stellar objects can't normally warp.
		/// </summary>
		public virtual bool CanWarp => false;

		public virtual IEnumerable<IAbilityObject> Children
		{
			get { yield break; }
		}

		public virtual ConstructionQueue? ConstructionQueue => null;

		public virtual SafeDictionary<string, object> Data
		{
			get
			{
				var dict = new SafeDictionary<string, object>();
				dict[nameof(Index)] = Index;
				dict[nameof(IsUnique)] = IsUnique;
				dict[nameof(Name)] = Name;
				dict[nameof(Description)] = Description;
				dict[nameof(PictureName)] = PictureName;
				dict[nameof(IntrinsicAbilities)] = IntrinsicAbilities;
				dict[nameof(StellarSize)] = StellarSize;
				dict[nameof(ID)] = ID;
				dict[nameof(IsMemory)] = IsMemory;
				dict[nameof(Timestamp)] = Timestamp;
				dict[nameof(ModID)] = ModID;
				dict[nameof(StoredResources)] = StoredResources;
				return dict;
			}
			set
			{
				Index = value[nameof(Index)].Default<int>();
				IsUnique = value[nameof(IsUnique)].Default<bool>();
				Name = value[nameof(Name)].Default<string>();
				Description = value[nameof(Description)].Default<string>();
				PictureName = value[nameof(PictureName)].Default<string>();
				IntrinsicAbilities = value[nameof(IntrinsicAbilities)].Default(new List<Ability>());
				StellarSize = value[nameof(StellarSize)].Default<StellarSize>();
				ID = value[nameof(ID)].Default<long>();
				IsMemory = value[nameof(IsMemory)].Default<bool>();
				Timestamp = value[nameof(Timestamp)].Default<double>();
				ModID = value[nameof(ModID)].Default<string>();
				StoredResources = value[nameof(StoredResources)].Default(new ResourceQuantity());
			}
		}

		/// <summary>
		/// A description of this stellar object.
		/// </summary>
		public string? Description { get; set; }

		public bool HasInfiniteSupplies => this.HasAbility("Quantum Reactor");

		public virtual Image Icon => Pictures.GetIcon(this);

		public Image Icon32 => Icon.Resize(32);

		public IEnumerable<string> IconPaths => PortraitPaths;

		public long ID { get; set; }

		/// <summary>
		/// Used for naming.
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// Abilities intrinsic to this stellar object.
		/// </summary>
		public IList<Ability> IntrinsicAbilities { get; private set; }

		IEnumerable<Ability> IAbilityObject.IntrinsicAbilities => IntrinsicAbilities;

		public bool IsDisposed { get; set; }

		/// <summary>
		/// Stellar objects by default can't be idle, because they can't take orders or build stuff to begin with.
		/// </summary>
		public virtual bool IsIdle => false;

		public bool IsMemory { get; set; }

		/// <summary>
		/// Used for naming.
		/// </summary>
		public bool IsUnique { get; set; }

		public string? ModID { get; set; }

		/// <summary>
		/// The name of this stellar object.
		/// </summary>
		public string? Name { get; set; }

		Empire? IOwnable.Owner => null;

		public virtual IEnumerable<IAbilityObject> Parents
		{
			get
			{
				if (!(Sector is null))
					yield return Sector;
			}
		}

		/// <summary>
		/// Name of the picture used to represent this stellar object, excluding the file extension.
		/// PNG files will be searched first, then BMP.
		/// </summary>
		public string? PictureName { get; set; }

		[DoNotSerialize]
		public Image Portrait => Pictures.GetPortrait(this);

		public IEnumerable<string> PortraitPaths
		{
			get
			{
				if (Mod.Current.RootPath != null)
					yield return Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Planets", PictureName ?? string.Empty);
				yield return Path.Combine("Pictures", "Planets", PictureName ?? string.Empty);
			}
		}

		[DoNotCopy(false)]
		public virtual Sector? Sector
		{
			get
			{
				if (sector is null)
					sector = this.FindSector();
				return sector;
			}
			set
			{
				var oldsector = sector;
				sector = value;
				if (value is null)
				{
					if (oldsector != null)
						oldsector.Remove(this);
				}
				else
				{
					if (oldsector != value)
						value.Place(this);
				}
			}
		}

		public StarSystem? StarSystem => Sector?.StarSystem;

		public StellarSize StellarSize { get; set; }

		/// <summary>
		/// Resources stored on this stellar object.
		/// </summary>
		public ResourceQuantity StoredResources { get; private set; }

		public int SupplyStorage => this.GetAbilityValue("Supply Storage").ToInt();

		/// <summary>
		/// Parameters from the mod meta templates.
		/// </summary>
		public IDictionary<string, object>? TemplateParameters { get; set; }

		public double Timestamp { get; set; }
		private Sector? sector;

		public Visibility CheckVisibility(Empire emp)
		{
			if ((Sector is null || StarSystem == null) && Mod.Current.StellarObjectTemplates.Contains(this))
				return Visibility.Scanned; // can always see the mod

			return this.CheckSpaceObjectVisibility(emp);
		}

		public virtual void Dispose()
		{
			if (IsDisposed)
				return;
			var sys = this.FindStarSystem();
			if (sys != null)
				sys.Remove(this);
			Galaxy.Current.UnassignID(this);
			if (!IsMemory)
				this.UpdateEmpireMemories();
		}

		/// <summary>
		/// Stellar objects don't typically have owners, so they can't usually be hostile.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public virtual bool IsHostileTo(Empire emp) => false;

		public bool IsObsoleteMemory(Empire emp)
		{
			if (StarSystem == null)
				return Timestamp < Galaxy.Current.Timestamp - 1;
			return StarSystem.CheckVisibility(emp) >= Visibility.Visible && Timestamp < Galaxy.Current.Timestamp - 1;
		}

		/// <summary>
		/// Removes any data from this stellar object that the specified empire should not see.
		/// Disposes of the stellar object if it is invisible to the empire.
		/// </summary>
		/// <param name="emp"></param>
		public virtual void Redact(Empire emp)
		{
			var vis = CheckVisibility(emp);
			if (vis < Visibility.Fogged || vis < Visibility.Visible && !IsMemory)
				Dispose();
		}

		public override string ToString() => Name ?? string.Empty;
	}
}
