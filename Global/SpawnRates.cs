using EvanModpack.Configuration;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EvanModpack.Global
{
    public class SpawnRates : GlobalNPC
    {
        class SpawnRateMultiplier : GlobalNPC
        {
            public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
            {
                if (!player.active) return;
                if (Main.invasionType > 0 || NPC.waveNumber > 0) return;

                if (player.FindBuffIndex(BuffType<Buffs.SuperBattle>()) != -1)
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotion.SuperSpawnRate));
                    maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotion.SuperMax);
                }
                if (player.FindBuffIndex(BuffType<Buffs.GreaterBattle>()) != -1)
                {
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotion.GreaterSpawnRate));
                    maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotion.GreaterMax);
                }
                if (player.FindBuffIndex(BuffID.Battle) != -1)
                {
                    if (GetInstance<ServerConfig>().BattlePotion.VanillaSpawnRate > 2)
                        spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotion.VanillaSpawnRate));

                    if (GetInstance<ServerConfig>().BattlePotion.VanillaMax > 2)
                        maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotion.VanillaMax);
                }

            }
        }
    }
}
