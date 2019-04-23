/**
*  @file      VanillaOverrides.cs
*  @brief     Basic overrides for the default NPC in the game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-04-22
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.NPCs
{
	internal class NPCOverrides : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			switch (npc.type)
			{
				case NPCID.WallofFlesh:
					GenerateSlag();
					return;
			}
			base.NPCLoot(npc);
		}

		public void GenerateSlag()
		{
			int slagVeins = 45;
			int slagLoop = (int)(WorldGen.rockLayer * Main.maxTilesY * slagVeins * 1E-05);
			Main.NewText(Language.GetTextValue("Mods.EvanModpack.Misc.SlagEnter"), Utils.ChatColors.Info);

			for (int i = 0; i < slagLoop; ++i)
			{
				GenerateSlagVein();
			}
		}

		public void GenerateSlagVein()
		{
			Point minPos = new Point(0, Main.maxTilesY - 200);
			Point maxPos = new Point(Main.maxTilesX, Main.maxTilesY);
			int slagStrength = WorldGen.genRand.Next(4, 8);
			int slagStep = WorldGen.genRand.Next(5, 9);

			WorldGen.OreRunner(WorldGen.genRand.Next(minPos.X, maxPos.X), WorldGen.genRand.Next(minPos.Y, maxPos.Y), slagStrength, slagStep, (ushort)mod.TileType("SlagTile"));
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			List<string> clothierMaleBlood = new List<string> { "GeorgeHat", "GeorgeSuit", "GeorgePants" };

			switch (type)
			{
				case NPCID.Merchant:
					if (Main.player[Main.myPlayer].statLifeMax > 400)
					{
						shop.item[7].SetDefaults(ItemID.SuperHealingPotion);
					}
					else if (Main.player[Main.myPlayer].statLifeMax > 300)
					{
						shop.item[7].SetDefaults(ItemID.GreaterHealingPotion);
					}
					else if (Main.player[Main.myPlayer].statLifeMax > 200)
					{
						shop.item[7].SetDefaults(ItemID.HealingPotion);
					}
					else
					{
						shop.item[7].SetDefaults(ItemID.LesserHealingPotion);
					}
					break;
				case NPCID.Clothier:
					if (Main.player[Main.myPlayer].Male && Main.bloodMoon)
					{
						foreach (string e in clothierMaleBlood)
						{
							shop.item[nextSlot++].SetDefaults(mod.ItemType(e));
						}
					}
					break;
				case NPCID.Dryad:
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.HerbBag);
						shop.item[nextSlot++].shopCustomPrice = Item.buyPrice(0, 5, 0, 0);
					}
					break;
				case NPCID.Wizard:
					if (Main.player[Main.myPlayer].statManaMax2 > 200)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.SuperManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 == 200)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.GreaterManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 > 100)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.ManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 > 0)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.LesserManaPotion);
					}
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.ClothierVoodooDoll);
					}
					if (Main.hardMode)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.GuideVoodooDoll);
					}
					break;
			}
			base.SetupShop(type, shop, ref nextSlot);
		}
	}
}
