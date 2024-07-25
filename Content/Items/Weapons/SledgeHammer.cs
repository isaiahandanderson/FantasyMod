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
    public class SledgeHammer : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.FantasyMod2.hjson' file.
        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 12;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ModContent.RarityType<Undead>();
            Item.shootSpeed = 8;
            Item.shoot = ModContent.ProjectileType<SledgeProj>();
            Item.UseSound = SoundID.Item10;
            Item.autoReuse = true;
            Item.hammer = 60;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalladiumBar, 12);
            recipe.AddIngredient(ItemID.Wood, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient<BloodiedVile>(14);
            recipe.AddIngredient<RoughMallet>(1);
            recipe.Register();
        }
    }
}
