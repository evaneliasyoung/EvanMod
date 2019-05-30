/**
*  @file      FrostburnBoots.cs
*  @brief     Adds successor to the frostspark boots and lava waders.
*
*  @author    Evan Elias Young
*  @date      2019-05-30
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Accessories
{
	class FrostburnBoots : ModItem
	{
		public override void SetDefaults()
		{
			//item.width = 26;
			//item.height = 30;
			item.value = Item.sellPrice(0, 12, 50, 0);
			item.rare = 8;
			item.accessory = true;
			base.SetDefaults();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.waterWalk2 = true;
			player.fireWalk = true;
			base.UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(ItemID.LavaWaders);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
			base.AddRecipes();
		}
	}
}
