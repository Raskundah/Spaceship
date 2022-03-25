using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace SpaceShipGame
{
    public class Game1 : Game
    {
        // declare variables

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        

        Texture2D shipSprite;
        Texture2D asteroidSrite;
        Texture2D spaceSprite;
        SpriteFont gameFont;
        SpriteFont timerFont;

        // call custom classes and create objects

        Ship player = new Ship();
        Controller gameController = new Controller();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()

            // Setup game window size.
            // TODO have player input their resolution selection
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()

            // load textures into texture2D variabe
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            shipSprite = Content.Load<Texture2D>("ship");
            asteroidSrite = Content.Load<Texture2D>("asteroid");
            spaceSprite = Content.Load<Texture2D>("space");

            gameFont = Content.Load<SpriteFont>("spaceFont");
            timerFont = Content.Load<SpriteFont>("timerFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            if (gameController.inGame)
            {
                player.ShipUpdate(gameTime);

            }

            gameController.conTime(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].asteroidUpdate(gameTime);

                int sum = gameController.asteroids[i].radius + player.radius;
                if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
                    gameController.asteroids.Clear();
                }

            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)

        {
            int halfWidth = _graphics.PreferredBackBufferWidth / 2;
            int halfHeight = _graphics.PreferredBackBufferHeight / 2;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            if (gameController.inGame)
            {
                _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            }
            else
                _spriteBatch.Draw(shipSprite, new Vector2((halfWidth) -34, (halfHeight) -50), Color.White);


            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                _spriteBatch.Draw(asteroidSrite, new Vector2(gameController.asteroids[i].position.X - gameController.asteroids[i].radius, gameController.asteroids[i].position.Y - gameController.asteroids[i].radius), Color.White);
            }

            if (gameController.inGame == false)
            {
                string menuMessage = "Press ENTER to begin!";
              Vector2 sizeOfText = gameFont.MeasureString(menuMessage);
                

                _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(halfWidth -sizeOfText.X /2, halfHeight), Color.White);
            }

            _spriteBatch.DrawString(timerFont, "Time: " + Math.Floor(gameController.totalTime).ToString(),new Vector2(3,3), Color.White);

                _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
