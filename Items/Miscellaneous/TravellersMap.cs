/**
*  @file      TravellersMap.cs
*  @brief     Adds a map that reveals the entire map to the player.
*
*  @author    Evan Elias Young
*  @date      2019-04-16
*  @date      2019-04-20
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Miscellaneous
{
	internal class TravellersMap : ModItem
	{
		/// <summary>
		/// Set the constant item data.
		/// </summary>
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(Language.GetTextValue("Mods.EvanModpack.ItemName.TravellersMap"));
			Tooltip.SetDefault(Language.GetTextValue("Mods.EvanModpack.ItemTooltip.TravellersMap"));
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
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.rare = -12;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			base.SetDefaults();
		}

		/// <summary>
		/// Checks if the current player can use the Traveller's Map.
		/// </summary>
		/// <param name="player">The player attemping to use it.</param>
		/// <returns>Whether or not the player can use the Traveller's Map.</returns>
		public override bool CanUseItem(Player player)
		{
			return Main.hardMode;
		}

		/// <summary>
		/// Actually uses the Traveller's Map.
		/// </summary>
		/// <param name="player">The player using the Traveller's Map.</param>
		/// <returns></returns>
		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1)
			{ // If not on a server, reveal the entire map.
				RevealWholeMap();
			}
			else
			{ // If on a server, reveal what you can :/.
				Point center = Main.player[Main.myPlayer].Center.ToTileCoordinates();
				RevealAroundPoint(center);
			}

			// Play a sound indicating completion.
			Main.PlaySound(SoundID.MenuTick);

			return true;
		}

		/// <summary>
		/// Reveals parts of the map around a specific point.
		/// </summary>
		/// <param name="pos">The point on the map.</param>
		public static void RevealAroundPoint(Point pos)
		{
			int halfMap = Utils.MapRevealSize / 2;

			for (int i = pos.X - halfMap; i < pos.X + halfMap; ++i)
			{
				for (int j = pos.Y - halfMap; j < pos.Y + halfMap; ++j)
				{
					if (WorldGen.InWorld(i, j))
					{
						Main.Map.Update(i, j, 255);
					}
				}
			}
			Main.refreshMap = true;
		}

		/// <summary>
		/// Reveals the entire map to the player.
		/// </summary>
		public static void RevealWholeMap()
		{
			for (int i = 0; i < Main.maxTilesX; ++i)
			{
				for (int j = 0; j < Main.maxTilesY; ++j)
				{
					if (WorldGen.InWorld(i, j))
					{
						Main.Map.Update(i, j, 255);
					}
				}
			}
			Main.refreshMap = true;
		}
	}
}
