using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EvanMod.Common
{
    public class GlobalPlayer : ModPlayer
    {
        public const int DashDown = 0;
        public const int DashUp = 1;
        public const int DashRight = 2;
        public const int DashLeft = 3;

        public const int DashCooldown = 50;
        public const int DashDuration = 35;
        public const float DashVelocity = 10f;

        public int dashDirection;
        public int dashDelay;
        public int docDash;
        public bool usedDoC;

        public override void Initialize()
        {
            dashDirection = -1;
            dashDelay = 0;
            docDash = 0;
            usedDoC = false;
        }

        public override void ResetEffects()
        {
            if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
            {
                dashDirection = DashDown;
            }
            else if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[DashUp] < 15)
            {
                dashDirection = DashUp;
            }
            else if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
            {
                dashDirection = DashRight;
            }
            else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
            {
                dashDirection = DashLeft;
            }
            else
            {
                dashDirection = -1;
            }
        }

        public override void PreUpdateMovement()
        {
            if (CanUseDash() && dashDirection != -1 && dashDelay == 0)
            {
                Vector2 newVelocity = Player.velocity;

                switch (dashDirection)
                {
                    case DashUp when Player.velocity.Y > -DashVelocity:
                    case DashDown when Player.velocity.Y < DashVelocity:
                        {
                            float dashDirection = this.dashDirection == DashDown ? 1 : -1.3f;
                            newVelocity.Y = dashDirection * DashVelocity;
                            break;
                        }
                    case DashLeft when Player.velocity.X > -DashVelocity:
                    case DashRight when Player.velocity.X < DashVelocity:
                        {
                            float dashDirection = this.dashDirection == DashRight ? 1 : -1;
                            newVelocity.X = dashDirection * DashVelocity;
                            break;
                        }
                    default:
                        return;
                }

                dashDelay = DashCooldown;
                docDash = DashDuration;
                Player.velocity = newVelocity;
            }

            if (dashDelay > 0)
            {
                --dashDelay;
            }

            if (docDash > 0)
            {
                Player.eocDash = docDash;
                Player.armorEffectDrawShadowEOCShield = true;
                --docDash;
            }
        }

        private bool CanUseDash()
        {
            return usedDoC
                && Player.dashType == DashID.None
                && !Player.setSolar
                && !Player.mount.Active;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write((byte)EvanMod.MessageType.UseDefenderOfCthulhu);
            packet.Write((byte)Player.whoAmI);
            packet.Write(usedDoC);
            packet.Send(toWho, fromWho);
        }

        public void ReceivePlayerSync(BinaryReader reader)
        {
            usedDoC = reader.ReadBoolean();
        }

        public override void CopyClientState(ModPlayer targetCopy)
        {
            GlobalPlayer clone = (GlobalPlayer)targetCopy;
            clone.usedDoC = usedDoC;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            GlobalPlayer clone = (GlobalPlayer)clientPlayer;

            if (usedDoC != clone.usedDoC)
            {
                SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag["usedDoC"] = usedDoC;
        }

        public override void LoadData(TagCompound tag)
        {
            usedDoC = tag.GetBool("usedDoC");
        }
    }
}
