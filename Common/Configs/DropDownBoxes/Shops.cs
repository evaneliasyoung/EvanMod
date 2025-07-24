using System.ComponentModel;

namespace EvanMod.Common.Configs.DropDownBoxes
{
    public class Shops
    {
        [DefaultValue(false)]
        public bool MerchantSellsGreaterHealing;

        [DefaultValue(false)]
        public bool MerchantSellsSuperHealing;

        [DefaultValue(false)]
        public bool WizardSellsSuperMana;

        [DefaultValue(false)]
        public bool WizardSellsVoodooDolls;

        [DefaultValue(false)]
        public bool DryadSellsHerbBag;

        public override bool Equals(object obj)
        {
            if (obj is Shops other)
                return
                MerchantSellsGreaterHealing == other.MerchantSellsGreaterHealing &&
                MerchantSellsSuperHealing == other.MerchantSellsSuperHealing &&
                WizardSellsSuperMana == other.WizardSellsSuperMana &&
                WizardSellsVoodooDolls == other.WizardSellsVoodooDolls &&
                DryadSellsHerbBag == other.DryadSellsHerbBag;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return new
            {
                MerchantSellsGreaterHealing,
                MerchantSellsSuperHealing,
                WizardSellsSuperMana,
                WizardSellsVoodooDolls,
                DryadSellsHerbBag,
            }.GetHashCode();
        }
    }
}
