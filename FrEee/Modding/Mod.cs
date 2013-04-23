﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FrEee.Game;
using System.Drawing;

namespace FrEee.Modding
{
	/// <summary>
	/// A set of data files containing templates for game objects.
	/// </summary>
	public class Mod
	{
		/// <summary>
		/// The currently loaded mod.
		/// </summary>
		public static Mod Current { get; private set; }

		/// <summary>
		/// The file name being loaded. (For error reporting)
		/// </summary>
		public static string CurrentFileName { get; private set; }

		/// <summary>
		/// Loads a mod.
		/// </summary>
		/// <param name="path">The mod root path, relative to the Mods folder.</param>
		/// <param name="setCurrent">Set the current mod to the new mod?</param>
		public static Mod Load(string path, bool setCurrent = true)
		{
			var mod = new Mod();

			CurrentFileName = Path.Combine("Mods", path, "Data", "SystemTypes.txt");
			mod.LoadStarSystemTemplates(new DataFile(File.ReadAllText(CurrentFileName)));

			CurrentFileName = null;

			if (setCurrent)
				Current = mod;
			return mod;
		}

		public Mod()
		{
			StarSystemTemplates = new Dictionary<string, StarSystemTemplate>();
		}

		/// <summary>
		/// Templates for star systems.
		/// </summary>
		public IDictionary<string, StarSystemTemplate> StarSystemTemplates { get; private set; }

		private IList<DataParsingException> errors = new List<DataParsingException>();

		/// <summary>
		/// Errors encountered when loading the mod.
		/// </summary>
		public IEnumerable<DataParsingException> Errors { get { return errors; } }

