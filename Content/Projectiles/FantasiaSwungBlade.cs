
using FantasyMod2.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Projectiles
{
    public class FantasiaSwungBlade : ModProjectile
    {
        
        public Player Owner => Main.player[Projectile.owner];

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 246;
            Projectile.height = 184;
            Projectile.scale = 1.15f;

            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ownerHitCheck = true;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 3;
        }

        public override void AI()
        {
            Projectile.frameCounter++;
            Projectile.frame = Projectile.frameCounter / 3;
            if (Projectile.frame >= Main.projFrames[Projectile.type])
                Projectile.Kill();

           

            // Rotation and directioning.
            Projectile.direction = (Projectile.velocity.X > 0).ToDirectionInt();

            // Sprite and player directioning.
            Projectile.spriteDirection = -Projectile.direction;
            if (Projectile.direction == 1)
                Projectile.Left = Owner.MountedCenter;
            else
                Projectile.Right = Owner.MountedCenter;
            Projectile.position.X += Projectile.spriteDirection == 0 ? 20f : 10f;
            Projectile.position.Y -= Projectile.scale * 150f;
            Owner.ChangeDir(Projectile.direction);

            // Prevents the projectile from dying
            Projectile.timeLeft = 2;

            // Player item-based field manipulation.
            Owner.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
            Owner.heldProj = Projectile.whoAmI;
            Owner.itemTime = 2;
            Owner.itemAnimation = 2;
        }

        public void HandleChannelMovement(Vector2 playerRotatedPoint)
        {
            Vector2 newVelocity = Vector2.UnitX * (Main.MouseWorld.X > playerRotatedPoint.X).ToDirectionInt();

            // Sync if a velocity component changes.
            if (Projectile.velocity.X != newVelocity.X || Projectile.velocity.Y != newVelocity.Y)
                Projectile.netUpdate = true;

            Projectile.velocity = newVelocity;
        }

      

      

        public override Color? GetAlpha(Color lightColor) => new Color(200, 200, 200, 170);

        // Don't suffer from the same issues Murasama did in the past; encouraging people to kill their wrists for some extra DPS is bad lmao
        public override bool? CanDamage() => Projectile.frameCounter > 6;
    }
}