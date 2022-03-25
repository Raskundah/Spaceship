using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


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

            player.ShipUpdate(gameTime);
            gameController.conTime(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].asteroidUpdate(gameTime);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)

        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - 34 , player.position.Y- 50), Color.White);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                _spriteBatch.Draw(asteroidSrite, new Vector2(gameController.asteroids[i].position.X - gameController.asteroids[i].radius, gameController.asteroids[i].position.Y - gameController.asteroids[i].radius), Color.White);
            }
                _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
