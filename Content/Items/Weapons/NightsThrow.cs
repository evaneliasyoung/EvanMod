using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Items.Weapons
{
    public class NightsThrow : ModItem
    {
        internal static readonly int DAMAGE = 36;
        internal static readonly float KNOCKBACK = 4.5f;
        internal static readonly int CRIT_CHANCE = 4;
        internal static readonly float SPIN_DURATION_IN_SECONDS = 15;
        internal static readonly float REACH_IN_TILES = 16f;
        internal static readonly float VELOCITY_IN_PPT = 16f;
        internal static readonly float TOP_VELOCITY_IN_PPI = 13f;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
            ItemID.Sets.Yoyo[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;

            Item.DamageType = DamageClass.Melee;
            Item.damage = DAMAGE;
            Item.knockBack = KNOCKBACK;
            Item.crit = CRIT_CHANCE;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.NightsThrowProjectile>();
            Item.shootSpeed = VELOCITY_IN_PPT;

            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 4);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Cascade)
                .AddIngredient(ItemID.JungleYoyo)
                .AddRecipeGroup("EvanMod:EvilYoyos")
                .AddIngredient(ItemID.Valor)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
