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
        #region Variables

        public Vector2 position = new Vector2(100, 100); // sets base ship position.
        public int regularSpeed = 180; // sets ship base speed.
        public int boostSpeed = 360; // speed increase from boost.
        public float thrustCapacity = 100.0f;
        public void ShipUpdate(GameTime gameTime)

        #endregion
        {
            #region delta time handler

            KeyboardState kState = Keyboard.GetState();
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // using delta time to manage consistent speed.

            #endregion delta time handler


            // movement handling, regular and boost speed.

            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left))

            // Left/Negative X axis movement.

            {
                if (kState.IsKeyDown(Keys.LeftShift))
                {
                    if (thrustCapacity > 0)
                    {
                        position.X -= boostSpeed * dt;
                        thrustCapacity -= 0.1f;
                    }
                    else
                    {
                        position.X -= regularSpeed * dt;
                    }
                }

                if (kState.IsKeyUp(Keys.LeftShift))
                {
                    position.X -= regularSpeed * dt;
                }
            }

            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right)) 

                // Right/Positive X axis movement.

            {
                if (kState.IsKeyDown(Keys.LeftShift))
                if (thrustCapacity > 0) // checks if thrust remaining to boost
                {
                    position.X += boostSpeed * dt;
                    thrustCapacity -= 0.1f; // recuses thrust capacity
                }
                else
                {
                    position.X += regularSpeed * dt;
                }

                if (kState.IsKeyUp(Keys.LeftShift))
                {
                    position.X += regularSpeed * dt;
                }
            }

            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down))

            // Up/Negative Y axis movement.
            {
                if (kState.IsKeyDown(Keys.LeftShift))
                    if (thrustCapacity > 0)
                    {
                        position.Y += boostSpeed * dt;
                        thrustCapacity -= 0.1f;
                    }
                    else
                    {
                        position.Y += regularSpeed * dt;
                    }

                if (kState.IsKeyUp(Keys.LeftShift))
                {
                    position.Y += regularSpeed * dt;
                }
            }

            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up))

                // Down/Positive Y axis movement.
            {
                if (kState.IsKeyDown(Keys.LeftShift))
                    if (thrustCapacity > 0)
                    {
                        position.Y -= boostSpeed * dt;
                        thrustCapacity -= 0.1f;
                    }
                    else
                    {
                        position.Y -= regularSpeed * dt;
                    }

                if (kState.IsKeyUp(Keys.LeftShift))
                {
                    position.Y -= regularSpeed * dt;
                }
            }
        }
    }
}
