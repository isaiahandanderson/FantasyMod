﻿using System;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Projectiles
{
    public class MalletProj : ModProjectile
    {
        public new string LocalizationCategory => "Projectiles.Melee";
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Melee;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255);
        }



        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, (255 - Projectile.alpha) * 0f / 255f, (255 - Projectile.alpha) * 0.35f / 255f, (255 - Projectile.alpha) * 0.35f / 255f);
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 1)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 1)
            {
                Projectile.frame = 0;
            }
            if (Projectile.velocity.X < 0f)
            {
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
            else
            {
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
            if (Main.rand.NextBool())
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GemRuby, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 0, new Color(255, 255, 255), 0.5f);
            }
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i <= 10; i++)
            {
                Dust dust;
                Vector2 position = new Vector2(Projectile.position.X - 4, Projectile.position.Y - 4);
                dust = Main.dust[Terraria.Dust.NewDust(position, 58, 58, DustID.GemRuby, 0f, 0f, 0, new Color(255, 255, 255), 0.4605263f)];
                dust.noGravity = true;
                dust.fadeIn = 0.9473684f;
            }
        }
    }
}