using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace nilzermod.Content.Items.Accessories
{
    internal class nursepills : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToAccessory();

            Item.accessory = true;

            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);

            player.GetAttackSpeed(DamageClass.Generic) += 0.2f;        
                
        }

        public class TownNPCAcessoryDrop : GlobalNPC
        {
            public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
            {
                if (npc.type == NPCID.Nurse)
                {
                    int itemID = ModContent.ItemType<Items.Accessories.nursepills>();
                    npcLoot.Add(ItemDropRule.Common(itemID, chanceDenominator: 3));
                }
            }
        }

    }
}
