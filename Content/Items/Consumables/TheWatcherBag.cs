using FantasyMod2.Content.Items.Armor;
using FantasyMod2.Content.NPCs;
using FantasyMod2.Content.Items;

using FantasyMod2.Content.NPCs;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using FantasyMod2.Content.Items.Weapons;
using FantasyMod2.Content.Items.Weapons.Guns;

namespace FantasyMod2.Content.Items.Consumables
{
    // Basic code for a boss treasure bag
    public class TheWatcherBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            // This set is one that every boss bag should have.
            // It will create a glowing effect around the item when dropped in the world.
            // It will also let our boss bag drop dev armor..
            ItemID.Sets.BossBag[Type] = true;
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true; // ..But this set ensures that dev armor will only be dropped on special world seeds, since that's the behavior of pre-hardmode boss bags.

            Item.ResearchUnlockCount = 3;
        }

        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true; // This makes sure that "Expert" displays in the tooltip and the item name color changes
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            // We have to replicate the expert drops from MinionBossBody here

            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<StarHead>(), 7));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<WatcherCube>(), 1, 12, 16));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BarToEntry>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<StalkerBlade>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheWatchersLash>(), 1, 1, 1));
            itemLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(ModContent.NPCType<TheWatcherBody>()));
        }
    }
}