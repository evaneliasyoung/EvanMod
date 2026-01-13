using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Items.Typeless
{
    class PlatinumCoinRoll : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 0;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlatinumCoin, 100)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
