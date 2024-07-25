

using FantasyMod2.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Weapons
{
    public class Fantasia : ModItem, ILocalizedModType
    {
      
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 146;
            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 12;
            Item.useTurn = true;
            Item.knockBack = 6f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
             
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.shoot = ModContent.ProjectileType<FantasiaSwungBlade>();
            Item.shootSpeed = 24f;
            Item.rare = ItemRarityID.Yellow;
        }

        // Terraria seems to really dislike high crit values in SetDefaults
        public override void ModifyWeaponCrit(Player player, ref float crit) => crit += 45;

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] <= 0;

        
      
    }
}