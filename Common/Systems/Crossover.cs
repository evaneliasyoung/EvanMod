using EvanMod.Content.Items.Tools;
using Terraria.ModLoader;

namespace EvanMod.Common.Systems
{
    public class Crossover : ModSystem
    {
        [JITWhenModsEnabled("HookStatsAndWingStats")]
        private static void SetupHookStatsAndWingStats()
        {
            var stats = new HookStatsAndWingStats.Helpers.HookStats(
                GemstoneHook.RANGE_IN_TILES * 16f,
                GemstoneHook.LAUNCH_SPEED,
                GemstoneHook.TOTAL_HOOKS,
                HookStatsAndWingStats.Helpers.Enums.HookLatchingType.Simultaneous
            );
            HookStatsAndWingStats.Common.Systems.HookSystem.HookStats.TryAdd("EvanMod:GemstoneHook", stats);
        }

        public override void PostSetupContent()
        {
            if (ModLoader.HasMod("HookStatsAndWingStats"))
            {
                SetupHookStatsAndWingStats();
            }
        }
    }
}
