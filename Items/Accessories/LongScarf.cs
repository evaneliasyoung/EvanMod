/**
*  @file      LongScarf.cs
*  @brief     Adds a cool long scarf vanity accessory.
*
*  @author    Evan Elias Young
*  @date      2020-04-27
*  @date      2020-04-27
*  @copyright Copyright 2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	internal class LongScarf : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 26;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = ItemRarityID.Pink;
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
			base.UpdateAccessory(player, hideVisual);
		}
	}
}
