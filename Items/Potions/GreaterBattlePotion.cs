using EvanMod.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EvanMod.Items.Potions
{
    public class GreaterBattlePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BattlePotion);
            Item.width = 20;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 0, 2, 10);
            Item.buffType = BuffType<Buffs.GreaterBattle>();
        }

        public override bool? UseItem(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            if (GetInstance<ServerConfig>().BattlePotion.GreaterMax > 1 || GetInstance<ServerConfig>().BattlePotion.GreaterSpawnRate > 1)
            {
                CreateRecipe()
                    .AddIngredient(ItemID.BottledWater, 1)
                    .AddIngredient(ItemID.Deathweed, 1)
                    .AddRecipeGroup("EvanMod:EvilPowder")
                    .AddRecipeGroup("EvanMod:EvilGuts")
                    .AddTile(TileID.Bottles)
                    .Register();
            }
        }
    }
}
