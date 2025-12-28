using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanMod.Common.Systems
{
    public class GlobalRecipeSystem : ModSystem
    {
        public override void AddRecipeGroups()
        {
            // Evil Powder Group
            RecipeGroup GroupPowder = new(() => string.Format("{0} Evil Powder", Language.GetText("LegacyMisc.37").Value), ItemID.ViciousPowder, ItemID.VilePowder);
            RecipeGroup.RegisterGroup("EvanMod:EvilPowder", GroupPowder);

            // Evil Guts Group
            RecipeGroup GroupGuts = new(() => string.Format("{0} Evil Guts", Language.GetText("LegacyMisc.37").Value), ItemID.RottenChunk, ItemID.Vertebrae);
            RecipeGroup.RegisterGroup("EvanMod:EvilGuts", GroupGuts);

            // Evil Yoyos Group
            RecipeGroup GroupEvilYoyos = new(() => string.Format("{0} Evil Yoyo", Language.GetText("LegacyMisc.37").Value), ItemID.CorruptYoyo, ItemID.CrimsonYoyo);
            RecipeGroup.RegisterGroup("EvanMod:EvilYoyos", GroupEvilYoyos);
        }

        public override void AddRecipes()
        {
            AddFoodRecipes();
            AddWeaponRecipes();
            AddMiscellaneousRecipes();
        }

        private static void AddFoodRecipes()
        {
            // Pad Recipe
            Recipe.Create(ItemID.PadThai, 5)
                .AddIngredient(ItemID.Blinkroot, 2)
                .AddIngredient(ItemID.RottenChunk, 2)
                .AddTile(TileID.WorkBenches)
                .Register();

            // Pho Recipe
            Recipe.Create(ItemID.Pho, 5)
                .AddIngredient(ItemID.BottledWater, 5)
                .AddIngredient(ItemID.Blinkroot, 2)
                .AddIngredient(ItemID.RottenChunk, 2)
                .AddTile(TileID.CookingPots)
                .Register();
        }

        private static void AddWeaponRecipes()
        {
            // Cascade Recipe
            Recipe.Create(ItemID.Cascade)
                .AddIngredient(ItemID.HellstoneBar, 12)
                .AddTile(TileID.Anvils)
                .Register();

            // Bone Wand Recipe
            Recipe.Create(ItemID.BoneWand)
                .AddIngredient(ItemID.Bone, 25)
                .AddTile(TileID.BoneWelder)
                .Register();

            // Hive Wand Recipe
            Recipe.Create(ItemID.HiveWand)
                .AddIngredient(ItemID.Hive, 25)
                .AddTile(TileID.HoneyDispenser)
                .Register();

            // Living Wood Wand Recipe
            Recipe.Create(ItemID.LivingWoodWand)
                .AddIngredient(ItemID.Wood, 25)
                .AddTile(TileID.LivingLoom)
                .Register();

            // Leaf Wand Recipe
            Recipe.Create(ItemID.LeafWand)
                .AddIngredient(ItemID.Wood, 25)
                .AddTile(TileID.LivingLoom)
                .Register();

            // Living Mahogany Wand Recipe
            Recipe.Create(ItemID.LivingMahoganyWand)
                .AddIngredient(ItemID.RichMahogany, 25)
                .AddTile(TileID.LivingLoom)
                .Register();

            // Rich Mahogany Leaf Wand Recipe
            Recipe.Create(ItemID.LivingMahoganyLeafWand)
                .AddIngredient(ItemID.RichMahogany, 25)
                .AddTile(TileID.LivingLoom)
                .Register();
        }

        private static void AddMiscellaneousRecipes()
        {
            // Life Fruit Recipe
            Recipe.Create(ItemID.LifeFruit)
                .AddIngredient(ItemID.ChlorophyteBar, 7)
                .AddIngredient(ItemID.LifeCrystal, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            // Gold Chest Recipe
            Recipe.Create(ItemID.GoldChest)
                .AddIngredient(ItemID.GoldBar, 8)
                .AddIngredient(ItemID.IronBar, 2)
                .AddTile(TileID.Anvils)
                .Register();

            // Pirate Map Recipe
            Recipe.Create(ItemID.PirateMap)
                .AddIngredient(ItemID.Sail, 10)
                .AddIngredient(ItemID.Cannonball)
                .AddIngredient(ItemID.GoldBar, 5)
                .AddTile(TileID.DemonAltar)
                .Register();

            // Golden Critters' Setups
            Dictionary<int, int> mapCritters = new()
            {
                { ItemID.Bird, ItemID.GoldBird },
                { ItemID.BlueJay, ItemID.GoldBird },
                { ItemID.Cardinal, ItemID.GoldBird },
                { ItemID.Bunny, ItemID.GoldBunny },
                { ItemID.Frog, ItemID.GoldFrog },
                { ItemID.Grasshopper, ItemID.GoldGrasshopper },
                { ItemID.Mouse, ItemID.GoldMouse },
                { ItemID.Squirrel, ItemID.SquirrelGold },
                { ItemID.SquirrelRed, ItemID.SquirrelGold },
                { ItemID.Worm, ItemID.GoldWorm }
            };

            // Golden Critters' Recipes
            foreach (KeyValuePair<int, int> oldNew in mapCritters)
                Recipe.Create(oldNew.Value)
                    .AddIngredient(ItemID.GoldBar, 2)
                    .AddIngredient(oldNew.Key)
                    .Register();
        }
    }
}
