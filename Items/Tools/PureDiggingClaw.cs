/**
*  @file      PureDiggingClaw.cs
*  @brief     Adds a fast, and far-superior alternate shroomite digging claw.
*
*  @author    Evan Elias Young
*  @date      2017-04-24
*  @date      2020-03-04
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Tools
{
	internal class PureDiggingClaw : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ShroomiteDiggingClaw);
			item.useAnimation = 10;
			item.useTime = 10;
			item.width = 34;
			item.height = 32;
			item.value = Item.sellPrice(0, 4, 50, 0);
			item.rare = ItemRarityID.Yellow;
			item.damage = 50;
			item.pick = 220;
			item.axe = 130 / 5;
			item.tileBoost += 4;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteDiggingClaw);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
