/**
*  @file      ModdedPlayer.cs
*  @brief     The wrapper for all custom effects on the player.
*
*  @author    Evan Elias Young
*  @date      2017-04-23
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack
{
	public class ModdedPlayer : ModPlayer
	{
		public bool allParticles = false;
		public override void MeleeEffects(Item item, Rectangle hitbox)
		{
			if (allParticles)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, player.velocity.X * 0.2f + player.direction * 3, player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
			}
			base.MeleeEffects(item, hitbox);
		}

		public override void ResetEffects()
		{
			allParticles = false;
			if (player.extraAccessory && !(Main.expertMode || Main.gameMenu))
			{
				player.extraAccessorySlots++;
			}
			base.ResetEffects();
		}

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item carrot = new Item();
			carrot.SetDefaults(ItemID.FuzzyCarrot);
			items.Add(carrot);
		}
	}
}
