using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using FrEee.Game.Objects.Space;
using FrEee.Game.Objects.Technology;
using FrEee.Game.Interfaces;
using FrEee.Modding.Templates;
using FrEee.Modding;
using FrEee.Utility.Extensions;
using System.Linq;
using FrEee.Game.Objects.Civilization;
using FrEee.Game.Objects.Combat;

namespace FrEee.Utility
{
	/// <summary>
	/// Utility methods for handling pictures.
	/// </summary>
	public static class Pictures
	{
		/// <summary>
		/// Picture cache for raw images on disk.
		/// </summary>
		private static IDictionary<string, Image> fileCache = new Dictionary<string, Image>();

		/// <summary>
		/// Picture cache for objects.
		/// </summary>
		private static IDictionary<object, Image> objectPortraits = new Dictionary<object, Image>();

		/// <summary>
		/// Generic pictures to use for space objects with missing pictures.
		/// </summary>
		private static IDictionary<Type, Image> genericPictures = new Dictionary<Type, Image>();

		static Pictures()
		{
			// Set up the generic images
			Image img;
			Graphics g;

			// TODO - moddable generic pics

			// star
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillEllipse(new SolidBrush(Color.Yellow), 10, 10, 108, 108);
			g.DrawEllipse(new Pen(Color.White, 3), 10, 10, 108, 108);
			genericPictures.Add(typeof(Star), img);

			// planet
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillEllipse(new SolidBrush(Color.Blue), 10, 10, 108, 108);
			g.DrawEllipse(new Pen(Color.White, 3), 10, 10, 108, 108);
			genericPictures.Add(typeof(Planet), img);

			// asteroid field
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillEllipse(new SolidBrush(Color.Gray), 10, 10, 25, 25);
			g.FillEllipse(new SolidBrush(Color.Gray), 45, 15, 25, 25);
			g.FillEllipse(new SolidBrush(Color.Gray), 75, 90, 25, 25);
			g.FillEllipse(new SolidBrush(Color.Gray), 30, 70, 25, 25);
			g.FillEllipse(new SolidBrush(Color.Gray), 15, 60, 25, 25);
			genericPictures.Add(typeof(AsteroidField), img);

			// storm
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.Clear(Color.Purple);
			genericPictures.Add(typeof(Storm), img);

			// warp point
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.DrawEllipse(new Pen(Color.Blue, 3), 10, 10, 108, 108);
			g.DrawEllipse(new Pen(Color.Blue, 3), 20, 20, 88, 88);
			g.DrawEllipse(new Pen(Color.Blue, 3), 30, 20, 68, 68);
			genericPictures.Add(typeof(WarpPoint), img);

			// facility
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillRectangle(new SolidBrush(Color.Silver), 10, 10, 108, 108);
			genericPictures.Add(typeof(FacilityTemplate), img);

			// component
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillEllipse(new SolidBrush(Color.Silver), 10, 10, 108, 108);
			genericPictures.Add(typeof(ComponentTemplate), img);

			// hull
			img = new Bitmap(128, 128);
			g = Graphics.FromImage(img);
			g.FillEllipse(new SolidBrush(Color.Silver), 40, 0, 68, 68);
			g.FillRectangle(new SolidBrush(Color.Silver), 50, 50, 10, 50);
			g.FillRectangle(new SolidBrush(Color.Silver), 88, 50, 10, 50);
			genericPictures.Add(typeof(IHull<IVehicle>), img);

			// TODO - mount, race, empire generic pics
		}

		/// <summary>
		/// Gets the icon image for a stellar object.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetIcon(StellarObject sobj)
		{
			var portrait = GetPortrait(sobj);
			if (portrait == null)
				return null;
			var img = portrait.GetThumbnailImage(32, 32, () => false, IntPtr.Zero);

			if (sobj is Planet)
			{
				var p = (Planet)sobj;
				if (p.Colony == null)
					p.DrawStatusIcons(img);
				else
					p.DrawPopulationBars(img);
			}

			return img;
		}

		/// <summary>
		/// Gets the portrait image for a stellar object.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetPortrait(StellarObject sobj)
		{
			if (!objectPortraits.ContainsKey(sobj))
			{
				if (sobj.PictureName == null)
					return GetGenericImage(sobj.GetType());

				Image portrait;
				if (Mod.Current.RootPath != null)
				{
					portrait =
						GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Planets", sobj.PictureName)) ??
						GetCachedImage(Path.Combine("Pictures", "Planets", sobj.PictureName)) ??
						GetGenericImage(sobj.GetType());
				}
				else
				{
					// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
					portrait =
						GetCachedImage(Path.Combine("Pictures", "Planets", sobj.PictureName)) ??
						GetGenericImage(sobj.GetType());
				}

				// clone the image so we don't mess up the original cached version
				portrait = (Image)portrait.Clone();

				objectPortraits.Add(sobj, portrait);
			}

			return objectPortraits[sobj];
		}

