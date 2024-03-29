/**
*  @file      WarPotion.cs
*  @brief     Adds a 4x great-battle potion.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-27
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Potions
{
	public class WarPotion : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BattlePotion);
			Item.width = 20;
			Item.height = 28;
			Item.buffType = Mod.Find<ModBuff>("WarBuff").Type;
			base.SetDefaults();
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			if (player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, Utils.FrameTime(7, 0), false);
			}
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddRecipeGroup("EvanModpack:EvilPowder");
			recipe.AddRecipeGroup("EvanModpack:EvilGuts");
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}
