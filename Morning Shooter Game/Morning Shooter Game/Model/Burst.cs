﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Morning_Shooter_Game.View;

namespace Morning_Shooter_Game.Model
{
    class Burst
    {
        Random random;
         // Image representing the Projectile
        public Texture2D Texture;

        // Position of the Projectile relative to the upper left side of the screen
        public Vector2 Position;

        // State of the Projectile
        public bool Active;

        // The amount of damage the projectile can inflict to an enemy
        public int Damage;

        // Represents the viewable boundary of the game
        Viewport viewport;

        // Get the width of the projectile ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the projectile ship
        public int Height
        {
            get { return Texture.Height; }
        }

        // Determines how fast the projectile moves
        float projectileMoveSpeed1;



        public void Initialize(Viewport viewport, Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            this.viewport = viewport;

            Active = true;
            random = new Random(100);
            Damage = 20;

            projectileMoveSpeed1 = 30f;
        }
        public void Update()
        {
            // Projectiles always move to the right
            Position.X += projectileMoveSpeed1;
            Position.Y += Position.X/2;
            // Deactivate the bullet if it goes out of screen
            if (Position.X + Texture.Width / 2 > viewport.Width)
                Active = false;
            if (Position.Y + Texture.Width / 2 > viewport.Width)
                Active = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }

    }
}

 
