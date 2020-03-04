/**
*  @file      YoyoGauntletAccessory.cs
*  @brief     Adds a cool yoyo bag-fire gauntlet accessory.
*
*  @author    Evan Elias Young
*  @date      2017-04-23
*  @date      2020-03-04
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Accessories
{
	internal class YoyoGauntlet : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			base.SetDefaults();
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180);
			knockBack *= 1.8f;
			base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>(mod);
			player.meleeDamage *= 1.15f;
			player.meleeSpeed *= 1.15f;
			player.yoyoGlove = true;
			player.yoyoString = true;
			modPlayer.allParticles = true;
			base.UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddIngredient(ItemID.YoyoBag);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
