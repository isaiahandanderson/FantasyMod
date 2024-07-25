using FantasyMod2.Content.Items.Weapons;
using Terraria;
using Terraria.ModLoader;
using FantasyMod2.Content.Projectiles;

namespace FantasyMod2.Common.GlobalNPCs
{
    internal class DamageOverTimeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool steel;

        public override void ResetEffects(NPC npc)
        {
            steel = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (steel)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                // Count how many ExampleJavelinProjectile are attached to this npc.
                int LanProjCount = 0;
                foreach (var p in Main.ActiveProjectiles)
                {
                    if (p.type == ModContent.ProjectileType<LanProj>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        LanProjCount++;
                    }
                }
                // Remember, lifeRegen affects the actual life loss, damage is just the text.
                // The logic shown here matches how vanilla debuffs stack in terms of damage numbers shown and actual life loss.
                npc.lifeRegen -= LanProjCount * 2 * 3;
                if (damage < LanProjCount * 3)
                {
                    damage =LanProjCount * 3;
                }
            }
        }

    }
}