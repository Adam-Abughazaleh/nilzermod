using Microsoft.Xna.Framework;
using nilzermod.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace nilzermod.Content.Items.Weapons
{
    public class magicspear : ModItem
    {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Spears[Item.type] = true; 
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(54, 54);

            Item.DamageType = DamageClass.Melee;
            Item.damage = 68;
            Item.crit = 12;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.noMelee = true;

            Item.useAnimation = 30;
            Item.useTime = 30;

            Item.knockBack = 6f;

            Item.noUseGraphic = true;

            Item.shoot = ModContent.ProjectileType<magicspearprojectile>();

            Item.autoReuse = true;

            Item.shootSpeed = 4f;

            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 3);

            Item.scale = 1f;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst, 18);
            recipe.AddIngredient(ItemID.SoulofLight, 12);
            recipe.AddIngredient(ItemID.GoldBar, 18);
            recipe.AddIngredient(ItemID.Spear, 1);
            recipe.AddIngredient(ItemID.CrystalShard, 24);

            recipe.AddTile(TileID.CrystalBall);
            recipe.Register();

            Recipe recipealternate = CreateRecipe();
            recipealternate.AddIngredient(ItemID.Amethyst, 18);
            recipealternate.AddIngredient(ItemID.SoulofLight, 12);
            recipealternate.AddIngredient(ItemID.PlatinumBar, 18);
            recipealternate.AddIngredient(ItemID.Spear, 1);
            recipealternate.AddIngredient(ItemID.CrystalShard, 24);

            recipealternate.AddTile(TileID.CrystalBall);
            recipealternate.Register();

        }

    }

}
