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
			ModRecipe lifeFruitRecipe = new ModRecipe(this);
			lifeFruitRecipe.AddIngredient(ItemID.ChlorophyteBar, 7);
			lifeFruitRecipe.AddIngredient(ItemID.LifeCrystal, 1);
			lifeFruitRecipe.AddTile(TileID.MythrilAnvil);
			lifeFruitRecipe.SetResult(ItemID.LifeFruit);
			lifeFruitRecipe.AddRecipe();

			// Pad Recipe
			ModRecipe padRecipe = new ModRecipe(this);
			padRecipe.AddIngredient(ItemID.Blinkroot, 2);
			padRecipe.AddIngredient(ItemID.RottenChunk, 2);
			padRecipe.AddTile(TileID.WorkBenches);
			padRecipe.SetResult(ItemID.PadThai, 5);
			padRecipe.AddRecipe();

			// Pho Recipe
			ModRecipe phoRecipe = new ModRecipe(this);
			phoRecipe.AddIngredient(ItemID.BottledWater, 5);
			phoRecipe.AddIngredient(ItemID.Blinkroot, 2);
			phoRecipe.AddIngredient(ItemID.RottenChunk, 2);
			phoRecipe.AddTile(TileID.CookingPots);
			phoRecipe.SetResult(ItemID.Pho, 5);
			phoRecipe.AddRecipe();

			// Black Belt Recipe
			ModRecipe blackBeltRecipe = new ModRecipe(this);
			blackBeltRecipe.AddIngredient(ItemID.Tabi);
			blackBeltRecipe.AddTile(TileID.TinkerersWorkbench);
			blackBeltRecipe.SetResult(ItemID.BlackBelt);
			blackBeltRecipe.AddRecipe();

			// Tabi Recipe
			ModRecipe tabiRecipe = new ModRecipe(this);
			tabiRecipe.AddIngredient(ItemID.BlackBelt);
			tabiRecipe.AddTile(TileID.TinkerersWorkbench);
			tabiRecipe.SetResult(ItemID.Tabi);
			tabiRecipe.AddRecipe();

			// Cascade Recipe
			ModRecipe cascadeRecipe = new ModRecipe(this);
			cascadeRecipe.AddIngredient(ItemID.HellstoneBar, 12);
			cascadeRecipe.AddTile(TileID.Anvils);
			cascadeRecipe.SetResult(ItemID.Cascade);
			cascadeRecipe.AddRecipe();

			// Gems' Setup
			List<int> gems = new List<int> { ItemID.Diamond, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst };

			// Gems' Recipes
			gems.ForEach(gem =>
			{
				ModRecipe gemRecipe = new ModRecipe(this);
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
				ModRecipe critterRecipe = new ModRecipe(this);
				critterRecipe.AddIngredient(ItemID.GoldBar, 2);
				critterRecipe.AddIngredient(oldNew.Key);
				critterRecipe.SetResult(oldNew.Value);
				critterRecipe.AddRecipe();
			}
		}
	}
}
