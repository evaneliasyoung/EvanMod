/**
*  @file      RecipeOverrides.cs
*  @brief     Updates all the recipes in the base game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2019-05-08
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack
{
	internal static class RecipeOverrides
	{
		public static void AddRecipeGroups()
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

		public static void AddFoodRecipes()
		{
			// Pad Recipe
			ModRecipe padRecipe = new ModRecipe(EvanModpack.Instance);
			padRecipe.AddIngredient(ItemID.Blinkroot, 2);
			padRecipe.AddIngredient(ItemID.RottenChunk, 2);
			padRecipe.AddTile(TileID.WorkBenches);
			padRecipe.SetResult(ItemID.PadThai, 5);
			padRecipe.AddRecipe();

			// Pho Recipe
			ModRecipe phoRecipe = new ModRecipe(EvanModpack.Instance);
			phoRecipe.AddIngredient(ItemID.BottledWater, 5);
			phoRecipe.AddIngredient(ItemID.Blinkroot, 2);
			phoRecipe.AddIngredient(ItemID.RottenChunk, 2);
			phoRecipe.AddTile(TileID.CookingPots);
			phoRecipe.SetResult(ItemID.Pho, 5);
			phoRecipe.AddRecipe();
		}

		public static void AddAccessoryRecipes()
		{
			// Black Belt Recipe
			ModRecipe blackBeltRecipe = new ModRecipe(EvanModpack.Instance);
			blackBeltRecipe.AddIngredient(ItemID.Tabi);
			blackBeltRecipe.AddTile(TileID.TinkerersWorkbench);
			blackBeltRecipe.SetResult(ItemID.BlackBelt);
			blackBeltRecipe.AddRecipe();

			// Tabi Recipe
			ModRecipe tabiRecipe = new ModRecipe(EvanModpack.Instance);
			tabiRecipe.AddIngredient(ItemID.BlackBelt);
			tabiRecipe.AddTile(TileID.TinkerersWorkbench);
			tabiRecipe.SetResult(ItemID.Tabi);
			tabiRecipe.AddRecipe();
		}

		public static void AddWeaponRecipes()
		{
			// Cascade Recipe
			ModRecipe cascadeRecipe = new ModRecipe(EvanModpack.Instance);
			cascadeRecipe.AddIngredient(ItemID.HellstoneBar, 12);
			cascadeRecipe.AddTile(TileID.Anvils);
			cascadeRecipe.SetResult(ItemID.Cascade);
			cascadeRecipe.AddRecipe();

			// Bone Wand Recipe
			ModRecipe wandRecipe = new ModRecipe(EvanModpack.Instance);
			wandRecipe.AddIngredient(ItemID.Bone, 25);
			wandRecipe.AddTile(TileID.BoneWelder);
			wandRecipe.SetResult(ItemID.BoneWand);
			wandRecipe.AddRecipe();
		}

		public static void AddMiscellaneousRecipes()
		{
			// Life Fruit Recipe
			ModRecipe lifeFruitRecipe = new ModRecipe(EvanModpack.Instance);
			lifeFruitRecipe.AddIngredient(ItemID.ChlorophyteBar, 7);
			lifeFruitRecipe.AddIngredient(ItemID.LifeCrystal, 1);
			lifeFruitRecipe.AddTile(TileID.MythrilAnvil);
			lifeFruitRecipe.SetResult(ItemID.LifeFruit);
			lifeFruitRecipe.AddRecipe();

			// Gold Chest Recipe
			ModRecipe goldChestRecipe = new ModRecipe(EvanModpack.Instance);
			goldChestRecipe.AddIngredient(ItemID.GoldBar, 8);
			goldChestRecipe.AddIngredient(ItemID.IronBar, 2);
			goldChestRecipe.AddTile(TileID.Anvils);
			goldChestRecipe.SetResult(ItemID.GoldChest);
			goldChestRecipe.AddRecipe();

			// Pirate Map Recipe
			ModRecipe pirateMapRecipe = new ModRecipe(EvanModpack.Instance);
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
				ModRecipe gemRecipe = new ModRecipe(EvanModpack.Instance);
				gemRecipe.AddRecipeGroup("EvanModpack:GroupGem", 1);
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
				ModRecipe critterRecipe = new ModRecipe(EvanModpack.Instance);
				critterRecipe.AddIngredient(ItemID.GoldBar, 2);
				critterRecipe.AddIngredient(oldNew.Key);
				critterRecipe.SetResult(oldNew.Value);
				critterRecipe.AddRecipe();
			}
		}

		public static void AddAllRecipes()
		{
			AddFoodRecipes();
			AddAccessoryRecipes();
			AddWeaponRecipes();
			AddMiscellaneousRecipes();
		}
	}
}
