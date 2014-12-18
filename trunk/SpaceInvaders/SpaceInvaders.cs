using SpaceInvaders.Engine;



namespace SpaceInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    internal class SpaceInvaders : BaseGame<SpaceInvaders>
    {
        /// <summary>
        /// Creates a new instance of the SpaceInvaders class.
        /// </summary>
        public SpaceInvaders()
            : base("Space Invaders", 1024, 768)
        {
        }



        public Animations Animations
        {
            get { return _Animations; }
        }
        private Animations _Animations;


        
        /// <summary>
        /// Perform any non-graphical initialization for the game.  
        /// This method is called immediately before Game.Initialize().
        /// </summary>
        protected override void PreInitialize()
        {
            // Show the mouse cursor
            IsMouseVisible = true;

            // Load the animations that may be used by the various game components.
            _Animations = Animations.Create(Content, 1000);

            // The game will start with the title screen.
            TitleScreen titleScreen = new TitleScreen(GameStateManager);
            GameStateManager.ChangeState(titleScreen);
        }



        /// <summary>
        /// Perform any graphical initialization for the game.  
        /// This method is called immediately before Game.LoadContent().
        /// </summary>
        protected override void PreLoadContent()
        {
            
        }
    }
}