/**
*  @file      AudioEngineerNPC.cs
*  @brief     Add an audio engineer vendor to sell music boxes.
*
*  @author    Evan Elias Young
*  @date      2017-04-24
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EvanModpack.NPCs
{
	internal class AudioEngineerNPC : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "AudioEngineerNPC";

			return mod.Properties.Autoload;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;

			npc.width = 18;
			npc.height = 46;

			npc.aiStyle = 7;
			npc.defense = 25;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 150;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			animationType = NPCID.Guide;
			base.SetDefaults();
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (NPC.downedBoss3 && numTownNPCs >= 5)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			return true;
		}

		public override string TownNPCName()
		{
			List<string> allNames = new List<string>
			{
				"George",
				"John",
				"Paul",
				"George",
				"Richard"
			};
			return allNames[WorldGen.genRand.Next(allNames.Count)];
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetText("LegacyInterface.28").Value;
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			List<int> forSale = new List<int>
			{
				ItemID.MusicBoxOverworldDay,
				ItemID.MusicBoxAltOverworldDay,
				ItemID.MusicBoxNight,
				ItemID.MusicBoxRain,
				ItemID.MusicBoxSnow,
				ItemID.MusicBoxIce,
				ItemID.MusicBoxDesert,
				ItemID.MusicBoxOcean,
				ItemID.MusicBoxSpace,
				ItemID.MusicBoxUnderground,
				ItemID.MusicBoxAltUnderground,
				ItemID.MusicBoxMushrooms
			};
			foreach (int sale in forSale)
			{
				shop.item[nextSlot++].SetDefaults(sale);
			}

			if (NPC.downedQueenBee)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxJungle);
			}
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxCorruption);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxCrimson);
				if (Main.hardMode)
				{
					shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxUndergroundCorruption);
					shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxUndergroundCrimson);
				}
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxTheHallow);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxUndergroundHallow);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxHell);
			}
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxDungeon);
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxTemple);
			}
			if (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxBoss1);
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxBoss2);
			}
			if (NPC.downedMechBoss2)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxBoss3);
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxBoss4);
			}
			if (NPC.downedQueenBee)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxBoss5);
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxPlantera);
			}
			shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxEerie);
			if (Main.hardMode)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxEclipse);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxGoblins);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxPirates);
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxMartians);
			}
			if (NPC.downedHalloweenKing)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxPumpkinMoon);
			}
			if (NPC.downedFrost)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxFrostMoon);
			}
			if (NPC.downedTowerNebula || NPC.downedTowerSolar || NPC.downedTowerStardust || NPC.downedTowerVortex)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxTowers);
			}
			if (NPC.downedAncientCultist)
			{
				shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxLunarBoss);
			}
			shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxSandstorm);
			shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxDD2);
			shop.item[nextSlot++].SetDefaults(ItemID.MusicBoxTitle);
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			if (NPC.FindFirstNPC(NPCID.DyeTrader) != -1)
			{
				chat.Add(Language.GetTextValue("Mods.EvanModpack.NPCDialog.AudioEngineer0", Main.npc[NPC.FindFirstNPC(NPCID.DyeTrader)].GivenName));
			}
			for (int i = 1; i < 7; ++i)
			{
				chat.Add(Language.GetText(string.Format("Mods.EvanModpack.NPCDialog.AudioEngineer{0}", i)).Value);
			}
			return chat;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 40;
			knockback = 2f;
		}

		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
		{
			scale = 1f;
			item = Main.itemTexture[ItemID.TerraBlade];
			itemSize = 56;
		}

		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
		{
			itemWidth = 56;
			itemHeight = 56;
		}
	}
}
