using Terraria.ModLoader;

namespace EvanMod.Common.Systems
{
    public class ModIntegrationSystem : ModSystem
    {
        [JITWhenModsEnabled("HookStatsAndWingStats")]
        private static void SetupHookStatsAndWingStats()
        {
            var stats = new HookStatsAndWingStats.Helpers.HookStats(
                Content.Items.Tools.GemstoneHook.RANGE_IN_TILES * 16f,
                Content.Items.Tools.GemstoneHook.LAUNCH_SPEED,
                Content.Items.Tools.GemstoneHook.TOTAL_HOOKS,
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
