using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EvanMod.Content.Tiles
{
    public class HellstoneExtractinator : ModTile
    {
        public static readonly ItemTrader Trader = CreateItemTrader();

        private static ItemTrader CreateItemTrader()
        {
            ItemTrader itemTrader = new ItemTrader();
            itemTrader.AddOption_Interchangable(ItemID.CopperOre, ItemID.TinOre);
            itemTrader.AddOption_Interchangable(ItemID.IronOre, ItemID.LeadOre);
            itemTrader.AddOption_Interchangable(ItemID.SilverOre, ItemID.TungstenOre);
            itemTrader.AddOption_Interchangable(ItemID.GoldOre, ItemID.PlatinumOre);
            itemTrader.AddOption_Interchangable(ItemID.DemoniteOre, ItemID.CrimtaneOre);
            itemTrader.AddOption_CyclicLoop(ItemID.BlueBrick, ItemID.GreenBrick, ItemID.PinkBrick);
            itemTrader.AddOption_Interchangable(ItemID.CopperBar, ItemID.TinBar);
            itemTrader.AddOption_Interchangable(ItemID.IronBar, ItemID.LeadBar);
            itemTrader.AddOption_Interchangable(ItemID.SilverBar, ItemID.TungstenBar);
            itemTrader.AddOption_Interchangable(ItemID.GoldBar, ItemID.PlatinumBar);
            itemTrader.AddOption_Interchangable(ItemID.DemoniteBar, ItemID.CrimtaneBar);
            itemTrader.AddOption_Interchangable(ItemID.ShadowScale, ItemID.TissueSample);
            return itemTrader;
        }

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileObsidianKill[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Extractinator, 0));
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(0xEE, 0x55, 0x46), name);

            AnimationFrameHeight = 54;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            // Terraria.Graphics.Light.TileLightScanner.ApplyTileLight
            // Values taken from the Hellforge
            r = 0.75f;
            g = 0.45f;
            b = 0.25f;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.Extractinator];
        }
    }
}
