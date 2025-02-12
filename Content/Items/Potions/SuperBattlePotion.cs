using EvanMod.Common.Config;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace EvanMod.Content.Items.Potions
{
    public class SuperBattlePotion : GreaterBattlePotion
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.value = Item.sellPrice(0, 0, 12, 10);
            Item.buffType = BuffType<Buffs.SuperBattle>();
        }

        public override void AddRecipes()
        {
            if (GetInstance<ServerConfig>().BattlePotion.SuperMax > 1 || GetInstance<ServerConfig>().BattlePotion.SuperSpawnRate > 1)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.BottledWater, 1)
                    .AddIngredient(ItemID.Deathweed, 1)
                    .AddRecipeGroup("EvanMod:EvilPowder", 5)
                    .AddRecipeGroup("EvanMod:EvilGuts", 2)
                    .AddTile(TileID.Bottles)
                    .Register();
            }
        }
    }
}
