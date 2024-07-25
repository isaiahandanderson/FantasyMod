using FantasyMod2.Content.Items.Mounts;
using FantasyMod2.Content.Mounts;
using Terraria;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Buffs
{
    public class YoshiBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<YoshiMount>(), player);
            player.buffTime[buffIndex] = 10;
            
        }
    }
}