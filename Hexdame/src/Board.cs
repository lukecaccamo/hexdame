using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Comora;

//TODO: Make a constants class, get rid of magic numbers
// clean up drawservice class and add comments
namespace Hexdame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Board : Game
    {
        Camera camera;
        GraphicsDeviceManager graphics;
        GraphicsAdapter deviceGraphicsAdapter; 
        SpriteBatch spriteBatch;
        Texture2D boardSpace;
        DrawBoardService boardRenderer;
        

        public Board()
        {
            graphics = new GraphicsDeviceManager(this);
            deviceGraphicsAdapter = new GraphicsAdapter();

            graphics.PreferredBackBufferHeight = deviceGraphicsAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = deviceGraphicsAdapter.CurrentDisplayMode.Width;
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
            this.camera = new Camera(this.graphics.GraphicsDevice);
            this.IsMouseVisible = true;
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
            boardRenderer = new DrawBoardService();

            //Camera settings
            this.camera.Position = boardRenderer.boardCenter;
            this.camera.Zoom = BoardConstants.ZoomLevel;

            //Loading assets
            boardSpace = Content.Load<Texture2D>("hexagon");
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin(this.camera);

            boardRenderer.DrawBoard(spriteBatch, boardSpace);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
