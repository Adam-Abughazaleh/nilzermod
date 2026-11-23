using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace nilzermod.Content.Items.Accessories
{
    internal class zenithExpertAccessory : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();
            Item.defense = 2;
            Item.value = Item.buyPrice(gold : 75);
            Item.rare = ItemRarityID.Expert;

        }

        /* this method runs every single frame when item equiped,
         for every frame the player has this equiped the varible 
        equipped == true for every instance of the varible equipped 
        in this program*/
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.RoyalGel], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.EoCShield], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.WormScarf], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.BrainOfConfusion], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.HiveBackpack], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.BoneGlove], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.BoneHelm], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.VolatileGelatin], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.SporeSac], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.ShinyStone], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.EmpressFlightBooster], hideVisual);
            player.ApplyEquipFunctional(ContentSamples.ItemsByType[ItemID.LongRainbowTrailWings], hideVisual);

        }   

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RoyalGel);
            recipe.AddIngredient(ItemID.EoCShield);
            recipe.AddIngredient(ItemID.WormScarf);
            recipe.AddIngredient(ItemID.BrainOfConfusion);
            recipe.AddIngredient(ItemID.HiveBackpack);
            recipe.AddIngredient(ItemID.BoneGlove);
            recipe.AddIngredient(ItemID.BoneHelm);
            recipe.AddIngredient(ItemID.VolatileGelatin);
            recipe.AddIngredient(ItemID.SporeSac);
            recipe.AddIngredient(ItemID.ShinyStone);
            recipe.AddIngredient(ItemID.EmpressFlightBooster);
            recipe.AddIngredient(ItemID.LongRainbowTrailWings);

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }


public class ShieldRestriction : GlobalItem
    {
        // Items that can't be worn together with your shield
        private static readonly HashSet<int> BlockedWithShield = new()
    {
        ItemID.RoyalGel,
        ItemID.EoCShield,             // Shield of Cthulhu
        ItemID.WormScarf,
        ItemID.BrainOfConfusion,
        ItemID.HiveBackpack,          // Hive Pack
        ItemID.BoneGlove,
        ItemID.BoneHelm,
        ItemID.VolatileGelatin,
        ItemID.SporeSac,
        ItemID.ShinyStone,
        ItemID.EmpressFlightBooster,  // Soaring Insignia
        ItemID.LongRainbowTrailWings,    // Celestial Starboard
    };

        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            if (slot >= 10) return true; // ignore vanity slots

            int myShield = ModContent.ItemType<zenithExpertAccessory>(); 

            // Case 1: equipping a blocked item while the shield is worn
            if (BlockedWithShield.Contains(item.type))
            {
                for (int i = 3; i < 10; i++)
                {
                    if (i == slot) continue; // allow swapping the shield out for this item
                    if (player.armor[i].type == myShield)
                        return false;
                }
            }

            // Case 2: equipping the shield while a blocked item is worn
            if (item.type == myShield)
            {
                for (int i = 3; i < 10; i++)
                {
                    if (i == slot) continue;
                    if (BlockedWithShield.Contains(player.armor[i].type))
                        return false;
                }
            }

            return true;
        }
    }
}
}
