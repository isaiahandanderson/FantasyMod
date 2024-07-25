﻿using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using FantasyMod2.Content.Items.Weapons;
using FantasyMod2.Content.Rarities;

namespace FantasyMod2.Content.Items.Weapons.GardenUpdate
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class GardenScythe : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.FantasyMod2.hjson' file.
        public override void SetDefaults()
        {
            Item.damage = 67;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ModContent.RarityType<Garden>();
            Item.UseSound = SoundID.Item10;
            Item.autoReuse = true;
        }



       

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenSword, 1);

            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}