		/// <summary>
		/// Gets the icon image for a facility.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetIcon(FacilityTemplate f)
		{
			var portrait = GetPortrait(f);
			if (portrait == null)
				return null;
			// TODO - draw level roman numeral on the icon
			return portrait.GetThumbnailImage(32, 32, () => false, IntPtr.Zero);
		}

		/// <summary>
		/// Gets the portrait image for a facility.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetPortrait(FacilityTemplate f)
		{
			if (f.PictureName == null)
				return GetGenericImage(f.GetType());
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Facilities", f.PictureName)) ??
					GetCachedImage(Path.Combine("Pictures", "Facilities", f.PictureName)) ??
					GetGenericImage(f.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Facilities", f.PictureName)) ??
					GetGenericImage(f.GetType());
			}
		}

		/// <summary>
		/// Gets the icon image for a component.
		/// </summary>
		public static Image GetIcon(ComponentTemplate c)
		{
			var portrait = GetPortrait(c);
			if (portrait == null)
				return null;
			// TODO - draw level roman numeral on the icon
			return portrait.GetThumbnailImage(32, 32, () => false, IntPtr.Zero);
		}

		/// <summary>
		/// Gets the portrait image for a component.
		/// </summary>
		public static Image GetPortrait(ComponentTemplate c)
		{
			if (c.PictureName == null)
				return GetGenericImage(c.GetType());
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Components", c.PictureName)) ??
					GetCachedImage(Path.Combine("Pictures", "Components", c.PictureName)) ??
					GetGenericImage(c.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Components", c.PictureName)) ??
					GetGenericImage(c.GetType());
			}
		}

		/// <summary>
		/// Gets the icon image for a mount.
		/// </summary>
		public static Image GetIcon(Mount m)
		{
			var portrait = GetPortrait(m);
			if (portrait == null)
				return null;
			return portrait.GetThumbnailImage(32, 32, () => false, IntPtr.Zero);
		}

		/// <summary>
		/// Gets the portrait image for a mount.
		/// </summary>
		public static Image GetPortrait(Mount m)
		{
			if (m.PictureName == null)
				return GetGenericImage(m.GetType());
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Mounts", m.PictureName)) ??
					GetCachedImage(Path.Combine("Pictures", "Mounts", m.PictureName)) ??
					GetGenericImage(m.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Mounts", m.PictureName)) ??
					GetGenericImage(m.GetType());
			}
		}

		public static Image GetIcon(IHull<IVehicle> hull, string shipsetPath, int size = 32)
		{
			if (shipsetPath == null)
				return null;
			var paths = new List<string>();
			foreach (var s in hull.PictureNames)
			{
				if (Mod.Current.RootPath != null)
				{
					paths.Add(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Shipsets", shipsetPath, "Mini_" + s));
					paths.Add(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Shipsets", shipsetPath, shipsetPath + "_Mini_" + s)); // for SE4 shipset compatibility
				}
				paths.Add(Path.Combine("Pictures", "Shipsets", shipsetPath, "Mini_" + s));
				paths.Add(Path.Combine("Pictures", "Shipsets", shipsetPath, shipsetPath + "_Mini_" + s)); // for SE4 shipset compatibility
			}
			return (GetCachedImage(paths) ?? GetGenericImage(hull.GetType())).Resize(32);
		}

		public static Image GetPortrait(IHull<IVehicle> hull, string shipsetPath)
		{
			if (shipsetPath == null)
				return null;
			if (!hull.PictureNames.Any())
				return GetGenericImage(hull.GetType());
			var paths = new List<string>();
			foreach (var s in hull.PictureNames)
			{
				if (Mod.Current.RootPath != null)
				{
					paths.Add(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Shipsets", shipsetPath, "Portrait_" + s));
					paths.Add(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Shipsets", shipsetPath, shipsetPath + "_Portrait_" + s)); // for SE4 shipset compatibility
				}
				paths.Add(Path.Combine("Pictures", "Shipsets", shipsetPath, "Portrait_" + s));
				paths.Add(Path.Combine("Pictures", "Shipsets", shipsetPath, shipsetPath + "_Portrait_" + s)); // for SE4 shipset compatibility
			}
			return GetCachedImage(paths) ?? GetGenericImage(hull.GetType());
		}

		/// <summary>
		/// Gets the icon image for a resource.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetIcon(Resource res)
		{
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "UI", "Resources", res.PictureName)) ??
					GetCachedImage(Path.Combine("Pictures", "UI", "Resources", res.PictureName)) ??
					GetGenericImage(res.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "UI", "Resources", res.PictureName)) ??
					GetGenericImage(res.GetType());
			}
		}

