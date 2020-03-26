﻿/**
*  @file      GeorgePants.cs
*  @brief     Brings George's pants to the PC game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	internal class GeorgePants : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.White;
			item.defense = 0;
			base.SetDefaults();
		}
	}
}
