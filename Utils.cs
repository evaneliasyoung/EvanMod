/**
*  @file      Utils.cs
*  @brief     The utilities for the modpack.
*
*  @author    Evan Elias Young
*  @date      2019-04-16
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;

namespace EvanMod
{
	internal static class Utils
	{
		/// <summary>
		/// The original color for slag on the minimap.
		/// </summary>
		public static Color OriginalSlagColor = new Color(157, 56, 56);
		/// <summary>
		/// The new color for slag on the minimap.
		/// </summary>
		public static Color SlagColor = new Color(120, 30, 30);
		/// <summary>
		/// The bulk reveal size for the Traveller's Map.
		/// </summary>
		public static int MapRevealSize = 255;

		internal class ChatColors
		{
			/// <summary>
			/// The color for information chat messages.
			/// </summary>
			public static Color Info = Color.SpringGreen;
			/// <summary>
			/// The color for boss chat messages.
			/// </summary>
			public static Color Boss = Color.DarkOrchid;
			/// <summary>
			/// The color for party chat messages.
			/// </summary>
			public static Color Party = Color.MediumVioletRed;
			/// <summary>
			/// The color for death chat messages.
			/// </summary>
			public static Color Death = Color.Crimson;
		}

		/// <summary>
		/// Converts time in seconds to frames.
		/// </summary>
		/// <param name="seconds">The number of seconds.</param>
		/// <returns>The number of frames.</returns>
		public static int FrameTime(int seconds)
		{
			return seconds * 60;
		}

		/// <summary>
		/// Converts time in minutes and seconds to frames.
		/// </summary>
		/// <param name="minutes">The number of minutes.</param>
		/// <param name="seconds">The number of seconds.</param>
		/// <returns>The number of frames.</returns>
		public static int FrameTime(int minutes, int seconds)
		{
			return FrameTime(minutes * 60 + seconds);
		}
	}
}
