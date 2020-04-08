/**
*  @file      RecipeOverrides.cs
*  @brief     Updates all the recipes in the base game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2020-04-08
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanMod
{
	internal static class RecipeOverrides
	{
		/// <summary>
		/// Creates new recipe groups.
		/// </summary>
		public static void AddRecipeGroups()
		{
			// Evil Powder Group
			RecipeGroup GroupPowder = new RecipeGroup(() => string.Format("{0} Evil Powder", Language.GetText("LegacyMisc.37").Value), new int[2]
			{
				ItemID.ViciousPowder,
				ItemID.VilePowder
			});
			RecipeGroup.RegisterGroup("EvanMod:EvilPowder", GroupPowder);

			// Evil Guts Group
			RecipeGroup GroupGuts = new RecipeGroup(() => string.Format("{0} Evil Guts", Language.GetText("LegacyMisc.37").Value), new int[2]
			{
				ItemID.RottenChunk,
				ItemID.Vertebrae
			});
			RecipeGroup.RegisterGroup("EvanMod:EvilGuts", GroupGuts);

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
			RecipeGroup.RegisterGroup("EvanMod:GroupGem", GroupGem);
		}

		/// <summary>
		/// Creates new food recipes.
		/// </summary>
		public static void AddFoodRecipes()
		{
			// Pad Thai Recipe
			ModRecipe padRecipe = new ModRecipe(EvanMod.Instance);
			padRecipe.AddIngredient(ItemID.Blinkroot, 2);
			padRecipe.AddIngredient(ItemID.RottenChunk, 2);
			padRecipe.AddTile(TileID.WorkBenches);
			padRecipe.SetResult(ItemID.PadThai, 5);
			padRecipe.AddRecipe();

			// Pho Recipe
			ModRecipe phoRecipe = new ModRecipe(EvanMod.Instance);
			phoRecipe.AddIngredient(ItemID.BottledWater, 5);
			phoRecipe.AddIngredient(ItemID.Blinkroot, 2);
			phoRecipe.AddIngredient(ItemID.RottenChunk, 2);
			phoRecipe.AddTile(TileID.CookingPots);
			phoRecipe.SetResult(ItemID.Pho, 5);
			phoRecipe.AddRecipe();
		}

		/// <summary>
		/// Creates new accessory recipes.
		/// </summary>
		public static void AddAccessoryRecipes()
		{
			// Black Belt Recipe
			ModRecipe blackBeltRecipe = new ModRecipe(EvanMod.Instance);
			blackBeltRecipe.AddIngredient(ItemID.Tabi);
			blackBeltRecipe.AddTile(TileID.TinkerersWorkbench);
			blackBeltRecipe.SetResult(ItemID.BlackBelt);
			blackBeltRecipe.AddRecipe();

			// Tabi Recipe
			ModRecipe tabiRecipe = new ModRecipe(EvanMod.Instance);
			tabiRecipe.AddIngredient(ItemID.BlackBelt);
			tabiRecipe.AddTile(TileID.TinkerersWorkbench);
			tabiRecipe.SetResult(ItemID.Tabi);
			tabiRecipe.AddRecipe();
		}

		/// <summary>
		/// Creates new weapon recipes.
		/// </summary>
		public static void AddWeaponRecipes()
		{
			// Cascade Recipe
			ModRecipe cascadeRecipe = new ModRecipe(EvanMod.Instance);
			cascadeRecipe.AddIngredient(ItemID.HellstoneBar, 12);
			cascadeRecipe.AddTile(TileID.Anvils);
			cascadeRecipe.SetResult(ItemID.Cascade);
			cascadeRecipe.AddRecipe();

			// Bone Wand Recipe
			ModRecipe wandRecipe = new ModRecipe(EvanMod.Instance);
			wandRecipe.AddIngredient(ItemID.Bone, 25);
			wandRecipe.AddTile(TileID.BoneWelder);
			wandRecipe.SetResult(ItemID.BoneWand);
			wandRecipe.AddRecipe();
		}

		/// <summary>
		/// Creates all other recipes.
		/// </summary>
		public static void AddMiscellaneousRecipes()
		{
			// Life Fruit Recipe
			ModRecipe lifeFruitRecipe = new ModRecipe(EvanMod.Instance);
			lifeFruitRecipe.AddIngredient(ItemID.ChlorophyteBar, 7);
			lifeFruitRecipe.AddIngredient(ItemID.LifeCrystal, 1);
			lifeFruitRecipe.AddTile(TileID.MythrilAnvil);
			lifeFruitRecipe.SetResult(ItemID.LifeFruit);
			lifeFruitRecipe.AddRecipe();

			// Gold Chest Recipe
			ModRecipe goldChestRecipe = new ModRecipe(EvanMod.Instance);
			goldChestRecipe.AddIngredient(ItemID.GoldBar, 8);
			goldChestRecipe.AddIngredient(ItemID.IronBar, 2);
			goldChestRecipe.AddTile(TileID.Anvils);
			goldChestRecipe.SetResult(ItemID.GoldChest);
			goldChestRecipe.AddRecipe();

			// Pirate Map Recipe
			ModRecipe pirateMapRecipe = new ModRecipe(EvanMod.Instance);
			pirateMapRecipe.AddIngredient(ItemID.Sail, 10);
			pirateMapRecipe.AddIngredient(ItemID.Cannonball);
			pirateMapRecipe.AddIngredient(ItemID.GoldBar, 5);
			pirateMapRecipe.AddTile(TileID.DemonAltar);
			pirateMapRecipe.SetResult(ItemID.PirateMap);
			pirateMapRecipe.AddRecipe();

			// Gems' Setup
			List<int> gems = new List<int> { ItemID.Diamond, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst };

			// Gems' Recipes
			gems.ForEach(gem =>
			{
				ModRecipe gemRecipe = new ModRecipe(EvanMod.Instance);
				gemRecipe.AddRecipeGroup("EvanMod:GroupGem", 1);
				gemRecipe.AddTile(TileID.MythrilAnvil);
				gemRecipe.SetResult(gem);
				gemRecipe.AddRecipe();
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
				ModRecipe critterRecipe = new ModRecipe(EvanMod.Instance);
				critterRecipe.AddIngredient(ItemID.GoldBar, 2);
				critterRecipe.AddIngredient(oldNew.Key);
				critterRecipe.SetResult(oldNew.Value);
				critterRecipe.AddRecipe();
			}
		}

		/// <summary>
		/// Creates all new recipes.
		/// </summary>
		public static void AddAllRecipes()
		{
			AddFoodRecipes();
			AddAccessoryRecipes();
			AddWeaponRecipes();
			AddMiscellaneousRecipes();
		}
	}
}
