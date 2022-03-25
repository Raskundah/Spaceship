
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceShipGame
{
    class Asteroid

       
    {
        Random rand = new Random(); // calling random class to make an obect

        
        public Vector2 position = new Vector2(1900, 900); // asteroid position
        public int speed; // base asteroid speed
        public int radius = 59; //the pixel offset value for drawing = the radius of the sprite.

        // constructor

        public Asteroid(int newSpeed)
        {
            speed = newSpeed;
            position = new Vector2(2020 , rand.Next(0, 1081));
        }

        // Handling delta time for consistent speed.
        public void asteroidUpdate(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.X -= speed * dt;
        }
    }
}
