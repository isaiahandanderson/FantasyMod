using FantasyMod2.Content.Projectiles;

using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons
{
    // ExampleStaff is a typical staff. Staffs and other shooting weapons are very similar, this example serves mainly to show what makes staffs unique from other items.
    // Staff sprites, by convention, are angled to point up and to the right. "Item.staff[Type] = true;" is essential for correctly drawing staffs.
    // Staffs use mana and shoot a specific projectile instead of using ammo. Item.DefaultToStaff takes care of that.
    public class JadeCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
        }

        public override void SetDefaults()
        {
            // DefaultToStaff handles setting various Item values that magic staff weapons use.
            // Hover over DefaultToStaff in Visual Studio to read the documentation!
            Item.DefaultToStaff(ModContent.ProjectileType<SparklingBall>(), 16, 25, 12);

            // Customize the UseSound. DefaultToStaff sets UseSound to SoundID.Item43, but we want SoundID.Item20
            Item.UseSound = SoundID.Item20;

            // Set damage and knockBack
            Item.SetWeaponValues(23, 5);

            // Set rarity and value
            Item.SetShopValues(ItemRarityColor.Green2, 10000);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<JadeChunk>(9);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}