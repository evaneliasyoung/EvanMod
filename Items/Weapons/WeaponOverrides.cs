/**
*  @file      WeaponOverrides.cs
*  @brief     Basic overrides for any of the weapons in the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2019-04-20
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class WeaponOverrides : GlobalItem
	{
		/// <summary>
		/// Override the defaults from the base-game.
		/// </summary>
		/// <param name="item">The item to edit.</param>
		public override void SetDefaults(Item item)
		{
			switch (item.type)
			{
				case ItemID.PhoenixBlaster:
					item.knockBack = 7;
					item.autoReuse = true;
					item.value = Item.sellPrice(0, 2, 0, 0);
					break;
			}
		}
	}
}
