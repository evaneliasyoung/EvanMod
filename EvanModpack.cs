/**
*  @file      EvanModpack.cs
*  @brief     The main entry point for the modpack.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack
{
	internal class EvanModpack : Mod
	{
		public EvanModpack()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}

		public override void AddRecipeGroups()
		{
			// Evil Powder Group
			RecipeGroup GroupPowder = new RecipeGroup(() => string.Format("{0} Evil Powder", Language.GetText("LegacyMisc.37").Value), new int[2]
			{
				ItemID.ViciousPowder,
				ItemID.VilePowder
			});
			RecipeGroup.RegisterGroup("EvanModpack:EvilPowder", GroupPowder);

			// Evil Guts Group
			RecipeGroup GroupGuts = new RecipeGroup(() => string.Format("{0} Evil Guts", Language.GetText("LegacyMisc.37").Value), new int[2]
			{
				ItemID.RottenChunk,
				ItemID.Vertebrae
			});
			RecipeGroup.RegisterGroup("EvanModpack:EvilGuts", GroupGuts);

			// Gem Group
			RecipeGroup GroupGem = new RecipeGroup(() => string.Format("{0} Gem", Language.GetText("LegacyMisc.37").Value), new int[6]
			{
				ItemID.Diamond,
				ItemID.Ruby,
				ItemID.Emerald,
				ItemID.Sapphire,
				ItemID.Topaz,
				ItemID.Amethyst
			});
			RecipeGroup.RegisterGroup("EvanModpack:GroupGem", GroupGem);
		}

		public override void AddRecipes()
		{
			// Life Fruit Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.ChlorophyteBar, 7);
				_.AddIngredient(ItemID.LifeCrystal, 1);
				_.AddTile(TileID.MythrilAnvil);
				_.SetResult(ItemID.LifeFruit);
				_.AddRecipe();
			});

			// Pad Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.Blinkroot, 2);
				_.AddIngredient(ItemID.RottenChunk, 2);
				_.AddTile(TileID.WorkBenches);
				_.SetResult(ItemID.PadThai, 5);
				_.AddRecipe();
			});

			// Pho Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.BottledWater, 5);
				_.AddIngredient(ItemID.Blinkroot, 2);
				_.AddIngredient(ItemID.RottenChunk, 2);
				_.AddTile(TileID.CookingPots);
				_.SetResult(ItemID.Pho, 5);
				_.AddRecipe();
			});

			// Black Belt Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.Tabi);
				_.AddTile(TileID.TinkerersWorkbench);
				_.SetResult(ItemID.BlackBelt);
				_.AddRecipe();
			});

			// Tabi Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.BlackBelt);
				_.AddTile(TileID.TinkerersWorkbench);
				_.SetResult(ItemID.Tabi);
				_.AddRecipe();
			});

			// Cascade Recipe
			new ModRecipe(this).With(_ =>
			{
				_.AddIngredient(ItemID.HellstoneBar, 12);
				_.AddTile(TileID.Anvils);
				_.SetResult(ItemID.Cascade);
				_.AddRecipe();
			});

			// Gems' Setup
			List<int> gems = new List<int> { ItemID.Diamond, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst };

			// Gems' Recipes
			gems.ForEach(gem =>
			{
				new ModRecipe(this).With(_ =>
				{
					_.AddRecipeGroup("EvanModpack:GroupGem", 1);
					_.AddTile(TileID.MythrilAnvil);
					_.SetResult(gem);
					_.AddRecipe();
				});
			});

			// Golden Critters' Setups
			Dictionary<int, int> mapCritters = new Dictionary<int, int>
			{
				{ ItemID.Bird, ItemID.GoldBird },
				{ ItemID.BlueJay, ItemID.GoldBird },
				{ ItemID.Cardinal, ItemID.GoldBird },
				{ ItemID.Bunny, ItemID.GoldBunny },
				{ ItemID.Frog, ItemID.GoldFrog },
				{ ItemID.Grasshopper, ItemID.GoldGrasshopper },
				{ ItemID.Mouse, ItemID.GoldMouse },
				{ ItemID.Squirrel, ItemID.SquirrelGold },
				{ ItemID.SquirrelRed, ItemID.SquirrelGold },
				{ ItemID.Worm, ItemID.GoldWorm }
			};

			// Golden Critters' Recipes
			foreach (KeyValuePair<int, int> oldNew in mapCritters)
			{
				new ModRecipe(this).With(_ =>
				{
					_.AddIngredient(ItemID.GoldBar, 2);
					_.AddIngredient(oldNew.Key);
					_.SetResult(oldNew.Value);
					_.AddRecipe();
				});
			}
		}
	}
}
