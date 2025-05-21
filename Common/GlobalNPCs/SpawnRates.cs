using System;
using EvanMod.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EvanMod.Common.GlobalNPCs
{
    public class SpawnRates : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (!player.active) return;
            if (Main.invasionType > 0 || NPC.waveNumber > 0) return;

            if (player.FindBuffIndex(BuffType<Content.Buffs.SuperBattle>()) != -1)
            {
                spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotions.SuperSpawnRate));
                maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotions.SuperMax);
            }
            if (player.FindBuffIndex(BuffType<Content.Buffs.GreaterBattle>()) != -1)
            {
                spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotions.GreaterSpawnRate));
                maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotions.GreaterMax);
            }
            if (player.FindBuffIndex(BuffID.Battle) != -1)
            {
                if (GetInstance<ServerConfig>().BattlePotions.VanillaSpawnRate > 2)
                    spawnRate = Math.Max(1, (int)(spawnRate / GetInstance<ServerConfig>().BattlePotions.VanillaSpawnRate));

                if (GetInstance<ServerConfig>().BattlePotions.VanillaMax > 2)
                    maxSpawns = (int)(maxSpawns * GetInstance<ServerConfig>().BattlePotions.VanillaMax);
            }
        }
    }
}
