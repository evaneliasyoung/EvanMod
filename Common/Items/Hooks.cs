using EvanMod.Content.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanMod.Common.Items
{
    public class Hooks : GlobalItem
    {
        // TODO: Fix this edge case, if possible.
        // NOTE: I'm afraid the Terraria source code ItemCheck_CheckCanUse can override the result of this function.
        // This logic includes specific TileID checking to only the builtin extractinators.
        // See Terraria.Player.ItemCheck_CheckCanUse
        // public override bool CanUseItem(Item item, Player player)
        // {
        //     // The items which won't trigger UseItem by default
        //     // but will on an extractinator, have the `chlorophyteExtractinatorConsumable` set to true.
        //     // These are only 2337, 2338, 2339, (junk), and 86 and 1329 (shadow scale & tissue sample).
        //     // We can flag these as usable if we're pointing at any extractinator;
        //     // even though this usage of the flag seems incorrect, Terraria.Player.ItemCheck_CheckCanUse applies this
        //     // flag to the default (silt) extractinator as well.

        //     return (item.chlorophyteExtractinatorConsumable && IsMouseTileHellstoneExtractinator) || base.CanUseItem(item, player);
        // }

        // Terraria.Player.ExtractinatorUse
        // Terraria.Player.PlaceThing_ItemInExtractinator
        public override bool? UseItem(Item item, Player player)
        {
            // Make sure we're over the Hellstone Extractinator
            if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileType != ModContent.TileType<HellstoneExtractinator>())
                return null;

            // Make sure the player is in range
            if (!(player.position.X / 16f - Player.tileRangeX - item.tileBoost - player.blockRange <= Player.tileTargetX) || !((player.position.X + player.width) / 16f + Player.tileRangeX + item.tileBoost - 1f + player.blockRange >= Player.tileTargetX) || !(player.position.Y / 16f - Player.tileRangeY - item.tileBoost - player.blockRange <= Player.tileTargetY) || !((player.position.Y + player.height) / 16f + Player.tileRangeY + item.tileBoost - 2f + player.blockRange >= Player.tileTargetY))
                return null;

            // Variety of checks for the default extractinators
            if (!player.ItemTimeIsZero || player.itemAnimation <= 0 || !player.controlUseItem)
                return null;

            // Handle the conversions
            if (HellstoneExtractinator.Trader.TryGetTradeOption(item, out var option))
            {
                SoundEngine.PlaySound(SoundID.Grab);
                player.itemTime = 5;
                item.stack -= option.TakingItemStack;
                if (item.stack <= 0)
                    item.TurnToAir();
                Utils.DropItemFromExtractinator(player, option.GivingITemType, option.GivingItemStack);

                return false;
            }
            else if (ItemID.Sets.ExtractinatorMode[item.type] >= 0)
            {
                SoundEngine.PlaySound(SoundID.Grab);
                player.itemTime = 5;
                if (--item.stack <= 0)
                    item.TurnToAir();
                Utils.ExtractinatorUse(player, ItemID.Sets.ExtractinatorMode[item.type], ModContent.TileType<HellstoneExtractinator>());

                return false;
            }

            return null;
        }
    }
}
