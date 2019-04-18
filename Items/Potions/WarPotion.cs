/**
*  @file      WarPotion.cs
*  @brief     Adds a 4x great-battle potion.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Potions
{
	public class WarPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("War Potion");
			Tooltip.SetDefault("Considerably increases enemy spawn rate (4x)");

			DisplayName.AddTranslation(GameCulture.Spanish, "Poción de guerra");
			Tooltip.AddTranslation(GameCulture.Spanish, "Considerablemente aumenta tasa de spawn de enemigo.");
			DisplayName.AddTranslation(GameCulture.German, "Kriegstrank");
			Tooltip.AddTranslation(GameCulture.German, "Erhöht die Spawnrate von Gegnern deutlich (4x)");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BattlePotion);
			item.width = 20;
			item.height = 28;
			item.buffType = mod.BuffType("WarBuff");
			base.SetDefaults();
		}

		public override void UseStyle(Player player)
		{
			if (player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 4200, false);
			}
			base.UseStyle(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddRecipeGroup("EvanModpack:EvilPowder");
			recipe.AddRecipeGroup("EvanModpack:EvilGuts");
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
