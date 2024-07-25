using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using FantasyMod2.Content.Items.Accessories;

namespace FantasyMod2.Content.Items.Accessories;

public class RancherBoots : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.accessory = true;
        Item.value = Item.sellPrice(silver: 30);
        Item.rare = ItemRarityID.Blue;
    }


    public override int ChoosePrefix(UnifiedRandom rand)
    {
        // When the item is given a prefix, only roll the best modifiers for accessories
        return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe(1);
        recipe.AddIngredient(ItemID.TerrasparkBoots, 2);
        recipe.AddIngredient(ItemID.ManaCrystal, 2);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}