/**
*  @file      Slag.cs
*  @brief     Adds a hardmode version of silt.
*
*  @author    Evan Elias Young
*  @date      2017-07-21
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Placeable
{
	internal class Slag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slag");
			Tooltip.SetDefault("Remnants of various metals waiting to be refined");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;

			DisplayName.AddTranslation(GameCulture.Spanish, "Escoria");
			Tooltip.AddTranslation(GameCulture.Spanish, "Los restos de varios metales que esperan ser refinados");
			DisplayName.AddTranslation(GameCulture.German, "Schlacke");
			Tooltip.AddTranslation(GameCulture.German, "Reste von verschiedenen Metallen warten darauf, verfeinert zu werden");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 14;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("SlagTile");
		}

		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			int ChoiceNumber = Main.rand.Next(100);
			int OreStack = Main.rand.Next(1, 3);
			bool OriginalOre = Main.rand.NextBool();
			List<short> GemList = new List<short> { ItemID.Emerald, ItemID.Sapphire, ItemID.Diamond, ItemID.Ruby, ItemID.Amethyst, ItemID.Topaz, ItemID.Amber };

			if (ChoiceNumber <= 15)
			{
				resultType = OriginalOre ? ItemID.CobaltOre : ItemID.PalladiumOre;
			}
			else if (ChoiceNumber <= 30)
			{
				resultType = OriginalOre ? ItemID.MythrilOre : ItemID.OrichalcumOre;
			}
			else if (ChoiceNumber <= 45)
			{
				resultType = OriginalOre ? ItemID.AdamantiteOre : ItemID.TitaniumOre;
			}
			else if (ChoiceNumber <= 60)
			{
				resultType = OriginalOre ? ItemID.ChlorophyteOre : ItemID.LunarOre;
			}
			else
			{
				resultType = GemList[Main.rand.Next(GemList.Count)];
			}

			resultStack = OreStack;
			base.ExtractinatorUse(ref resultType, ref resultStack);
		}
	}
}
