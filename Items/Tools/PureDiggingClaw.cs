/**
*  @file      PureDiggingClaw.cs
*  @brief     Adds a fast, and far-superior alternate shroomite digging claw.
*
*  @author    Evan Elias Young
*  @date      2017-04-24
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class PureDiggingClaw : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pure Digging Claw");
			Tooltip.SetDefault("Purified from the darkest of evil");

			DisplayName.AddTranslation(GameCulture.Spanish, "Garra de cavando pura");
			Tooltip.AddTranslation(GameCulture.Spanish, "Purificado de lo más oscuro del mal");
			DisplayName.AddTranslation(GameCulture.German, "Reine Graben Klaue");
			Tooltip.AddTranslation(GameCulture.German, "Aus dem dunkelsten des Bösen gereinigt");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ShroomiteDiggingClaw);
			item.useAnimation = 10;
			item.useTime = 10;
			item.width = 34;
			item.height = 32;
			item.value = Item.sellPrice(0, 4, 50, 0);
			item.rare = 8;
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
