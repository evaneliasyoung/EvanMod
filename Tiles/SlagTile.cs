/**
*  @file      SlagTile.cs
*  @brief     Adds an ingame tile for the slag tile.
*
*  @author    Evan Elias Young
*  @date      2017-07-21
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanMod.Tiles
{
	internal class SlagTile : ModTile
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			minPick = 110;
			mineResist = 2.5f;
			drop = mod.ItemType("Slag");
			AddMapEntry(Utils.SlagColor, Language.GetText("Mods.EvanMod.ItemName.Slag"));
			base.SetDefaults();
		}

		/// <summary>
		/// Override the light engine from the base-game.
		/// </summary>
		/// <param name="i">The x coordinate.</param>
		/// <param name="j">The y coordinate.</param>
		/// <param name="r">The red component.</param>
		/// <param name="g">The green component.</param>
		/// <param name="b">The blue component.</param>
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
			base.ModifyLight(i, j, ref r, ref g, ref b);
		}
	}
}
