/**
*  @file      Slag.cs
*  @brief     Adds a hardmode version of silt.
*
*  @author    Evan Elias Young
*  @date      2017-07-21
*  @date      2019-05-04
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Blocks
{
	internal class Slag : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
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
			List<short> listOres = new List<short> { ItemID.CobaltOre, ItemID.PalladiumOre, ItemID.MythrilOre, ItemID.OrichalcumOre, ItemID.AdamantiteOre, ItemID.TitaniumOre };
			List<short> listGems = new List<short> { ItemID.Sapphire, ItemID.Ruby, ItemID.Emerald, ItemID.Topaz, ItemID.Amethyst, ItemID.Diamond, ItemID.Amber };
			double percent = Main.rand.NextDouble();
			int mx = 16;

			if (percent <= 0.2000)
			{ // Gems
				resultType = listGems[Main.rand.Next(listGems.Count)];
			}
			else if (percent <= 0.3533)
			{ // Ores
				resultType = listOres[Main.rand.Next(listOres.Count)];
			}
			else if (percent <= 0.9933)
			{ // Silver Coin
				mx = 100;
				resultType = ItemID.SilverCoin;
			}
			else if (percent <= 0.9993)
			{ // Gold Coin
				mx = 100;
				resultType = ItemID.GoldCoin;
			}
			else
			{ // Platinum Coin
				mx = 25;
				resultType = ItemID.PlatinumCoin;
			}

			resultStack = Main.rand.Next(Main.rand.Next(mx)) + 1;
			base.ExtractinatorUse(ref resultType, ref resultStack);
		}
	}
}
