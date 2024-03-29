/**
*  @file      WeaponOverrides.cs
*  @brief     Basic overrides for any of the weapons in the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2019-05-11
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
				case ItemID.MagicDagger:
					item.autoReuse = true;
					break;
			}
		}

		public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			switch (item.type)
			{
				case ItemID.PhoenixBlaster:
					if (type == ProjectileID.Bullet)
					{
						type = Mod.Find<ModProjectile>("MoltenShot").Type;
					}
					break;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}
