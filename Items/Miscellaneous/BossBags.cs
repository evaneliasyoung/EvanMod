/**
*  @file      BossBags.cs
*  @brief     Creates all the overrides for the pre-existing boss bags.
*
*  @author    Evan Elias Young
*  @date      2019-04-19
*  @date      2019-04-24
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Miscellaneous
{
	internal class BossBags : GlobalItem
	{
		/// <summary>
		/// Changes the potential loot for the boss bags.
		/// </summary>
		/// <param name="context">The context for the boss bag.</param>
		/// <param name="player">The player opening the boss bag.</param>
		/// <param name="arg">The specific boss bag that is being opened.</param>
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context != "bossBag") { return; }

			switch (arg)
			{
				case ItemID.WallOfFleshBossBag:
					player.QuickSpawnItem(Mod.Find<ModItem>("TravellersMap").Type);
					player.QuickSpawnItem(Mod.Find<ModItem>("Slag").Type, Main.rand.Next(10, 30));
					break;
			}
		}
	}
}
