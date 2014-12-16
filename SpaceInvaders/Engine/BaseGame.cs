using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace SpaceInvaders.Engine
{
        internal abstract class BaseGame : Game
        {
                private readonly GraphicsDeviceManager _Graphics;
                private SpriteBatch _SpriteBatch;
                private GameStateManager _GameStateManager;
                
                private InputHandler _InputHandler;

                private Random _RandomNumberGenerator;



                /// <summary>
                /// Creates a new instance
                /// </summary>
                /// <param name="windowTitle">The text that should display in the Game's Window's title bar.</param>
                /// <param name="screenWidth">The width to which the game window should be set.</param>
                /// <param name="screenHeight">The height to which the game window should be set.</param>
                protected BaseGame(string windowTitle, int screenWidth, int screenHeight) : base()
                {
                        _Graphics = new GraphicsDeviceManager(this);
                        Content.RootDirectory = "Content";

                        Window.Title = windowTitle;
                        SetWindowSize(screenWidth, screenHeight);
                }



                #region " Properties "
                

                /// <summary>
                /// Gets the GraphicsDeviceManager assigned to this Game.
                /// </summary>
                protected GraphicsDeviceManager GraphicsDeviceManager
                {
                        get { return _Graphics; }
                }



                /// <summary>
                /// Gets the System.Random declared for the game.
                /// </summary>
                public Random RandomNumberGenerator
                {
                        get { return _RandomNumberGenerator; }
                }



                /// <summary>
                /// Gets the InputHandler assigned to this Game.
                /// </summary>
                public InputHandler InputHandler
                {
                        get { return _InputHandler; }
                }



                /// <summary>
                /// Gets the SpriteBatch created for rendering 2D objects.
                /// </summary>
                public SpriteBatch SpriteBatch
                {
                        get { return _SpriteBatch; }
                }



                /// <summary>
                /// Gets the GameStateManager assigned to this Game.
                /// </summary>
                protected GameStateManager GameStateManager
                {
                        get { return _GameStateManager; }
                }



                /// <summary>
                /// Gets the Rectangle representing the game screen.
                /// </summary>
                public Rectangle ScreenRectangle
                {
                        get { return _ScreenRectangle; }
                }
                private Rectangle _ScreenRectangle;
                

                // End of Properties region
                #endregion


                #region " Methods "


                /// <summary>
                /// Perform any non-graphical initialization for the game.  
                /// This method is called immediately before Game.Initialize().
                /// </summary>
                protected abstract void PreInitialize();



                /// <summary>
                /// Perform any graphical initialization for the game.  
                /// This method is called immediately before Game.LoadContent().
                /// </summary>
                protected abstract void PreLoadContent();



                /// <summary>
                /// Sets the Game's window to the specified size.
                /// </summary>
                /// <param name="width">The width to which the game window should be set.</param>
                /// <param name="height">The height to which the game window should be set.</param>
                public void SetWindowSize(int width, int height)
                {
                        _Graphics.PreferredBackBufferWidth = width;
                        _Graphics.PreferredBackBufferHeight = height;
                        _Graphics.ApplyChanges();

                        _ScreenRectangle = new Rectangle(0, 0, width, height);
                }


                // End of Methods region
                #endregion


                #region " Game overrides"


                /// <summary>
                /// Allows the game to perform any initialization it needs to before starting to run.
                /// This is where it can query for any required services and load any non-graphic
                /// related content.  Calling base.Initialize will enumerate through any components
                /// and initialize them as well.
                /// </summary>
                protected override void Initialize()
                {
                        _RandomNumberGenerator = new Random();

                        _InputHandler = new InputHandler(this);
                        Components.Add(_InputHandler);

                        _GameStateManager = new GameStateManager(this);
                        Components.Add(_GameStateManager);
                        
                        PreInitialize();

                        base.Initialize();
                }



                /// <summary>
                /// LoadContent will be called once per game and is the place to load
                /// all of your content.
                /// </summary>
                protected override void LoadContent()
                {
                        base.LoadContent();


                        // Create a new SpriteBatch, which can be used to draw textures.
                        _SpriteBatch = new SpriteBatch(GraphicsDevice);
                }



                /// <summary>
                /// UnloadContent will be called once per game and is the place to unload
                /// all content.
                /// </summary>
                protected override void UnloadContent()
                {
                        base.UnloadContent();

                        _SpriteBatch.Dispose();
                }



                /// <summary>
                /// Allows the game to run logic such as updating the world,
                /// checking for collisions, gathering input, and playing audio.
                /// </summary>
                /// <param name="gameTime">Time passed since the last call to Update.</param>
                protected override void Update(GameTime gameTime)
                {
                        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                        {
                                Exit();
                        }

                        base.Update(gameTime);
                }



                /// <summary>
                /// This is called when the game should draw itself.
                /// </summary>
                /// <param name="gameTime">Time passed since the last call to Draw.</param>
                protected override void Draw(GameTime gameTime)
                {
                        GraphicsDevice.Clear(Color.CornflowerBlue);

                        base.Draw(gameTime);
                }


                // End of Game region
                #endregion
        }
}