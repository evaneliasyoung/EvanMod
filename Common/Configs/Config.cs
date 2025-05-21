using Terraria.ModLoader.Config;

namespace EvanMod.Common.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Expand(false)]
        public DropDownBoxes.BattlePotions BattlePotions;

        [Expand(false)]
        public DropDownBoxes.Shops Shops;

        public ServerConfig()
        {
            BattlePotions = new DropDownBoxes.BattlePotions();
            Shops = new DropDownBoxes.Shops();
        }
    }
}
