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
            position.Y++;
        }
    }
}
