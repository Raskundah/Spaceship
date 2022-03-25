using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipGame
{
    class Controller
    {
        public List<Asteroid> asteroids = new List<Asteroid>();
        public double timer = 2;
        public double maxTime = 2;
        public int speed = 250;

        public void conTime(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(speed));
                
                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.1;

                }

                if (speed < 700)
                {
                    speed += 5;
                }
            }
        }
    }
}
