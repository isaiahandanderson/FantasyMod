﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons.Guns
{
    public class SnowStorm : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.
            // See ExampleGun.SetDefaults to see comments explaining those properties
            Item.DefaultToRangedWeapon(ProjectileID.PurificationPowder, AmmoID.Snowball, 2, 16f, true);

            // Item.SetWeaponValues can quickly set1 damage, knockBack, and crit
            Item.SetWeaponValues(14, 1f);

            Item.width = 54; // Hitbox width of the item.
            Item.height = 22; // Hitbox height of the item.
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
            Item.useAnimation = 12;
            Item.useTime = 4; // one third of useAnimation
            Item.reuseDelay = 14;
            Item.consumeAmmoOnLastShotOnly = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.


        // The following method gives this gun a 38% chance to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.38f;
        }

        // The following method allows this gun to shoot when having no ammo, as long as the player has at least 10 example items in their inventory.
        // The gun will then shoot as if the default ammo for it, in this case the musket ball, is being used.


        // The following method makes the gun slightly inaccurate
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
        }
    }
}