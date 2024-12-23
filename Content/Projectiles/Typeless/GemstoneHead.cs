using System.Collections.Generic;
using EvanMod.Content.Items.Tools;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Projectiles.Typeless
{
    // The included texture should never be used, since the projectile is overridden with the builtin hooks.
    // However, the mod will not compile without a texture, so we include a placeholder texture.
    public class GemstoneHead : ModProjectile
    {
        /// <summary>
        /// This is used to keep track of which hooks are in use.
        /// </summary>
        private readonly Dictionary<int, bool> gemStoneHooks = new()
        {
            { ProjectileID.GemHookAmethyst, false },
            { ProjectileID.GemHookTopaz, false },
            { ProjectileID.GemHookSapphire, false },
            { ProjectileID.GemHookEmerald, false },
            { ProjectileID.GemHookRuby, false },
            { ProjectileID.GemHookDiamond, false }
        };

        /// <summary>
        /// This is used when all hooks are in use, so we use the hook after the most recent hook.
        /// </summary>
        /// <remarks>
        /// HACK: This is a simple way to keep track of the most recent hook, but it has potential issues.
        /// The amber hook would cause issues, since it's ID is not sequential with the other hooks.
        /// </remarks>
        private int mostRecentHook = -1;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookDiamond);
        }

        public override bool? CanUseGrapple(Player player)
        {
            // Clear the used hooks
            foreach (var hook in gemStoneHooks.Keys) gemStoneHooks[hook] = false;

            int hooksOut = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && gemStoneHooks.ContainsKey(Main.projectile[i].type))
                {
                    // Mark the hook as used
                    gemStoneHooks[Main.projectile[i].type] = true;
                    hooksOut++;
                }
            }
            return hooksOut <= GemstoneHook.TOTAL_HOOKS;
        }

        public override float GrappleRange() => GemstoneHook.RANGE_IN_TILES * 16f;


        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = GemstoneHook.TOTAL_HOOKS;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = GemstoneHook.REEL_SPEED;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = GemstoneHook.PULL_SPEED;
        }

        private int getNextHook()
        {
            // Try to use the first unused hook
            foreach (var hook in gemStoneHooks)
                if (!hook.Value) return hook.Key;

            // This should never happen, since we assign the most recent hook in UseGrapple
            if (mostRecentHook == -1) return ProjectileID.GemHookAmethyst;

            // If the most recent hook is the last hook index-wise, use the first hook (wrap around)
            if (mostRecentHook == ProjectileID.GemHookDiamond) return ProjectileID.GemHookAmethyst;

            // Otherwise, use the next hook, see HACK comment above for logic and potential issues
            return mostRecentHook + 1;
        }

        public override void UseGrapple(Player player, ref int type)
        {
            type = getNextHook();
            mostRecentHook = type;
            base.UseGrapple(player, ref type);
        }
    }
}
