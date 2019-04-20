/**
*  @file      AmberPhasesaber.cs
*  @brief     Adds a (superior) amber-colored phasesaber.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-04-20
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class AmberPhasesaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(Language.GetTextValue("Mods.EvanModpack.ItemName.AmberPhasesaber"));
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.damage = 50;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 78, 0);
			item.rare = 5;
			item.autoReuse = true;
			item.UseSound = SoundID.Item15;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("AmberPhaseblade"));
			recipe.AddIngredient(ItemID.CrystalShard, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
