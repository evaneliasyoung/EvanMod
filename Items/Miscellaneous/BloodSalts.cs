/**
*  @file      BloodSalts.cs
*  @brief     Adds an items that can be used to trigger a blood moon.
*
*  @author    Evan Elias Young
*  @date      2019-04-20
*  @date      2019-04-22
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Miscellaneous
{
	internal class BloodSalts : ModItem
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 40;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.useAnimation = 30;
			Item.useTime = 44;
			Item.useStyle = 4;
			Item.consumable = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
		public override void AddRecipes()
		{
			Recipe bloodSaltsRecipe = CreateRecipe();
			bloodSaltsRecipe.AddIngredient(ItemID.BottledWater);
			bloodSaltsRecipe.AddIngredient(ItemID.AshBlock);
			bloodSaltsRecipe.AddIngredient(ItemID.Deathweed);
			bloodSaltsRecipe.AddIngredient(ItemID.Fireblossom);
			bloodSaltsRecipe.AddIngredient(ItemID.Moonglow);
			bloodSaltsRecipe.AddTile(TileID.Bottles);
			bloodSaltsRecipe.Register();
		}

		/// <summary>
		/// Checks if the current player can use the Blood Salts.
		/// </summary>
		/// <param name="player">The player attemping to use it.</param>
		/// <returns>Whether or not the player can use the Blood Salts.</returns>
		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 120 // Enough health
					 && Main.moonPhase != 0    // Not a new moon
					 && !Main.dayTime          // Night time
					 && !Main.bloodMoon;       // Not a blood moon
		}

		/// <summary>
		/// Actually uses the Blood Salts.
		/// </summary>
		/// <param name="player">The player using the Blood Salts.</param>
		/// <returns></returns>
		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			Main.bloodMoon = true;
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			Main.NewText(Language.GetText("LegacyMisc.8"), Utils.ChatColors.Info);

			return true;
		}
	}
}
