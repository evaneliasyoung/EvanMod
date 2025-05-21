using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Common.GlobalProjectiles
{
    public class Hooks : GlobalProjectile
    {
        static readonly HashSet<int> gemStoneHooks = [
            ProjectileID.GemHookAmethyst,
            ProjectileID.GemHookTopaz,
            ProjectileID.GemHookSapphire,
            ProjectileID.GemHookEmerald,
            ProjectileID.GemHookRuby,
            ProjectileID.GemHookDiamond
        ];

        public override void NumGrappleHooks(Projectile projectile, Player player, ref int numHooks)
        {

            if (player.miscEquips[4].type == ModContent.ItemType<Content.Items.Tools.GemstoneHook>() && gemStoneHooks.Contains(projectile.type))
                numHooks = Content.Items.Tools.GemstoneHook.TOTAL_HOOKS;
            else
                base.NumGrappleHooks(projectile, player, ref numHooks);
        }
    }
}
