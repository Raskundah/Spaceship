﻿using System;
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
        public bool inGame = false;
        public double totalTime = 0;

        public void conTime(GameTime gameTime)
        {
            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += gameTime.ElapsedGameTime.TotalSeconds;

            }

            else
            {
                KeyboardState kState = Keyboard.GetState();
                if(kState.IsKeyDown(Keys.Enter))
                {
                    inGame =true;
                    totalTime = 0;
                    timer = 2;
                    maxTime = 2;
                    speed = 250;
                }
            }
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
