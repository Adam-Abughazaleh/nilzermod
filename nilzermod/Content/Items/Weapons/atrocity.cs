using Microsoft.Xna.Framework;
using nilzermod.Content.Projectiles;
using System.Security.Policy;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace nilzermod.Content.Items.Weapons
{
    public class atrocity : ModItem
    {
        private Vector2 velocity;
        public override void SetDefaults()
        {
            Item.Size = new Vector2(44, 28);

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 3;
            Item.crit = 0;
            Item.width = 44;
            Item.height = 28;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item38;
            Item.useAmmo = AmmoID.Bullet;

            Item.shoot = ProjectileID.Bullet;
            Item.useTime = 1;
            Item.useAnimation = 1;

            Item.knockBack = 1f;

            Item.autoReuse = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.LightRed;

            Item.shootSpeed = 12f;
            Item.ArmorPenetration = 25;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -4f);
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.66f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
            velocity = perturbedSpeed;
            Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);

            return false;
        }

        private float _currentSpreadRotation;

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15f));
            _currentSpreadRotation = velocity.ToRotation();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (velocity == Vector2.Zero)
                return;

            player.direction = velocity.X >= 0 ? 1 : -1;

            float rotation = velocity.ToRotation();
            player.itemRotation = velocity.ToRotation();

            if (player.direction == -1)
            {
                rotation += MathHelper.Pi;
            }

            player.itemRotation = MathHelper.WrapAngle(rotation) * player.gravDir;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.FlintlockPistol, 1);
            recipe.AddIngredient(ItemID.Wire, 100);
            recipe.AddIngredient(ItemID.MechanicalLens, 1);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }

}

