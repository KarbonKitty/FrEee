﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FrEee.Game
{
	/// <summary>
	/// Utility methods for handling pictures.
	/// </summary>
	public static class Pictures
	{
		/// <summary>
		/// Until we have images to load
		/// </summary>
		private static Image fakeImage;

		static Pictures()
		{
			// Set up the fake image
			fakeImage = new Bitmap(128, 128);
			var g = Graphics.FromImage(fakeImage);
			g.DrawEllipse(new Pen(Color.White, 1), 0, 0, 128, 128);
			g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, 128, 128);
		}

		/// <summary>
		/// Gets the icon image for a stellar object.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static Image GetStellarObjectIcon(int number)
		{
			// TODO - implement GetStellarObjectIcon
			return fakeImage;
		}

		/// <summary>
		/// Gets the portrait image for a stellar object.
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static Image GetStellarObjectPortrait(int number)
		{
			// TODO - implement GetStellarObjectPortrait
			return fakeImage;
		}
	}
}
