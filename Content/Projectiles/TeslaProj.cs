﻿using FantasyMod2.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Projectiles
{
    public class TeslaProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
        }
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 3;
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.75f;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }



        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.ai[0] += 0.1f;
            Projectile.velocity *= 0.75f;
        }
    }
}