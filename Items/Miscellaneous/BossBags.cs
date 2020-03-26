/**
*  @file      BossBags.cs
*  @brief     Creates all the overrides for the pre-existing boss bags.
*
*  @author    Evan Elias Young
*  @date      2019-04-19
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Items.Miscellaneous
{
	internal class BossBags : GlobalItem
	{
		// The minimum amount of slag a bag can produce.
		const int MIN_SLAG = 15;
		// The maximum amount of slag a bag can produce.
		const int MAX_SLAG = 30;

		/// <summary>
		/// Changes the potential loot for the boss bags.
		/// </summary>
		/// <param name="context">The context for the boss bag.</param>
		/// <param name="player">The player opening the boss bag.</param>
		/// <param name="arg">The specific boss bag that is being opened.</param>
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			// Ignore the bag if it isn't from a boss.
			if (context != "bossBag") { return; }

			switch (arg)
			{
				case ItemID.WallOfFleshBossBag:
					player.QuickSpawnItem(mod.ItemType("TravellersMap"));
					player.QuickSpawnItem(mod.ItemType("Slag"), Main.rand.Next(MIN_SLAG, MAX_SLAG));
					break;
			}
		}
	}
}
