using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;

namespace EvanMod
{
    internal static class Utils
    {
        /// <summary>
        /// Drops an item stack from an extractinator.
        /// </summary>
        /// <remarks>
        /// Original implementation marked as <c>private</c> in <c>Terraria.Player.DropItemFromExtractinator</c>.
        /// </remarks>
        /// <param name="player">The player who triggered the extractinator.</param>
        /// <param name="itemType">The item ID to be dropped.</param>
        /// <param name="stack">The amount of items in the stack to be dropped.</param>
        public static void DropItemFromExtractinator(Player player, int itemType, int stack)
        {
            Vector2 vector = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
            if (Main.SmartCursorIsUsed || PlayerInput.UsingGamepad)
                vector = player.Center;

            int number = Item.NewItem(player.GetSource_TileInteraction(Player.tileTargetX, Player.tileTargetY), (int)vector.X, (int)vector.Y, 1, 1, itemType, stack, noBroadcast: false, -1);
            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, number, 1f);
        }

        /// <summary>
        /// Rolls and drops an item stack from an extractinator.
        /// </summary>
        /// <remarks>
        /// Original implementation marked as <c>private</c> in <c>Terraria.Player.ExtractinatorUse</c>.
        /// </remarks>
        /// <param name="player">The player who triggered the extractinator.</param>
        /// <param name="extractType">The extractinator type corresponding to the items being processed.</param>
        /// <param name="extractinatorBlockType">Which extractinator tile is being used.</param>
        public static void ExtractinatorUse(Player player, int extractType, int extractinatorBlockType)
        {
            int mosquitoOdds = 5000;
            int gemstoneOdds = 25;
            int amberOdds = 50;
            bool isDesertFossil = false;
            bool isJunk = false;
            bool isGlowingMoss = false;
            bool extraCoinRoll = true;

            switch (extractType)
            {
                case 1: // Desert Fossil
                    mosquitoOdds /= 3;
                    gemstoneOdds *= 2;
                    amberOdds = 20;
                    isDesertFossil = true;
                    break;
                case 2: // Junk
                    mosquitoOdds = -1;
                    gemstoneOdds = -1;
                    amberOdds = -1;
                    isJunk = true;
                    extraCoinRoll = false;
                    break;
                case 3: // Glowing Moss
                    mosquitoOdds = -1;
                    gemstoneOdds = -1;
                    amberOdds = -1;
                    isGlowingMoss = true;
                    extraCoinRoll = false;
                    break;
            }

            int item = -1;
            int stack = 1;
            if (isDesertFossil && Main.rand.NextBool(10))
            {
                item = ItemID.FossilOre;
                if (Main.rand.NextBool(5)) stack += Main.rand.Next(2);
                if (Main.rand.NextBool(10)) stack += Main.rand.Next(3);
                if (Main.rand.NextBool(15)) stack += Main.rand.Next(4);
            }
            else if (extraCoinRoll && Main.rand.NextBool(2))
            {
                if (Main.rand.NextBool(12000))
                {
                    item = ItemID.PlatinumCoin;
                    if (Main.rand.NextBool(14)) stack += Main.rand.Next(0, 2);
                    if (Main.rand.NextBool(14)) stack += Main.rand.Next(0, 2);
                    if (Main.rand.NextBool(14)) stack += Main.rand.Next(0, 2);
                }
                else if (Main.rand.NextBool(800))
                {
                    item = ItemID.GoldCoin;
                    if (Main.rand.NextBool(6)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(6)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(6)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(6)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(6)) stack += Main.rand.Next(1, 20);
                }
                else if (Main.rand.NextBool(60))
                {
                    item = ItemID.SilverCoin;
                    if (Main.rand.NextBool(4)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(4)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(4)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(4)) stack += Main.rand.Next(5, 25);
                }
                else
                {
                    item = ItemID.CopperCoin;
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(10, 25);
                }
            }
            else if (mosquitoOdds != -1 && Main.rand.NextBool(mosquitoOdds))
            {
                item = ItemID.AmberMosquito;
            }
            else if (isJunk)
            {
                item = (!Main.rand.NextBool(4)) ? ItemID.ApprenticeBait : ((!Main.rand.NextBool(3)) ? ItemID.Snail : (Main.rand.NextBool(3) ? ItemID.JourneymanBait : ItemID.Worm));
            }
            else if (isGlowingMoss && extractinatorBlockType == TileID.ChlorophyteExtractinator)
            {
                if (Main.rand.NextBool(10))
                {
                    item = Main.rand.Next(5) switch
                    {
                        0 => ItemID.LavaMoss,
                        1 => ItemID.ArgonMoss,
                        2 => ItemID.KryptonMoss,
                        3 => ItemID.VioletMoss,
                        _ => ItemID.XenonMoss,
                    };
                }
                else
                {
                    item = Main.rand.Next(5) switch
                    {
                        0 => ItemID.GreenMoss,
                        1 => ItemID.BrownMoss,
                        2 => ItemID.RedMoss,
                        3 => ItemID.BlueMoss,
                        _ => ItemID.PurpleMoss,
                    };
                }
            }
            else if (isGlowingMoss)
            {
                item = Main.rand.Next(5) switch
                {
                    0 => ItemID.GreenMoss,
                    1 => ItemID.BrownMoss,
                    2 => ItemID.RedMoss,
                    3 => ItemID.BlueMoss,
                    _ => ItemID.PurpleMoss,
                };
            }
            else if (gemstoneOdds != -1 && Main.rand.NextBool(gemstoneOdds))
            {
                item = Main.rand.Next(6) switch
                {
                    0 => ItemID.Amethyst,
                    1 => ItemID.Topaz,
                    2 => ItemID.Sapphire,
                    3 => ItemID.Emerald,
                    4 => ItemID.Ruby,
                    _ => ItemID.Diamond,
                };
                if (Main.rand.NextBool(20)) stack += Main.rand.Next(0, 2);
                if (Main.rand.NextBool(30)) stack += Main.rand.Next(0, 3);
                if (Main.rand.NextBool(40)) stack += Main.rand.Next(0, 4);
                if (Main.rand.NextBool(50)) stack += Main.rand.Next(0, 5);
                if (Main.rand.NextBool(60)) stack += Main.rand.Next(0, 6);
            }
            else if (amberOdds != -1 && Main.rand.NextBool(amberOdds))
            {
                item = ItemID.Amber;
                if (Main.rand.NextBool(20)) stack += Main.rand.Next(0, 2);
                if (Main.rand.NextBool(30)) stack += Main.rand.Next(0, 3);
                if (Main.rand.NextBool(40)) stack += Main.rand.Next(0, 4);
                if (Main.rand.NextBool(50)) stack += Main.rand.Next(0, 5);
                if (Main.rand.NextBool(60)) stack += Main.rand.Next(0, 6);
            }
            else if (Main.rand.NextBool(3))
            {
                if (Main.rand.NextBool(5000))
                {
                    item = ItemID.PlatinumCoin;
                    if (Main.rand.NextBool(10)) stack += Main.rand.Next(0, 3);
                    if (Main.rand.NextBool(10)) stack += Main.rand.Next(0, 3);
                    if (Main.rand.NextBool(10)) stack += Main.rand.Next(0, 3);
                    if (Main.rand.NextBool(10)) stack += Main.rand.Next(0, 3);
                    if (Main.rand.NextBool(10)) stack += Main.rand.Next(0, 3);
                }
                else if (Main.rand.NextBool(400))
                {
                    item = ItemID.GoldCoin;
                    if (Main.rand.NextBool(5)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(5)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(5)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(5)) stack += Main.rand.Next(1, 21);
                    if (Main.rand.NextBool(5)) stack += Main.rand.Next(1, 20);
                }
                else if (Main.rand.NextBool(30))
                {
                    item = ItemID.SilverCoin;
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(5, 26);
                    if (Main.rand.NextBool(3)) stack += Main.rand.Next(5, 25);
                }
                else
                {
                    item = ItemID.CopperCoin;
                    if (Main.rand.NextBool(2)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(2)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(2)) stack += Main.rand.Next(10, 26);
                    if (Main.rand.NextBool(2)) stack += Main.rand.Next(10, 25);
                }
            }
            else if (extractinatorBlockType == TileID.ChlorophyteExtractinator)
            {
                item = Main.rand.Next(14) switch
                {
                    0 => ItemID.CopperOre,
                    1 => ItemID.IronOre,
                    2 => ItemID.SilverOre,
                    3 => ItemID.GoldOre,
                    4 => ItemID.TinOre,
                    5 => ItemID.LeadOre,
                    6 => ItemID.TungstenOre,
                    7 => ItemID.PlatinumOre,
                    8 => ItemID.CobaltOre,
                    9 => ItemID.PalladiumOre,
                    10 => ItemID.MythrilOre,
                    11 => ItemID.OrichalcumOre,
                    12 => ItemID.AdamantiteOre,
                    _ => ItemID.TitaniumOre,
                };
                if (Main.rand.NextBool(20)) stack += Main.rand.Next(0, 2);
                if (Main.rand.NextBool(30)) stack += Main.rand.Next(0, 3);
                if (Main.rand.NextBool(40)) stack += Main.rand.Next(0, 4);
                if (Main.rand.NextBool(50)) stack += Main.rand.Next(0, 5);
                if (Main.rand.NextBool(60)) stack += Main.rand.Next(0, 6);
            }
            else
            {
                item = Main.rand.Next(8) switch
                {
                    0 => ItemID.CopperOre,
                    1 => ItemID.IronOre,
                    2 => ItemID.SilverOre,
                    3 => ItemID.GoldOre,
                    4 => ItemID.TinOre,
                    5 => ItemID.LeadOre,
                    6 => ItemID.TungstenOre,
                    _ => ItemID.PlatinumOre,
                };
                if (Main.rand.NextBool(20)) stack += Main.rand.Next(0, 2);
                if (Main.rand.NextBool(30)) stack += Main.rand.Next(0, 3);
                if (Main.rand.NextBool(40)) stack += Main.rand.Next(0, 4);
                if (Main.rand.NextBool(50)) stack += Main.rand.Next(0, 5);
                if (Main.rand.NextBool(60)) stack += Main.rand.Next(0, 6);
            }

            if (item > 0)
                Utils.DropItemFromExtractinator(player, item, stack);
        }
    }
}
