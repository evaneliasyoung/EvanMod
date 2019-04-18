/**
*  @file      PhoenixBlaster.cs
*  @brief     Adds the once-removed phoenix blaster.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class PhoenixBlaster : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.PhoenixBlaster)
			{
				item.knockBack = 7;
				item.autoReuse = true;
				item.value = Item.sellPrice(0, 2, 0, 0);
			}
			base.SetDefaults(item);
		}
	}
}
