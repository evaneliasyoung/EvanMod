/**
*  @file      VanillaOverrides.cs
*  @brief     Basic overrides for the default NPC in the game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.NPCs
{
	internal class VanillaOverrides : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.WallofFlesh)
			{
				int SlagVeins = 45;
				int SlagMaxLoop = (int)(WorldGen.rockLayer * Main.maxTilesY * SlagVeins * 1E-05);
				Main.NewText("Slag has begun to seep up through the center of the earth", Utils.ChatColors.Info);

				for (int k = 0; k < SlagMaxLoop; k++)
				{
					int X = WorldGen.genRand.Next(0, Main.maxTilesX);
					int Y = WorldGen.genRand.Next(Main.maxTilesY - 200, Main.maxTilesY);
					int SlagStrength = WorldGen.genRand.Next(4, 8);
					int SlagStep = WorldGen.genRand.Next(5, 9);
					WorldGen.OreRunner(X, Y, SlagStrength, SlagStep, (ushort)mod.TileType("SlagTile"));
				}
			}
			base.NPCLoot(npc);
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
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot++].SetDefaults(mod.ItemType("TravellersMap"));
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
