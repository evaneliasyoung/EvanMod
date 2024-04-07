using Terraria;
using Terraria.ModLoader;

namespace EvanMod.Content.Buffs
{
    internal class GreaterBattle : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
        }
    }
}