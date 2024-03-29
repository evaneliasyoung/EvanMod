/**
*  @file      GeorgeSuit.cs
*  @brief     Brings George's suit to the PC game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	internal class GeorgeSuit : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 0;
			base.SetDefaults();
		}
	}
}
