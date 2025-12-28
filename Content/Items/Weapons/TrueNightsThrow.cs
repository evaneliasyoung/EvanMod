using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Content.Items.Weapons
{
    public class TrueNightsThrow : ModItem
    {
        internal static readonly int DAMAGE = 80;
        internal static readonly float KNOCKBACK = 4.5f;
        internal static readonly int CRIT_CHANCE = 8;
        internal static readonly float SPIN_DURATION_IN_SECONDS = -1;
        internal static readonly float REACH_IN_TILES = 20f;
        internal static readonly float VELOCITY_IN_PPT = 16f;
        internal static readonly float TOP_VELOCITY_IN_PPI = 17f;

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

            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.TrueNightsThrowProjectile>();
            Item.shootSpeed = VELOCITY_IN_PPT;

            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 10);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<NightsThrow>())
                .AddIngredient(ItemID.SoulofSight, 20)
                .AddIngredient(ItemID.SoulofFright, 20)
                .AddIngredient(ItemID.SoulofMight, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
