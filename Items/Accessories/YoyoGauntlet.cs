/**
*  @file      YoyoGauntletAccessory.cs
*  @brief     Adds a cool yoyo bag-fire gauntlet accessory.
*
*  @author    Evan Elias Young
*  @date      2017-04-23
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Accessories
{
	internal class YoyoGauntlet : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 30;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
			base.SetDefaults();
		}

		public override void ModifyHitNPC(Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			target.AddBuff(BuffID.OnFire, 180);
			knockBack *= 1.8f;
			base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>(Mod);
			player.GetDamage(DamageClass.Melee) *= 1.15f;
			player.GetAttackSpeed(DamageClass.Melee) *= 1.15f;
			player.yoyoGlove = true;
			player.yoyoString = true;
			modPlayer.allParticles = true;
			base.UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddIngredient(ItemID.YoyoBag);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}
