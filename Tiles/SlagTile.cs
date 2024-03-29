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
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			MinPick = 110;
			MineResist = 2.5f;
			ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = Mod.Find<ModItem>("Slag").Type;
			AddMapEntry(Utils.SlagColor, Language.GetText("Mods.EvanModpack.ItemName.Slag"));
			base.SetStaticDefaults();
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
