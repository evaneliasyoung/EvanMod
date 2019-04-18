/**
*  @file      WarBuff.cs
*  @brief     Adds a 4x great-battle buff.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Buffs
{
	internal class WarBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("War");
			Description.SetDefault("Considerably increased enemy spawn rate (4x)");

			DisplayName.AddTranslation(GameCulture.Spanish, "Guerra");
			Description.AddTranslation(GameCulture.Spanish, "Considerablemente aumenta tasa de spawn (4x) de enemigo.");
			DisplayName.AddTranslation(GameCulture.German, "Krieg");
			Description.AddTranslation(GameCulture.German, "Erhöht die Spawnrate von Gegnern deutlich (4x)");

			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 420;
			base.Update(player, ref buffIndex);
		}

		private class SpawnRateMultiplierGlobalNPC : GlobalNPC
		{
			private static readonly float mult = 4f;
			public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
			{
				if (player.FindBuffIndex(mod.BuffType("WarBuff")) > 0)
				{
					spawnRate = (int)(spawnRate / mult);
					maxSpawns = (int)(maxSpawns * mult);
				}
			}
		}
	}
}
