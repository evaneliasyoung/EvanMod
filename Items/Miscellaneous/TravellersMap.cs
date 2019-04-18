/**
*  @file      TravellersMap.cs
*  @brief     Adds a map that reveals the entire map to the player.
*
*  @author    Evan Elias Young
*  @date      2019-04-16
*  @date      2019-04-16
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
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Traveller's Map");
			Tooltip.SetDefault("This place looks pretty familiar...");

			DisplayName.AddTranslation(GameCulture.Spanish, "Mapa del Viajero");
			Tooltip.AddTranslation(GameCulture.Spanish, "Esta lugar aparece muy familiar...");
			DisplayName.AddTranslation(GameCulture.German, "Karte Das Reisenden");
			Tooltip.AddTranslation(GameCulture.German, "Dieser Ort sieht ziemlich vertraut aus...");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 44;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = 4;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
			base.SetDefaults();
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool UseItem(Player player)
		{
			if (Main.netMode != 1)
			{
				RevealWholeMap();
			}
			else
			{
				Point center = Main.player[Main.myPlayer].Center.ToTileCoordinates();
				RevealAroundPoint(center.X, center.Y);
			}

			Main.PlaySound(SoundID.MenuTick);

			return true;
		}

		public static void RevealAroundPoint(int x, int y)
		{
			for (int i = x - Utils.MapRevealSize / 2; i < x + Utils.MapRevealSize / 2; i++)
			{
				for (int j = y - Utils.MapRevealSize / 2; j < y + Utils.MapRevealSize / 2; j++)
				{
					if (WorldGen.InWorld(i, j))
					{
						Main.Map.Update(i, j, 255);
					}
				}
			}
			Main.refreshMap = true;
		}

		public static void RevealWholeMap()
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
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
