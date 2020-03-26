/**
*  @file      MoltenShot.cs
*  @brief     Adds a flaming bullet to the game.
*
*  @author    Evan Elias Young
*  @date      2019-04-28
*  @date      2020-03-04
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Projectiles
{
	internal class MoltenShot : ModProjectile
	{
		/// <summary>
		/// Set the specific item data that does not change.
		/// </summary>
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Molten Shot");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.damage = 11;
			projectile.timeLeft = Utils.FrameTime(10);
			projectile.alpha = 255;
			projectile.light = 0.75f;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}

		/// <summary>
		/// Overrides the base-game's implementation of an npc hit.
		/// </summary>
		/// <param name="target">The npc receiving the hit.</param>
		/// <param name="damage">The base damage from the hit.</param>
		/// <param name="knockBack">The base knockback from the hit.</param>
		/// <param name="crit">Whehter or not the hit was a critical hit.</param>
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, Utils.FrameTime(9));
			base.OnHitNPC(target, damage, knockback, crit);
		}

		/// <summary>
		/// Handles the setup for drawing the bullet.
		/// </summary>
		/// <param name="spriteBatch">The sprite collection.</param>
		/// <param name="lightColor">The light effect's color.</param>
		/// <returns></returns>
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		/// <summary>
		/// Handles destroying the bullet.
		/// </summary>
		/// <param name="timeLeft">The time left in the bullet's life.</param>
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}
	}
}
