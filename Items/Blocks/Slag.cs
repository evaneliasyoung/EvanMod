/**
*  @file      Slag.cs
*  @brief     Adds a hardmode version of silt.
*
*  @author    Evan Elias Young
*  @date      2017-07-21
*  @date      2020-04-08
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EvanMod.Items.Blocks
{
	internal class Slag : ModItem
	{
		/// <summary>
		/// Set the specific item data that does not change.
		/// </summary>
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
			base.SetStaticDefaults();
		}

		/// <summary>
		/// Set the specific item data.
		/// </summary>
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
			// The actual random resul generator.
			WeightedRandom<short> result = new WeightedRandom<short>();
			// The list of ores that slag can produce.
			List<short> listOres = new List<short> { ItemID.CobaltOre, ItemID.PalladiumOre, ItemID.MythrilOre, ItemID.OrichalcumOre, ItemID.AdamantiteOre, ItemID.TitaniumOre };
			// The list of gems that slag can produce.
			List<short> listGems = new List<short> { ItemID.Sapphire, ItemID.Ruby, ItemID.Emerald, ItemID.Topaz, ItemID.Amethyst, ItemID.Diamond, ItemID.Amber };
			// The maximum stack for anything from slag.
			int mx = 20;

			// Add the ores to the random generator.
			listOres.ForEach((e) =>
			{
				result.Add(e, 0.2833 / listOres.Count);
			});
			// Add the gems to the random generator.
			listGems.ForEach((e) =>
			{
				result.Add(e, 0.2500 / listOres.Count);
			});
			// Add the gold coin to the random generator.
			result.Add(ItemID.GoldCoin, 0.4660);
			// Add the platinum coin to the random generator.
			result.Add(ItemID.PlatinumCoin, 0.0007);

			resultType = result;
			mx = resultType == ItemID.GoldCoin ? 100 : mx;
			resultStack = Main.rand.Next(Main.rand.Next(mx) + 1);
			base.ExtractinatorUse(ref resultType, ref resultStack);
		}
	}
}
