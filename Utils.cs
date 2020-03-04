/**
*  @file      Utils.cs
*  @brief     The utilities for the modpack.
*
*  @author    Evan Elias Young
*  @date      2019-04-16
*  @date      2020-03-04
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;

namespace EvanMod
{
	internal static class Utils
	{
		// Global Public Variables
		public static Color OriginalSlagColor = new Color(157, 56, 56);
		public static Color SlagColor = new Color(120, 30, 30);
		public static int MapRevealSize = 255;

		internal class ChatColors
		{
			public static Color Info = Color.SpringGreen;
			public static Color Boss = Color.DarkOrchid;
			public static Color Party = Color.MediumVioletRed;
			public static Color Death = Color.Crimson;
		}

		public static int FrameTime(int seconds)
		{
			return seconds * 60;
		}

		public static int FrameTime(int minutes, int seconds)
		{
			return FrameTime(minutes * 60 + seconds);
		}
	}
}
