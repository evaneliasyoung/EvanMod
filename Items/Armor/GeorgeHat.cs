/**
*  @file      GeorgeHat.cs
*  @brief     Brings George's hat to the PC game.
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
	[AutoloadEquip(EquipType.Head)]
	internal class GeorgeHat : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 14;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.White;
			item.defense = 0;
			base.SetDefaults();
		}
	}
}
