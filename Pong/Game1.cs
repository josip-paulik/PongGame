using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using GenericList;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// The bottom paddle object.
        /// </summary>
        public Paddle PaddleBottom { get; private set; }

        /// <summary>
        /// The top paddle object.
        /// </summary>
        public Paddle PaddleTop { get; private set; }

        /// <summary>
        /// Ball object.
        /// </summary>
        public Ball Ball { get; private set; }

        /// <summary>
        /// Background image.
        /// </summary>
        public Background Background { get; private set; }

        /// <summary>
        /// Sound when the ball hits.
        /// </summary>
        public SoundEffect HitSound { get; private set; }

        /// <summary>
        /// Background music.
        /// </summary>
        public Song Music{ get; private set; }

        /// <summary>
        /// Generic list that holds Sprites that should be drawn on screen.
        /// </summary>
        private GenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500
            };
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            var screenBounds = GraphicsDevice.Viewport.Bounds;

            PaddleBottom = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            PaddleBottom.X = GameConstants.PaddleBottomXPostionInital;
            PaddleBottom.Y = GameConstants.PaddleBottomYPositionInital;

            PaddleTop = new Paddle(GameConstants.PaddleDefaultWidth,
            GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);
            PaddleTop.X = GameConstants.PaddleTopXPostionInital;
            PaddleTop.Y = GameConstants.PaddleTopYPositionInital;

            Ball = new Ball(GameConstants.DefaultBallSize,
            GameConstants.DefaultInitialBallSpeed,
            GameConstants.DefaultBallBumpSpeedIncreaseFactor)
            {
                X = GameConstants.TextureMiddleWidth,
                Y = GameConstants.TextureMiddleHeight
            };
            Background = new Background( GameConstants.TextureWidth, GameConstants.TextureHeight);

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialize new SpriteBatch object which will be used to draw textures .
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set textures
            Texture2D paddleTexture = Content.Load<Texture2D>("Paddle");
            PaddleBottom.Texture = paddleTexture;
            PaddleTop.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("Ball");
            Background.Texture = Content.Load<Texture2D>("Background");
            
            // Load sounds
            // Start background music
            HitSound = Content.Load<SoundEffect>("Hit");
            Music = Content.Load<Song>("Music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for (int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).DrawSpriteOnScreen(spriteBatch);
            }

            //End drawing.
            //Send all gathered details to the graphic card in one batch.
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
