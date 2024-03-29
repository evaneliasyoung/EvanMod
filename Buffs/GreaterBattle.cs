using Terraria;
using Terraria.ModLoader;

namespace EvanModpack.Buffs
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
