using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Items.Placeable
{
    public class HellstoneExtractinator : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.HellstoneExtractinator>());
            Item.rare = ItemRarityID.Orange;
            Item.width = 34;
            Item.height = 38;
            Item.value = Item.sellPrice(0, 2, 0, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 18)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.ChlorophyteExtractinator)
                .AddIngredient<HellstoneExtractinator>()
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
