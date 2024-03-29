/**
*  @file      WarBuff.cs
*  @brief     Adds a 4x great-battle buff.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Buffs
{
	internal class WarBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("War");
			// Description.SetDefault("Considerably increased enemy spawn rate (4x)");

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
				if (player.FindBuffIndex(Mod.Find<ModBuff>("WarBuff").Type) > 0)
				{
					spawnRate = (int)(spawnRate / mult);
					maxSpawns = (int)(maxSpawns * mult);
				}
			}
		}
	}
}
