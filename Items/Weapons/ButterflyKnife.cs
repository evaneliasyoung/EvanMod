/**
*  @file      ButterflyKnife.cs
*  @brief     Adds a fast and deadly butterfly-knife.
*
*  @author    Evan Elias Young
*  @date      2017-07-17
*  @date      2019-04-16
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
		public static int InstantKillChance = 3;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Butterfly Knife");
			Tooltip.SetDefault(string.Format("That spy is not ours!\nHas a {0}% chance to instantly kill the target.", InstantKillChance));

			DisplayName.AddTranslation(GameCulture.Spanish, "Navaja");
			Tooltip.AddTranslation(GameCulture.Spanish, string.Format("¡Ese espía no es nuestro!\nTiene una {0}% posibilidad a mata al instante el blanco", InstantKillChance));
			DisplayName.AddTranslation(GameCulture.German, "Klappmesser");
			Tooltip.AddTranslation(GameCulture.German, string.Format("Das Spion ist nicht unsere!\nHat eine {0}% ige Chance, um sofort weiß zu töten", InstantKillChance));
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
			if (Main.rand.Next(100 / InstantKillChance) == 0)
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
