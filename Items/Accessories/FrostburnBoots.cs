/**
*  @file      FrostburnBoots.cs
*  @brief     Adds a successor to the frostspark boots and lava waders.
*
*  @author    Evan Elias Young
*  @date      2019-05-30
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	internal class FrostburnBoots : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 28;
			item.value = Item.sellPrice(0, 12, 50, 0);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Updates the player's stats when the accessory is equipped.
		/// </summary>
		/// <param name="player">The player equipping the accessory.</param>
		/// <param name="hideVisual">Whether or not to hide the accessory.</param>
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 6.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.08f;
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += Utils.FrameTime(7);
			player.iceSkate = true;
			base.UpdateAccessory(player, hideVisual);
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
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
