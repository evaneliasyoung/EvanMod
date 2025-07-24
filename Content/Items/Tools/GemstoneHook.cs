using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Items.Tools
{
    public class GemstoneHook : ModItem
    {
        internal static float LAUNCH_SPEED = 11.25f;
        internal static float PULL_SPEED = 12f;
        internal static float REEL_SPEED = 11f;
        internal static float RANGE_IN_TILES = 23.625f;
        internal static int TOTAL_HOOKS = 6;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.DiamondHook);
            Item.shootSpeed = LAUNCH_SPEED;
            Item.value = Item.sellPrice(0, 2, 40, 0);
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<Content.Projectiles.Typeless.GemstoneHead>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AmethystHook)
                .AddIngredient(ItemID.TopazHook)
                .AddIngredient(ItemID.SapphireHook)
                .AddIngredient(ItemID.EmeraldHook)
                .AddIngredient(ItemID.RubyHook)
                .AddIngredient(ItemID.DiamondHook)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

}
