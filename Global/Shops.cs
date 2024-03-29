using EvanModpack.Configuration;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace EvanModpack.Global
{
    public class Shops : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            switch (shop.NpcType)
            {
                case NPCID.Dryad:
                    if (GetInstance<ServerConfig>().Shops.DryadSellsHerbBag)
                    {
                        shop.Add(ItemID.HerbBag, Condition.DownedSkeletron);
                    }
                    break;
                case NPCID.Wizard:
                    if (GetInstance<ServerConfig>().Shops.WizardSellsSuperMana)
                    {
                        if (shop.TryGetEntry(ItemID.ManaPotion, out NPCShop.Entry addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.SuperManaPotion), Condition.DownedMechBossAll);
                        }
                        else
                        {
                            shop.Add(ItemID.SuperManaPotion, Condition.DownedMechBossAll);
                        }
                    }
                    if (GetInstance<ServerConfig>().Shops.WizardSellsVoodooDolls)
                    {
                        shop.Add(ItemID.ClothierVoodooDoll, Condition.DownedSkeletron);
                        shop.Add(ItemID.GuideVoodooDoll, Condition.Hardmode);
                    }
                    break;
                case NPCID.Merchant:
                    if (GetInstance<ServerConfig>().Shops.MerchantSellsGreaterHealing)
                    {
                        if (shop.TryGetEntry(ItemID.HealingPotion, out NPCShop.Entry addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.GreaterHealingPotion), Condition.DownedMechBossAll);
                        }
                        else if (shop.TryGetEntry(ItemID.LesserHealingPotion, out addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.GreaterHealingPotion), Condition.DownedMechBossAll);
                        }
                        else
                        {
                            shop.Add(ItemID.GreaterHealingPotion, Condition.DownedMechBossAll);
                        }
                    }
                    if (GetInstance<ServerConfig>().Shops.MerchantSellsSuperHealing)
                    {
                        if (shop.TryGetEntry(ItemID.GreaterHealingPotion, out NPCShop.Entry addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.SuperHealingPotion), Condition.DownedMechBossAll);
                        }
                        else if (shop.TryGetEntry(ItemID.HealingPotion, out addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.SuperHealingPotion), Condition.DownedMechBossAll);
                        }
                        else if (shop.TryGetEntry(ItemID.LesserHealingPotion, out addAfter))
                        {
                            shop.InsertAfter(addAfter, new Item(ItemID.SuperHealingPotion), Condition.DownedMechBossAll);
                        }
                        else
                        {
                            shop.Add(ItemID.SuperHealingPotion, Condition.DownedMechBossAll);
                        }
                    }
                    break;
                default:
                    break;
            }

            base.ModifyShop(shop);
        }
    }
}