		/// <summary>
		/// Gets the population icon image for a race.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetIcon(Race race)
		{
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Population", race.Name)) ??
					GetCachedImage(Path.Combine("Pictures", "Population", race.Name)) ??
					GetGenericImage(race.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Population", race.Name)) ??
					GetGenericImage(race.GetType());
			}
		}

		/// <summary>
		/// Gets the leader portrait image for a race.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetPortrait(Race race)
		{
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Leaders", race.Name)) ??
					GetCachedImage(Path.Combine("Pictures", "Leaders", race.Name)) ??
					GetGenericImage(race.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Leaders", race.Name)) ??
					GetGenericImage(race.GetType());
			}
		}

		/// <summary>
		/// Gets the insignia icon for an empire.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetIcon(Empire emp)
		{
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Insignia", emp.Name)) ??
					GetCachedImage(Path.Combine("Pictures", "Insignia", emp.Name)) ??
					GetSolidColorImage(emp.Color);
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Insignia", emp.Name)) ??
					GetSolidColorImage(emp.Color);
			}
		}

		/// <summary>
		/// Gets the leader portrait for an empire.
		/// </summary>
		/// <param name="sobj"></param>
		/// <returns></returns>
		public static Image GetPortrait(Empire emp)
		{
			if (Mod.Current.RootPath != null)
			{
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Leaders", emp.Name)) ??
					GetCachedImage(Path.Combine("Pictures", "Leaders", emp.Name)) ??
					GetGenericImage(emp.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				return
					GetCachedImage(Path.Combine("Pictures", "Leaders", emp.Name)) ??
					GetGenericImage(emp.GetType());
			}
		}

		public static Image GetIcon(Seeker seeker)
		{
			if (Mod.Current.RootPath != null)
			{
				var fx = (SeekerWeaponDisplayEffect)seeker.WeaponInfo.DisplayEffect;
				return
					GetCachedImage(Path.Combine("Mods", Mod.Current.RootPath, "Pictures", "Shipsets", seeker.Owner.ShipsetPath, fx.Name)) ??
					GetCachedImage(Path.Combine("Pictures", "Shipsets", seeker.Owner.ShipsetPath)) ??
					GetGenericImage(seeker.GetType());
			}
			else
			{
				// stock mod has no entry in Mods folder, and looking for a null path crashes Path.Combine
				var fx = (SeekerWeaponDisplayEffect)seeker.WeaponInfo.DisplayEffect;
				return
					GetCachedImage(Path.Combine("Pictures", "Shipsets", seeker.Owner.ShipsetPath, fx.Name)) ??
					GetGenericImage(seeker.GetType());
			}
		}

		public static Image GetCachedImage(IEnumerable<string> paths)
		{
			foreach (var path in paths)
			{
				var img = GetCachedImage(path);
				if (img != null)
					return img;
			}
			return null;
		}

		public static Image GetCachedImage(string path)
		{
			if (string.IsNullOrEmpty(Path.GetExtension(path)))
			{
				// check PNG, then BMP, if no extension specified
				return GetCachedImage(path + ".png") ?? GetCachedImage(path + ".bmp");
			}

			if (!fileCache.ContainsKey(path))
			{
				if (File.Exists(path))
				{
					try
					{
						fileCache[path] = Image.FromFile(path);
					}
					catch
					{
						// TODO - log missing images
						fileCache[path] = null;
					}
				}
				else
				{
					// TODO - log missing images
					fileCache[path] = null;
				}
			}
			return fileCache[path];
		}

		public static Image GetGenericImage(Type type)
		{
			if (genericPictures.ContainsKey(type))
				return genericPictures[type];
			else
			{
				// check base type and interfaces
				if (type.BaseType != null && genericPictures.ContainsKey(type.BaseType))
					return genericPictures[type.BaseType];

				foreach (var i in type.GetInterfaces())
				{
					if (genericPictures.ContainsKey(i))
						return genericPictures[i];
				}

				// yay recursion
				Image img = null;
				if (type.BaseType != null)
					img = GetGenericImage(type.BaseType);
				if (img != null)
					return img;
				foreach (var i in type.GetInterfaces())
				{
					img = GetGenericImage(i);
					if (img != null)
						return img;
				}
			}
			return null;
		}

		public static Image GetSolidColorImage(Color color)
		{
			var img = new Bitmap(1, 1);
			var g = Graphics.FromImage(img);
			g.Clear(color);
			return img;
		}
	}
}
