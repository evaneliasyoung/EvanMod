/**
*  @file      WeaponOverrides.cs
*  @brief     Basic overrides for any of the weapons in the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Weapons
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
				case ItemID.MagicDagger:
					item.autoReuse = true;
					break;
			}
		}

		/// <summary>
		/// Overrides the shoot mechanic from the base-game.
		/// </summary>
		/// <param name="item">The source of the bullet.</param>
		/// <param name="player">The player that shot the bullet.</param>
		/// <param name="position">The current position of the bullet.</param>
		/// <param name="speedX">The x-component of the speed.</param>
		/// <param name="speedY">The y-component of the speed.</param>
		/// <param name="type">The type of bullet.</param>
		/// <param name="damage">The base-damage from the bullet.</param>
		/// <param name="knockBack">The base-knockback from the bullet.</param>
		/// <returns>Whether the bullet was shot?</returns>
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			switch (item.type)
			{
				case ItemID.PhoenixBlaster:
					if (type == ProjectileID.Bullet)
					{ // Default musket balls, so make it a molten shot.
						type = mod.ProjectileType("MoltenShot");
					}
					break;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
