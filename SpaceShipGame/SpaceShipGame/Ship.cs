using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipGame
{
    class Ship
    {
        public Vector2 position = new Vector2(100, 100);
        public int speed = 180;
        public void ShipUpdate(GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))
            {
                position.X -= speed * dt;
            }

            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right))
            {
                position.X += speed * dt;
            }

            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))
            {
                position.Y += speed * dt;
            }

            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))
            {
                position.Y -= speed * dt;
            }
        }
    }
}
