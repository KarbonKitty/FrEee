﻿using FrEee.Game;
using FrEee.Game.Enumerations;
using FrEee.Game.Objects.Space;
using FrEee.Modding.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrEee.Modding.Loaders
{
	/// <summary>
	/// Loads stellar object templates from SectType.txt.
	/// </summary>
	 [Serializable] public class StellarObjectLoader : DataFileLoader
	{
		 public const string Filename = "SectType.txt";

		 public StellarObjectLoader(string modPath)
			 : base(Filename, DataFile.Load(modPath, Filename))
		{
		}

		public override void Load(Mod mod)
		{
			foreach (var rec in DataFile.Records)
			{
				StellarObject sobj;
				string temp, type;
				int index = -1;

				rec.TryFindFieldValue("Physical Type", out type, ref index, Mod.Errors, 0, true);
				if (type == "Star" || type == "Destroyed Star")
				{
					var star = new Star();
					sobj = star;

					rec.TryFindFieldValue(new string[]{"Size", "Star Size"}, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Size field for star.", Mod.CurrentFileName, rec));
						continue;
					}
					StellarSize size;
					if (Enum.TryParse<StellarSize>(temp, out size))
						star.StellarSize = size;
					else
						Mod.Errors.Add(new DataParsingException("Invalid star size. Must be Tiny, Small, Medium, Large, or Huge.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue(new string[] { "Age", "Star Age" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Age field for star.", Mod.CurrentFileName, rec));
						continue;
					}
					star.Age = temp;

					rec.TryFindFieldValue(new string[] { "Color", "Star Color" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Color field for star.", Mod.CurrentFileName, rec));
						continue;
					}
					star.Color = temp;

					rec.TryFindFieldValue(new string[] { "Luminosity", "Star Luminosity" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Luminosity field for star.", Mod.CurrentFileName, rec));
						continue;
					}
					star.Brightness = temp;

					if (type == "Destroyed Star")
						star.IsDestroyed = true;
				}
				else if (type == "Planet")
				{
					var planet = new Planet();
					sobj = planet;

					rec.TryFindFieldValue(new string[] { "Size", "Planet Size" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Size field for planet.", Mod.CurrentFileName, rec));
						continue;
					}
					StellarObjectSize size = Mod.Current.StellarObjectSizes.Where(sos => sos.StellarObjectType == "Planet" && sos.Name == temp).FirstOrDefault();
					if (size != null)
						planet.Size = size;
					else
						Mod.Errors.Add(new DataParsingException("Cannot find planet size entry " + temp + " in PlanetSize.txt.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue(new string[] { "Physical Type", "Planet Physical Type" }, out temp, ref index, Mod.Errors, 1, true); // skip the original Physical Type field which just says it's a planet
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Physical Type field for planet.", Mod.CurrentFileName, rec));
						continue;
					}
					planet.Surface = temp;

					rec.TryFindFieldValue(new string[] { "Atmosphere", "Planet Atmosphere" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Atmosphere field for planet.", Mod.CurrentFileName, rec));
						continue;
					}
					planet.Atmosphere = temp;
				}
				else if (type == "Asteroids")
				{
					var ast = new AsteroidField();
					sobj = ast;

					rec.TryFindFieldValue(new string[] { "Size", "Planet Size" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Size field for asteroids.", Mod.CurrentFileName, rec));
						continue;
					}
					StellarObjectSize size = Mod.Current.StellarObjectSizes.Where(sos => sos.StellarObjectType == "Asteroids" && sos.Name == temp).FirstOrDefault();
					if (size != null)
						ast.Size = size;
					else
						Mod.Errors.Add(new DataParsingException("Cannot find asteroids size entry " + temp + " in PlanetSize.txt.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue(new string[] { "Physical Type", "Planet Physical Type" }, out temp, ref index, Mod.Errors, 1, true); // skip the original Physical Type field which just says it's asteroids
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Physical Type field for asteroids.", Mod.CurrentFileName, rec));
						continue;
					}
					ast.Surface = temp;

					rec.TryFindFieldValue(new string[] { "Atmosphere", "Planet Atmosphere" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Atmosphere field for asteroids.", Mod.CurrentFileName, rec));
						continue;
					}
					ast.Atmosphere = temp;

					rec.TryFindFieldValue(new string[] { "Combat Tile" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Combat Tile field for asteroids.", Mod.CurrentFileName, rec));
						continue;
					}
					ast.CombatTile = temp;
				}
				else if (type == "Storm")
				{
					var storm = new Storm();
					sobj = storm;

					rec.TryFindFieldValue(new string[] { "Size", "Storm Size" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Size field for storm.", Mod.CurrentFileName, rec));
						continue;
					}
					StellarSize size;
					if (Enum.TryParse<StellarSize>(temp, out size))
						storm.StellarSize = size;
					else
						Mod.Errors.Add(new DataParsingException("Invalid storm size. Must be Tiny, Small, Medium, Large, or Huge.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue(new string[] { "Combat Tile" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Combat Tile field for storm.", Mod.CurrentFileName, rec));
						continue;
					}
					storm.CombatTile = temp;
				}
				else if (type == "Warp Point")
				{
					var wp = new WarpPoint();
					sobj = wp;

					rec.TryFindFieldValue(new string[] { "Size", "Warp Point Size" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Size field for warp point.", Mod.CurrentFileName, rec));
						continue;
					}
					StellarSize size;
					if (Enum.TryParse<StellarSize>(temp, out size))
						wp.StellarSize = size;
					else
						Mod.Errors.Add(new DataParsingException("Invalid warp point size. Must be Tiny, Small, Medium, Large, or Huge.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue(new string[] { "One-Way", "Warp Point One-Way" }, out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find One-Way field for warp point.", Mod.CurrentFileName, rec));
						continue;
					}
					bool oneway;
					if (bool.TryParse(temp, out oneway))
						wp.IsOneWay = oneway;
					else
						Mod.Errors.Add(new DataParsingException("Invalid value " + temp + " for warp point One-Way field. Must be true or false.", Mod.CurrentFileName, rec));

					rec.TryFindFieldValue( "Unusual", out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Unusual field for warp point.", Mod.CurrentFileName, rec));
						continue;
					}
					bool unusual;
					if (bool.TryParse(temp, out unusual))
						wp.IsUnusual = unusual;
					else
						Mod.Errors.Add(new DataParsingException("Invalid value " + temp + " for warp point Unusual field. Must be true or false.", Mod.CurrentFileName, rec));
				}
				else
				{
					Mod.Errors.Add(new DataParsingException("Invalid stellar object type: " + type + ".", Mod.CurrentFileName, rec));
					continue;
				}

				rec.TryFindFieldValue("Picture", out temp, ref index, null, 0, true); // ignore error for now, might use Picture Num
				if (temp == null)
				{
					rec.TryFindFieldValue("Picture Num", out temp, ref index, Mod.Errors, 0, true);
					if (temp == null)
					{
						Mod.Errors.Add(new DataParsingException("Could not find Picture field or Picture Num field.", Mod.CurrentFileName, rec));
						continue;
					}
					int pnum;
					if (!int.TryParse(temp, out pnum))
					{
						Mod.Errors.Add(new DataParsingException("Picture Num field was not an integer.", Mod.CurrentFileName, rec));
						continue;
					}
					sobj.PictureName = "p" + (pnum + 1).ToString("0000"); // to match SE4
				}
				else
					sobj.PictureName = temp;

				rec.TryFindFieldValue("Description", out temp, ref index, Mod.Errors, 0, true);
				sobj.Description = temp;

				mod.StellarObjectTemplates.Add(sobj);
			}
		}
	}
}
