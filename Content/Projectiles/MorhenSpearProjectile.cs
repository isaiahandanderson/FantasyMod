﻿using FantasyMod2.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Projectiles;

public class MorhenSpearProjectile : ModProjectile
{

    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 19;
        Projectile.penetrate = -1;
        Projectile.scale = 1.3f;
        Projectile.alpha = 0;

        Projectile.hide = true;
        Projectile.ownerHitCheck = true;
        Projectile.tileCollide = false;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Melee;
    }

    // In here the AI uses this example, to make the code more organized and readable
    // Also showcased in ExampleJavelinProjectile.cs
    public float movementFactor // Change this value to alter how fast the spear moves
    {
        get => Projectile.ai[0];
        set => Projectile.ai[0] = value;
    }

    // It appears that for this AI, only the ai0 field is used!
    public override void AI()
    {
        // Since we access the owner player instance so much, it's useful to create a helper local variable for this
        // Sadly, Projectile/ModProjectile does not have its own
        Player projOwner = Main.player[Projectile.owner];
        // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
        Projectile.direction = projOwner.direction;
        projOwner.heldProj = Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        
        // As long as the player isn't frozen, the spear can move
        if (!projOwner.frozen)
        {
            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                Projectile.netUpdate = true; // Make sure to netUpdate this spear
            }
            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
            {
                movementFactor -= 2.4f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 2.1f;
            }
        }
        // Change the spear position based off of the velocity and the movementFactor
        Projectile.position += Projectile.velocity * movementFactor;
        // When we reach the end of the animation, we can kill the spear projectile
        if (projOwner.itemAnimation == 0)
        {
            Projectile.Kill();
        }
        // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
        // MathHelper.ToRadians(xx degrees here)
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
        // Offset by 90 degrees here
        if (Projectile.spriteDirection == -1)
        {
            Projectile.rotation -= MathHelper.ToRadians(90f);
        }

        }
    }