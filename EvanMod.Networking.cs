using EvanMod.Common;
using System.IO;
using Terraria;
using Terraria.ID;

namespace EvanMod
{
    public partial class EvanMod
    {
        internal enum MessageType : byte
        {
            UseDefenderOfCthulhu
        }

        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            MessageType msgType = (MessageType)reader.ReadByte();

            switch (msgType)
            {
                case MessageType.UseDefenderOfCthulhu:
                    byte playerNumber = reader.ReadByte();
                    GlobalPlayer player = Main.player[playerNumber].GetModPlayer<GlobalPlayer>();
                    player.ReceivePlayerSync(reader);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        player.SyncPlayer(-1, whoAmI, false);
                    }
                    break;
                default:
                    Logger.WarnFormat("EvanMod: Unknown Message type: {0}", msgType);
                    break;
            }
            base.HandlePacket(reader, whoAmI);
        }
    }
}
