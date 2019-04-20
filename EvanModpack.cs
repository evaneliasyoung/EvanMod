/**
*  @file      EvanModpack.cs
*  @brief     The main entry point for the modpack.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria.ModLoader;

namespace EvanModpack
{
	internal class EvanModpack : Mod
	{
		public static EvanModpack Instance;

		public override void Load()
		{
			Instance = this;
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
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
		public static string GithubProjectName => "EvanModpack";
		#endregion
	}
}
