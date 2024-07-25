using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Back)]
    public class TheRedBanner : ModItem
    {
     

        // This IL editing (Intermediate Language editing) example is walked through in the guide: https://github.com/tModLoader/tModLoader/wiki/Expert-IL-Editing#example---hive-pack-upgrade
     

        public override void SetDefaults()
        {
            int realBackSlot = Item.backSlot;
            Item.CloneDefaults(ItemID.HiveBackpack);
            Item.value = Item.sellPrice(0, 5);
            // CloneDefaults will clear out the autoloaded Back slot, so we need to preserve it this way.
            Item.backSlot = realBackSlot;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // The original Hive Pack sets strongBees.
            player.strongBees = true;
         
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            // Don't allow Hive Pack and Wasp Nest to be equipped at the same time.
            return incomingItem.type != ItemID.HiveBackpack;
        }
    }

 
}