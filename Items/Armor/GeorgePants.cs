/**
*  @file      GeorgePants.cs
*  @brief     Brings George's pants to the PC game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	internal class GeorgePants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("George's Pants");
			Tooltip.SetDefault("\"Oh myyy!\"");

			DisplayName.AddTranslation(GameCulture.Spanish, "Pantalones de Jorge");
			Tooltip.AddTranslation(GameCulture.Spanish, "\"Oh mi!\"");
			DisplayName.AddTranslation(GameCulture.German, "George's Hose");
			Tooltip.AddTranslation(GameCulture.German, "\"Oh mein!\"");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 0;
			item.defense = 0;
			base.SetDefaults();
		}
	}
}
