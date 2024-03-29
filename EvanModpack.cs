/**
*  @file      EvanModpack.cs
*  @brief     The main entry point for the modpack.
*/

using Terraria.ModLoader;

namespace EvanModpack
{
    internal class EvanModpack : Mod
    {
        public static EvanModpack Instance;

        public override void Load()
        {
            Instance = this;
        }
    }
}
