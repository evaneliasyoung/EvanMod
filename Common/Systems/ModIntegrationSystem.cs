using Terraria.ModLoader;

namespace EvanMod.Common.Systems
{
    public class ModIntegrationSystem : ModSystem
    {
        [JITWhenModsEnabled("HookStatsAndWingStats")]
        private static void SetupHookStatsAndWingStats()
        {
            HookStatsAndWingStats.Common.Systems.HookSystem.AddModdedHook(
                ModContent.ItemType<Content.Items.Tools.GemstoneHook>(),
                Content.Items.Tools.GemstoneHook.RANGE_IN_TILES * 16f,
                Content.Items.Tools.GemstoneHook.LAUNCH_SPEED,
                Content.Items.Tools.GemstoneHook.TOTAL_HOOKS,
                (int)HookStatsAndWingStats.Core.Enums.HookLatchingType.Simultaneous
            );
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
