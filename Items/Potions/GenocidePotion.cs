/**
*  @file      GenocidePotion.cs
*  @brief     Adds a 7x super-battle potion.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Potions
{
	internal class GenocidePotion : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BattlePotion);
			item.width = 20;
			item.height = 28;
			item.buffType = mod.BuffType("GenocideBuff");
			base.SetDefaults();
		}

		/// <summary>
		/// Adds the buff to the player using the potion.
		/// </summary>
		/// <param name="player">The player using the potion.</param>
		/// <returns>If the buff was added to the player.</returns>
		public override bool UseItem(Player player)
		{
			if (player.itemTime == 0)
			{
				player.AddBuff(item.buffType, Utils.FrameTime(7, 0), false);
			}
			return base.UseItem(player);
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddRecipeGroup("EvanMod:EvilPowder", 5);
			recipe.AddRecipeGroup("EvanMod:EvilGuts", 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
