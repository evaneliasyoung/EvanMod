/**
*  @file      ButterflyKnife.cs
*  @brief     Adds a fast and deadly butterfly-knife.
*
*  @author    Evan Elias Young
*  @date      2017-07-17
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Weapons
{
	internal class ButterflyKnife : ModItem
	{
		// The percent chance for an instant kill.
		public const int INSTANT_KILL_CHANCE = 1;

		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.width = 34;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 35, 0);
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		/// <summary>
		/// Overrides the base-game's implementation of an npc hit.
		/// </summary>
		/// <param name="player">The player inflicting the hit.</param>
		/// <param name="target">The npc receiving the hit.</param>
		/// <param name="damage">The base damage from the hit.</param>
		/// <param name="knockBack">The base knockback from the hit.</param>
		/// <param name="crit">Whehter or not the hit was a critical hit.</param>
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(1, 100) <= INSTANT_KILL_CHANCE)
			{
				item.damage = 217500;
			}
			else
			{
				item.damage = 18;
			}
			base.OnHitNPC(player, target, damage, knockBack, crit);
		}
	}
}
