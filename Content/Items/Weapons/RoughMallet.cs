using ExampleMod.Content.Rarities;
using FantasyMod2.Content.Projectiles;
using FantasyMod2.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons
{
    // This is a basic item template.
    // Please see tModLoader's ExampleMod for every other example:
    // https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
    public class RoughMallet : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.FantasyMod2.hjson' file.
        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ModContent.RarityType<Undead>();
            Item.shootSpeed = 10;
            Item.shoot = ModContent.ProjectileType<MalletProj>();
            Item.UseSound = SoundID.Item10;
            Item.autoReuse = true;
            Item.hammer = 30;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 12);
            recipe.AddIngredient(ItemID.Wood, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient<BloodiedVile>(5);
            recipe.Register();
        }
    }
}
