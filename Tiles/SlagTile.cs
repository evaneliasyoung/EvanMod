/**
*  @file      SlagTile.cs
*  @brief     Adds an ingame tile for the slag tile.
*
*  @author    Evan Elias Young
*  @date      2017-07-21
*  @date      2019-04-24
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Tiles
{
	internal class SlagTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			minPick = 110;
			mineResist = 2.5f;
			drop = mod.ItemType("Slag");
			AddMapEntry(Utils.SlagColor, Language.GetText("Mods.EvanModpack.ItemName.Slag"));
			base.SetDefaults();
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
			base.ModifyLight(i, j, ref r, ref g, ref b);
		}
	}
}
