/**
*  @file      ButterflyKnife.cs
*  @brief     Adds a fast and deadly butterfly-knife.
*
*  @author    Evan Elias Young
*  @date      2017-07-17
*  @date      2019-04-20
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Weapons
{
	internal class ButterflyKnife : ModItem
	{
		public const int InstantKillChance = 3;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(Language.GetTextValue("Mods.EvanModpack.ItemName.ButterflyKnife"));
			Tooltip.SetDefault(Language.GetTextValue("Mods.EvanModpack.ItemTooltip.ButterflyKnife", InstantKillChance));
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.damage = 18;
			item.melee = true;
			item.width = 34;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = Item.sellPrice(0, 0, 35, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			base.SetDefaults();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (Main.rand.Next(1, 100) <= InstantKillChance)
			{
				item.damage = 217500;
			}
			else
			{
				item.damage = 18;
			}
			base.OnHitNPC(player, target, damage, knockBack, crit);
		}
	}
}
