/**
*  @file      AmberPhasesaber.cs
*  @brief     Adds a (superior) amber-colored phasesaber.
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
	internal class AmberPhasesaber : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 78, 0);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item15;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.GetItem("AmberPhaseblade"));
			recipe.AddIngredient(ItemID.CrystalShard, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
