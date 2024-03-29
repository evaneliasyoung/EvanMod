/**
*  @file      AmberPhaseblade.cs
*  @brief     Adds a (superior) amber-colored phaseblade.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class AmberPhaseblade : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 78, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item15;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
