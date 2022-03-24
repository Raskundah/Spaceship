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

        public void ShipUpdate()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))
            {
                position.X--;
            }

            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right))
            {
                position.X++;
            }

            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))
            {
                position.Y++;
            }

            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))
            {
                position.Y--;
            }
        }
    }
}
