/**
*  @file      PureDiggingClaw.cs
*  @brief     Adds a fast, and far-superior alternate shroomite digging claw.
*
*  @author    Evan Elias Young
*  @date      2017-04-24
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Tools
{
	internal class PureDiggingClaw : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ShroomiteDiggingClaw);
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.width = 34;
			Item.height = 32;
			Item.value = Item.sellPrice(0, 4, 50, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.damage = 50;
			Item.pick = 220;
			Item.axe = 130 / 5;
			Item.tileBoost += 4;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteDiggingClaw);
			recipe.AddIngredient(ItemID.HallowedBar, 9);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
