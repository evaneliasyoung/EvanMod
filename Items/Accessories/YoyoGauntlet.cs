using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Accessories
{
    class YoyoGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 180);
            modifiers.Knockback *= 1.8f;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) *= 1.15f;
            player.GetAttackSpeed(DamageClass.Melee) *= 1.15f;
            player.autoReuseGlove = true;
            player.meleeScaleGlove = true;
            player.kbGlove = true;
            player.magmaStone = true;
            player.yoyoGlove = true;
            player.yoyoString = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FireGauntlet)
                .AddIngredient(ItemID.YoyoBag)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
