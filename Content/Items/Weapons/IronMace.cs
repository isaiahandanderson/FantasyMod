﻿using FantasyMod2.Content.DamageClasss;
using FantasyMod2.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons
{
    public class IronMace : ModItem
    {
        public override void SetDefaults()
        {
            // Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools

            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 5);
            Item.maxStack = 999;

            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.consumable = true;

            // Weapon Properties			
            Item.damage = 33;
            Item.knockBack = 5f;
            Item.noUseGraphic = true; // The item should not be visible when used
            Item.noMelee = true; // The projectile will do the damage and not the item
            Item.DamageType = ModContent.GetInstance<CrusherDamage>();

            // Projectile Properties
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Mace>(); // The projectile that will be thrown
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(15);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}