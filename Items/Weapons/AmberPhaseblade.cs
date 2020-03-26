/**
*  @file      AmberPhaseblade.cs
*  @brief     Adds a (superior) amber-colored phaseblade.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Weapons
{
	internal class AmberPhaseblade : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.damage = 30;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 78, 0);
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item15;
			base.SetDefaults();
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Amber, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
