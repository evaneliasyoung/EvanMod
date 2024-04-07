using Terraria.ModLoader.Config;

namespace EvanMod.Common.Config
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Expand(false)]
        public DropDownBoxes.BattlePotion BattlePotion;

        [Expand(false)]
        public DropDownBoxes.Shops Shops;

        public ServerConfig()
        {
            BattlePotion = new DropDownBoxes.BattlePotion();
            Shops = new DropDownBoxes.Shops();
        }
    }
}
