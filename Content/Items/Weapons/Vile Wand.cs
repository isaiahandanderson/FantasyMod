using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using FantasyMod2.Content.Items.Weapons;

namespace FantasyMod2.Content.Items.Weapons
{
    internal class VileWand : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 8;
            Item.damage = 56;
            Item.knockBack = 3.2f;

            Item.useTime = 20;
            Item.useAnimation = 15;

            Item.UseSound = SoundID.Item71;

            Item.shoot = Mod.Find <ModProjectile>("VileWandProjectile").Type;
            Item.shootSpeed = 1f;
        }
    }
}