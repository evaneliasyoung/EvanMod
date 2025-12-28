using System;
using EvanMod.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Projectiles.Melee
{
    public class TrueNightsThrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Type] = TrueNightsThrow.SPIN_DURATION_IN_SECONDS;
            ProjectileID.Sets.YoyosMaximumRange[Type] = TrueNightsThrow.REACH_IN_TILES * 16f;
            ProjectileID.Sets.YoyosTopSpeed[Type] = TrueNightsThrow.TOP_VELOCITY_IN_PPI;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.aiStyle = ProjAIStyleID.Yoyo;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(10))
            {
                int dust;

                if (Main.rand.NextBool(4))
                {
                    dust = Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.CursedTorch,
                        Scale: Main.rand.NextFloat(1.5f, 1.75f)
                    );
                }
                else if (Main.rand.NextBool(4))
                {
                    dust = Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Corruption,
                        Alpha: 128,
                        Scale: Main.rand.NextFloat(1.25f, 1.75f)
                    );
                }
                else
                {
                    dust = Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Shadowflame,
                        Scale: Main.rand.NextFloat(1.5f, 1.75f)
                    );
                }
                Main.dust[dust].noGravity = true;
            }

            Lighting.AddLight(Projectile.Center, 0.2f, 0.2f, 0.35f);
        }
    }
}
