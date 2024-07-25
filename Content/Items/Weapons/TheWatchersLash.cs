
using ExampleMod.Content.Rarities;
using FantasyMod2.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons
{
    public class TheWatchersLash : ModItem
    {
        

        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.DefaultToWhip(ModContent.ProjectileType<Lash>(), 60, 2, 4);
            Item.rare = ModContent.RarityType<Watcher>();
            Item.channel = true;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        

        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}