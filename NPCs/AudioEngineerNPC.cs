/**
*  @file      AudioEngineerNPC.cs
*  @brief     Add an audio engineer vendor to sell music boxes.
*
*  @author    Evan Elias Young
*  @date      2017-04-24
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EvanMod.NPCs
{
	internal class AudioEngineerNPC : ModNPC
	{
		public override bool Autoload(ref string name)
		{
			name = "AudioEngineerNPC";

			return mod.Properties.Autoload;
		}

		/// <summary>
		/// Set the specific npc data.
		/// </summary>
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

		/// <summary>
		/// Determines whether or not the Audio Engineer can spawn.
		/// </summary>
		/// <param name="numTownNPCs">The current number of town npc.</param>
		/// <param name="money">The current amount of money the player has.</param>
		/// <returns>Whether or not the Audio Engineer can spawn.</returns>
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			// TODO: Simplify this function.
			if (NPC.downedBoss3 && numTownNPCs >= 5)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Checks if the spawn conditions are valid for the Audio Engineer.
		/// </summary>
		/// <param name="left">The pixel.</param>
		/// <param name="right">The right pixel.</param>
		/// <param name="top">The top pixel.</param>
		/// <param name="bottom">The bottom pixel.</param>
		/// <returns>Whether or not the spawn conditions are valid.</returns>
		public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			return true;
		}

		/// <summary>
		/// Gets the name of the Audio Engineer.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Gets the text for the chat buttons.
		/// </summary>
		/// <param name="button">The text for the first button.</param>
		/// <param name="button2">The text for the second button.</param>
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetText("LegacyInterface.28").Value;
		}

		/// <summary>
		/// The first button was pressed, open the shop.
		/// </summary>
		/// <param name="firstButton">If the first button was pressed.</param>
		/// <param name="shop">Whether or not to open the shop.</param>
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		/// <summary>
		/// Sets up the shop's inventory.
		/// </summary>
		/// <param name="shop">The shop's contents.</param>
		/// <param name="nextSlot">The index of the next slot.</param>
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			List<short> forSale = new List<short>
			{
				ItemID.MusicBox,
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
				ItemID.MusicBoxMushrooms,
				ItemID.MusicBoxSandstorm,
				ItemID.MusicBoxEerie
			};

			if (NPC.downedQueenBee)
			{ // Queen Bee defeated, add the jungle box and her box.
				forSale.Add(ItemID.MusicBoxJungle);
				forSale.Add(ItemID.MusicBoxBoss5);
			}
			if (NPC.downedBoss2)
			{ // The BoC or EoW defeated, add the evil boxes.
				forSale.Add(ItemID.MusicBoxCorruption);
				forSale.Add(ItemID.MusicBoxCrimson);
				if (Main.hardMode)
				{ // Hardmode, so add the underground boxes.
					forSale.Add(ItemID.MusicBoxUndergroundCorruption);
					forSale.Add(ItemID.MusicBoxUndergroundCrimson);
				}
			}
			if (NPC.downedBoss3)
			{ // Skeleltron defeated, add the dungeon box.
				forSale.Add(ItemID.MusicBoxDungeon);
			}
			if (Main.hardMode)
			{ // WoF defeated, add the Hallow, Hell, and underground Hallow boxes.
				forSale.Add(ItemID.MusicBoxTheHallow);
				forSale.Add(ItemID.MusicBoxUndergroundHallow);
				forSale.Add(ItemID.MusicBoxHell);
			}
			if (NPC.downedGolemBoss)
			{ // Golem defeated, add the template box.
				forSale.Add(ItemID.MusicBoxTemple);
			}
			if (NPC.downedGoblins)
			{ // Goblin Army defeated, add the goblin box.
				forSale.Add(ItemID.MusicBoxGoblins);
			}
			if (NPC.downedPirates)
			{ // Pirate Army defeated, add the pirate box.
				forSale.Add(ItemID.MusicBoxPirates);
			}
			if (NPC.downedMechBossAny)
			{ // Any Mech defeated, add the eclipse box.
				forSale.Add(ItemID.MusicBoxEclipse);
			}
			if (NPC.downedMartians)
			{ // Martian Army defeated, add the martian box.
				forSale.Add(ItemID.MusicBoxMartians);
			}
			if (NPC.downedHalloweenKing)
			{ // Pumpking defeated, add the Pumpkin Moon box.
				forSale.Add(ItemID.MusicBoxPumpkinMoon);
			}
			if (NPC.downedFrost)
			{ // Frost Queen defeated, add the Frost Moon box.
				forSale.Add(ItemID.MusicBoxFrostMoon);
			}
			if (NPC.downedTowerNebula || NPC.downedTowerSolar || NPC.downedTowerStardust || NPC.downedTowerVortex)
			{ // One of the towers defeated, add the Towers' box.
				forSale.Add(ItemID.MusicBoxTowers);
			}
			if (NPC.downedSlimeKing || NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3 || NPC.downedMechBoss3 || NPC.downedFishron)
			{ // Any of the "first" bosses defeated, add the collective box.
				forSale.Add(ItemID.MusicBoxBoss1);
			}
			if (Main.hardMode || NPC.downedMechBoss1)
			{ // Any of the "second" bosses defeated, add the collective box.
				forSale.Add(ItemID.MusicBoxBoss2);
			}
			if (NPC.downedMechBoss2 || NPC.downedFrost || NPC.downedBoss2)
			{ // Any of the "third" bosses defeated, add the collective box.
				forSale.Add(ItemID.MusicBoxBoss3);
			}
			if (NPC.downedGolemBoss || NPC.downedAncientCultist)
			{ // Any of the "fourth" bosses defeated, add the collective box.
				forSale.Add(ItemID.MusicBoxBoss4);
			}
			if (NPC.downedPlantBoss)
			{ // Plantera defeated, add her box.
				forSale.Add(ItemID.MusicBoxPlantera);
			}
			if (NPC.downedAncientCultist)
			{ // Ancient Cultist defeated, add his box.
				forSale.Add(ItemID.MusicBoxLunarBoss);
			}
			if (NPC.downedMoonlord)
			{ // Moon Lord defeated, add his box.
				forSale.Add(ItemID.MusicBoxTitle);
			}

			// Actually add all the boxes to the shop.
			foreach (short s in forSale)
			{
				shop.item[nextSlot++].SetDefaults(s);
			}
		}

		/// <summary>
		/// Gets a random chat message.
		/// </summary>
		/// <returns>A random chat message.</returns>
		public override string GetChat()
		{
			// The chat message.
			WeightedRandom<string> chat = new WeightedRandom<string>();

			// Player has the Dye Trader.
			if (NPC.FindFirstNPC(NPCID.DyeTrader) != -1)
			{
				chat.Add(Language.GetTextValue("Mods.EvanMod.NPCDialog.AudioEngineer0", Main.npc[NPC.FindFirstNPC(NPCID.DyeTrader)].GivenName));
			}

			// Add the other random messages to the list.
			for (int i = 1; i < 7; ++i)
			{
				chat.Add(Language.GetText(string.Format("Mods.EvanMod.NPCDialog.AudioEngineer{0}", i)).Value);
			}
			return chat;
		}

		/// <summary>
		/// Sets the Audio Engineer's attack strength.
		/// </summary>
		/// <param name="damage">The base-damage.</param>
		/// <param name="knockback">The base-knockback.</param>
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 40;
			knockback = 2f;
		}

		/// <summary>
		/// Sets the Audio Engineer's attack animation.
		/// </summary>
		/// <param name="item">The item to swing.</param>
		/// <param name="itemSize">The item's scale in pixels.</param>
		/// <param name="scale">The item's scale.</param>
		/// <param name="offset">The position offset.</param>
		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
		{
			scale = 1f;
			item = Main.itemTexture[ItemID.TheAxe];
			itemSize = 56;
		}

		/// <summary>
		/// Sets the base size for the Audio Engineer's attack animation.
		/// </summary>
		/// <param name="itemWidth">The width.</param>
		/// <param name="itemHeight">The height.</param>
		public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
		{
			itemWidth = 56;
			itemHeight = 56;
		}
	}
}
