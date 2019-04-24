/**
*  @file      BlockOverrides.cs
*  @brief     Basic overrides for any of the blocks in the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-24
*  @date      2019-04-24
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Blocks
{
	internal class BlockOverrides : GlobalItem
	{
		/// <summary>
		/// Override the defaults from the base-game.
		/// </summary>
		/// <param name="item">The item to edit.</param>
		public override void SetDefaults(Item item)
		{
			switch (item.type)
			{
				case ItemID.GoldChest:
					ModRecipe recipe = new ModRecipe(mod);
					recipe.AddIngredient(ItemID.GoldBar, 8);
					recipe.AddIngredient(ItemID.IronBar, 2);
					recipe.AddTile(TileID.Anvils);
					recipe.AddRecipe();
					break;
			}
		}
	}
}