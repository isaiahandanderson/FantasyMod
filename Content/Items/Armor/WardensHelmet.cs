using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FantasyMod2.Content.Items.Armor
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class WardensHelmet : ModItem
    {
        public static readonly int AdditiveGenericDamageBonus = 20;

        public static LocalizedText SetBonusText { get; private set; }

      

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 5; // The amount of defense the item will give when equipped
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
      

        // UpdateArmorSet allows you to give set bonuses to the armor.
       

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
      
    }
}