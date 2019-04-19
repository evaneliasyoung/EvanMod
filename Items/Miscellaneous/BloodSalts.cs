/**
*  @file      BloodSalts.cs
*  @brief     Adds an items that can be used to trigger a blood moon.
*
*  @author    Evan Elias Young
*  @date      2019-04-19
*  @date      2019-04-19
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Miscellaneous
{
	internal class BloodSalts : ModItem
	{
		/// <summary>
		/// Set the constant item data.
		/// </summary>
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Salts");
			Tooltip.SetDefault("Summons a Blood Moon");

			DisplayName.AddTranslation(GameCulture.Spanish, "Sales de Sangre");
			Tooltip.AddTranslation(GameCulture.Spanish, "Invoca una Luna de Sangre");
			DisplayName.AddTranslation(GameCulture.German, "Salze von Blut");
			Tooltip.AddTranslation(GameCulture.German, "Beschwört den Blutmond");
			base.SetStaticDefaults();
		}

		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.rare = 0;
			item.useAnimation = 30;
			item.useTime = 44;
			item.useStyle = 4;
			item.consumable = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Adds the crafting recipes to the item.
		/// </summary>
		public override void AddRecipes()
		{
			ModRecipe bloodSaltsRecipe = new ModRecipe(mod);
			bloodSaltsRecipe.AddIngredient(ItemID.BottledWater);
			bloodSaltsRecipe.AddIngredient(ItemID.SiltBlock);
			bloodSaltsRecipe.AddIngredient(ItemID.Deathweed);
			bloodSaltsRecipe.AddIngredient(ItemID.Fireblossom);
			bloodSaltsRecipe.AddIngredient(ItemID.Moonglow);
			bloodSaltsRecipe.AddTile(TileID.Bottles);
			bloodSaltsRecipe.SetResult(this);
			bloodSaltsRecipe.AddRecipe();
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
		public override bool UseItem(Player player)
		{
			Main.bloodMoon = true;
			Main.NewText(Language.GetText("LegacyMisc.8"), Utils.ChatColors.Info);

			return true;
		}
	}
}
