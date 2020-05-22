/**
*  @file      YoyoGauntletAccessory.cs
*  @brief     Adds a cool yoyo bag-fire gauntlet accessory.
*
*  @author    Evan Elias Young
*  @date      2017-04-23
*  @date      2020-05-22
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Accessories
{
	internal class YoyoGauntlet : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Overrides the base-game's implementation of an npc hit.
		/// </summary>
		/// <param name="player">The player inflicting the hit.</param>
		/// <param name="target">The npc receiving the hit.</param>
		/// <param name="damage">The base damage from the hit.</param>
		/// <param name="knockBack">The base knockback from the hit.</param>
		/// <param name="crit">Whehter or not the hit was a critical hit.</param>
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180);
			knockBack *= 1.8f;
			base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
		}

		/// <summary>
		/// Updates the player's stats when the accessory is equipped.
		/// </summary>
		/// <param name="player">The player equipping the accessory.</param>
		/// <param name="hideVisual">Whether or not to hide the accessory.</param>
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ModdedPlayer modPlayer = (ModdedPlayer)player.GetModPlayer(mod, "ModdedPlayer");
			player.meleeDamage *= 1.15f;
			player.meleeSpeed *= 1.15f;
			player.yoyoGlove = true;
			player.yoyoString = true;
			modPlayer.allParticles = true;
			base.UpdateAccessory(player, hideVisual);
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
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
