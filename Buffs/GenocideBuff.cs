/**
*  @file      GenocideBuff.cs
*  @brief     Adds a 7x super-battle buff.
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
	internal class GenocideBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Genocide");
			// Description.SetDefault("Extremely increased enemy spawn rate (7x)");

			DisplayName.AddTranslation(GameCulture.Spanish, "Genocidio");
			Description.AddTranslation(GameCulture.Spanish, "Extremadamente aumenta tasa de spawn (7x) de enemigo");

			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
		}

		private class SpawnRateMultiplierGlobalNPC : GlobalNPC
		{
			private static readonly float mult = 7f;
			public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
			{
				if (player.FindBuffIndex(Mod.Find<ModBuff>("GenocideBuff").Type) > 0)
				{
					spawnRate = (int)(spawnRate / mult);
					maxSpawns = (int)(maxSpawns * mult);
				}
			}
		}
	}
}
