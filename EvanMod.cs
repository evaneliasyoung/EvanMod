/**
*  @file      EvanMod.cs
*  @brief     The main entry point for the modpack.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2020-04-08
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria.ModLoader;

namespace EvanMod
{
	internal class EvanMod : Mod
	{
		public static EvanMod Instance;

		public override void Load()
		{
			Instance = this;
		}

		public override void AddRecipeGroups()
		{
			RecipeOverrides.AddRecipeGroups();
		}

		public override void AddRecipes()
		{
			RecipeOverrides.AddAllRecipes();
		}

		#region Hamstar's Mod Helpers integration
		public static string GithubUserName => "evaneliasyoung";
		public static string GithubProjectName => "EvanMod";
		#endregion
	}
}