		/// <summary>
		/// Loads star system templates from SystemTypes.txt into this mod.
		/// </summary>
		/// <param name="df">SystemTypes.txt.</param>
		private void LoadStarSystemTemplates(DataFile df)
		{
			foreach (var rec in df.Records)
			{
				var sst = new StarSystemTemplate();
				string temp;
				int index = -1;

				rec.TryFindFieldValue("Name", out temp, ref index, errors);
				StarSystemTemplates.Add(temp, sst);

				rec.TryFindFieldValue("Description", out temp, ref index, errors);
				sst.Description = temp;

				rec.TryFindFieldValue("Background Bitmap", out temp, ref index, errors);
				sst.BackgroundImagePath = temp;

				rec.TryFindFieldValue("Empires Can Start In", out temp, ref index, errors);
				sst.EmpiresCanStartIn = bool.Parse(temp);

				rec.TryFindFieldValue("Non-Tiled Center Pic", out temp, ref index, errors);
				sst.NonTiledCenterCombatImage = bool.Parse(temp);

				foreach (var abil in LoadAbilities(rec))
					sst.Abilities.Add(abil);

				// TODO - load warp point stellar ability type

				int count = 0;
				int start = 0;
				while (true)
				{
					count++;
					string sobjtype;
					string pos;

					if (!rec.TryFindFieldValue("Obj " + count + " Physical Type", out temp, ref start, null, start))
					{
						if (!rec.TryFindFieldValue("Obj Physical Type", out temp, ref start, null, start))
							break; // couldn't load next stellar object template
						else
							sobjtype = temp;
					}
					else
						sobjtype = temp;
					start++;
					if (!rec.TryFindFieldValue("Obj " + count + " Position", out temp, ref start, null, start))
					{
						if (!rec.TryFindFieldValue("Obj Position", out temp, ref start, null, start))
						{
							errors.Add(new DataParsingException("Could not find \"Obj Position\" field.", CurrentFileName, rec));
							continue; // skip this stellar object
						}
						else
							pos = temp;
					}
					else
						pos = temp;
					start++;

					ITemplate<ISpaceObject> sobjTemplate;
					if (sobjtype == "Star")
					{
						var template = new StarTemplate();

						// TODO - load star abilities from StellarAbilityTypes.txt

						if (!rec.TryFindFieldValue("Obj " + count + " Size", out temp, ref start, null, start))
						{
							if (!rec.TryFindFieldValue("Obj Size", out temp, ref start, null, start))
							{
								errors.Add(new DataParsingException("Could not find \"Obj Size\" field for star.", CurrentFileName, rec));
								continue; // skip this stellar object
							}
							else
							{
								if (temp == "Any")
									template.Size = null;
								else
								{
									try
									{
										template.Size = (Game.Size)Enum.Parse(typeof(Game.Size), temp);
									}
									catch (ArgumentException ex)
									{
										errors.Add(new DataParsingException("Invalid stellar object size \"" + temp + "\". Must be Tiny, Small, Medium, Large, Huge, or Any.", ex, CurrentFileName, rec));
										continue; // skip this stellar object
									}
								}
							}
						}
						else
						{
							if (temp == "Any")
								template.Size = null;
							else
							{
								try
								{
									template.Size = (Game.Size)Enum.Parse(typeof(Game.Size), temp);
								}
								catch (ArgumentException ex)
								{
									errors.Add(new DataParsingException("Invalid stellar object size \"" + temp + "\". Must be Tiny, Small, Medium, Large, Huge, or Any.", ex, CurrentFileName, rec));
									continue; // skip this stellar object
								}
							}
						}
						start++;

						if (!rec.TryFindFieldValue("Obj " + count + " Age", out temp, ref start, null, start))
						{
							if (!rec.TryFindFieldValue("Obj Age", out temp, ref start, null, start))
							{
								errors.Add(new DataParsingException("Could not find \"Obj Age\" field for star.", CurrentFileName, rec));
								continue; // skip this stellar object
							}
							else
								template.Age = temp == "Any" ? null : temp;
						}
						else
							template.Age = temp == "Any" ? null : temp;
						start++;

						if (!rec.TryFindFieldValue("Obj " + count + " Color", out temp, ref start, null, start))
						{
							if (!rec.TryFindFieldValue("Obj Color", out temp, ref start, null, start))
							{
								errors.Add(new DataParsingException("Could not find \"Obj Color\" field for star.", CurrentFileName, rec));
								continue; // skip this stellar object
							}
							else
								template.Color = temp == "Any" ? null : temp;
						}
						else
							template.Color = temp == "Any" ? null : temp;
						start++;

						if (!rec.TryFindFieldValue("Obj " + count + " Luminosity", out temp, ref start, null, start))
						{
							if (!rec.TryFindFieldValue("Obj Luminosity", out temp, ref start, null, start))
							{
								errors.Add(new DataParsingException("Could not find \"Obj Luminosity\" field.", CurrentFileName, rec));
								continue; // skip this stellar object
							}
							else
								template.Brightness = temp == "Any" ? null : temp;
						}
						else
							template.Brightness = temp == "Any" ? null : temp;
						start++;

						sobjTemplate = template;
					}
					else if (sobjtype == "Planet")
					{
						var template = new Planet();
						// TODO - set planet attributes
						sobjTemplate = template;
					}
					else if (sobjtype == "Asteroids")
					{
						var template = new AsteroidField();
						// TODO - set asteroids attributes
						sobjTemplate = template;
					}
					else if (sobjtype == "Storm")
					{
						var template = new Storm();
						// TODO - set storm attributes
						sobjTemplate = template;
					}
					else
					{
						errors.Add(new DataParsingException("Invalid stellar object type \"" + sobjtype + "\". Must be Star, Planet, Asteroids, or Storm.", CurrentFileName, rec));
						continue;
					}

					if (pos.StartsWith("Ring "))
					{
						int ring;
						if (!int.TryParse(pos.Substring("Ring ".Length), out ring))
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected integer after Ring.", CurrentFileName, rec));
							continue;
						}
						sst.StellarObjectLocations.Add(new RingStellarObjectLocation { Ring = ring, StellarObjectTemplate = sobjTemplate });
					}
					else if (pos.StartsWith("Coord ") || pos.StartsWith("Centered Coord "))
					{
						int x, y;
						string coordsData;
						bool isCentered = pos.StartsWith("Centered Coord ");
						if (isCentered)
							coordsData = pos.Substring("Centered Coord ".Length);
						else
							coordsData = pos.Substring("Coord ".Length);
						var splitData = coordsData.Split(',');
						if (splitData.Length < 2)
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected two comma separated integers after Coord.", CurrentFileName, rec));
							continue;
						}
						if (!int.TryParse(splitData[0].Trim(), out x))
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected two comma separated integers after Coord.", CurrentFileName, rec));
							continue;
						}
						if (!int.TryParse(splitData[1].Trim(), out y))
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected two comma separated integers after Coord.", CurrentFileName, rec));
							continue;
						}
						sst.StellarObjectLocations.Add(new CoordStellarObjectLocation { Coordinates = new Point(x, y), UseCenteredCoordinates = isCentered, StellarObjectTemplate = sobjTemplate });
					}
					else if (pos.StartsWith("Same As"))
					{
						int idx;
						if (!int.TryParse(pos.Substring("Same As ".Length), out idx))
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected integer after Same As.", CurrentFileName, rec));
							continue;
						}
						if (idx > sst.StellarObjectLocations.Count)
						{
							errors.Add(new DataParsingException("A \"Same As\" stellar object location can reference only previously defined locations.", CurrentFileName, rec));
							continue;
						}
						sst.StellarObjectLocations.Add(new SameAsStellarObjectLocation { StarSystemTemplate = sst, TargetIndex = idx, StellarObjectTemplate = sobjTemplate });
					}
					else if (pos.StartsWith("Circle Radius "))
					{
						int radius;
						if (!int.TryParse(pos.Substring("Circle Radius ".Length), out radius))
						{
							errors.Add(new DataParsingException("Could not parse stellar object location \"" + pos + "\". Expected integer after Circle Radius.", CurrentFileName, rec));
							continue;
						}
						sst.StellarObjectLocations.Add(new CircleRadiusStellarObjectLocation { Radius = radius, StellarObjectTemplate = sobjTemplate });
					}
				}
			}
		}

		/// <summary>
		/// Loads abilities from a record.
		/// </summary>
		/// <param name="rec"></param>
		private IEnumerable<Ability> LoadAbilities(Record rec)
		{
			int count = 0;
			int start = 0;
			while (true)
			{
				count++;
				var abil = new Ability();
				string temp;

				if (!rec.TryFindFieldValue("Ability " + count + " Type", out temp, ref start, null, start))
				{
					if (!rec.TryFindFieldValue("Ability Type", out temp, ref start, null, start))
						yield break; // couldn't load next ability
					else
						abil.Name = temp;
				}
				else
					abil.Name = temp;
				start++;
				if (!rec.TryFindFieldValue("Ability " + count + " Descr", out temp, ref start, null, start))
				{
					if (!rec.TryFindFieldValue("Ability Descr", out temp, ref start, null, start))
						abil.Description = ""; // no description for this ability
					else
						abil.Description = temp;
				}
				else
					abil.Description = temp;
				start++;
				if (!rec.TryFindFieldValue("Ability " + count + " Val 1", out temp, ref start, null, start))
				{
					if (!rec.TryFindFieldValue("Ability Val", out temp, ref start, null, start))
						continue; // leave default values
					else
						abil.Values.Add(temp);
				}
				else
					abil.Values.Add(temp);
				start++;
				if (!rec.TryFindFieldValue("Ability " + count + " Val 2", out temp, ref start, null, start))
				{
					if (!rec.TryFindFieldValue("Ability Val", out temp, ref start, null, start))
						continue; // leave default values
					else
						abil.Values.Add(temp);
				}
				else
					abil.Values.Add(temp);
				start++;

				yield return abil;
			}
		}
	}
}
