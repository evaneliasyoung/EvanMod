/**
*  @file      WeaponOverrides.cs
*  @brief     Basic overrides for any of the weapons in the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2019-04-28
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
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

		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			switch (item.type)
			{
				case ItemID.PhoenixBlaster:
					if (type == ProjectileID.Bullet)
					{
						type = mod.ProjectileType("MoltenShot");
					}
					break;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
