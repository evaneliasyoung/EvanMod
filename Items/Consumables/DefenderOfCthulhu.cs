using EvanMod.Global;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EvanMod.Items.Consumables
{
    class DefenderOfCthulhu : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.expert = true;
            Item.rare = ItemRarityID.Expert;
            Item.value = Item.sellPrice(gold: 2);
            Item.useTime = 45;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item92;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.width = 26;
            Item.height = 28;
        }

        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<GlobalPlayer>().usedDoC)
            {
                return null;
            }

            player.GetModPlayer<GlobalPlayer>().usedDoC = true;
            return true;
        }

        public override void AddRecipes()
        {
            ItemID.Sets.ShimmerTransformToItem[ItemID.EoCShield] = ItemType<DefenderOfCthulhu>();
        }
    }
}
