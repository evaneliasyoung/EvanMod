/**
*  @file      ButterflyKnife.cs
*  @brief     Adds a fast and deadly butterfly-knife.
*
*  @author    Evan Elias Young
*  @date      2017-07-17
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class ButterflyKnife : ModItem
	{
		public const int InstantKillChance = 1;

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 34;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 3;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(0, 0, 35, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.Next(1, 100) <= InstantKillChance)
			{
				Item.damage = 217500;
			}
			else
			{
				Item.damage = 18;
			}
			base.OnHitNPC(player, target, damage, knockBack, crit);
		}
	}
}
