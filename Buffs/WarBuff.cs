/**
*  @file      WarBuff.cs
*  @brief     Adds a 4x great-battle buff.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanMod.Buffs
{
	internal class WarBuff : ModBuff
	{
		/// <summary>
		/// Set the specific item data.
		/// </summary>
		public override void SetDefaults()
		{
			DisplayName.SetDefault("War");
			Description.SetDefault("Considerably increased enemy spawn rate (4x)");

			DisplayName.AddTranslation(GameCulture.Spanish, "Guerra");
			Description.AddTranslation(GameCulture.Spanish, "Considerablemente aumenta tasa de spawn (4x) de enemigo.");

			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
		}

		private class SpawnRateMultiplierGlobalNPC : GlobalNPC
		{
			private static readonly float mult = 4f;
			public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
			{
				if (player.FindBuffIndex(mod.BuffType("GenocideBuff")) > 0)
				{
					spawnRate = (int)(spawnRate / mult);
					maxSpawns = (int)(maxSpawns * mult);
				}
			}
		}
	}
}
