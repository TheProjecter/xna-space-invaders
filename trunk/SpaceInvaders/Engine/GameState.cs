using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvaders.Engine.UserInterface;


namespace SpaceInvaders.Engine
{
    /// <summary>
    /// The GameState class encapsulates the basic functionality that any state of a game should need.
    /// It is based on the GameState class created in Jamie McMahon's XNA 4.0 RPG Tutorials series (http://xnagpa.net/xna4rpg.php)
    /// </summary>
    internal abstract class GameState<TypeOfGame> : DrawableGameComponent where TypeOfGame : BaseGame<TypeOfGame>
    {
        /// <summary>
        /// Creates a new instance of the GameState class.
        /// </summary>
        /// <param name="stateManager">The manager to which this GameState belongs.</param>
        protected GameState(GameStateManager<TypeOfGame> stateManager)
            : base(stateManager.Game)
        {
            _GameComponents = new List<GameComponent>();
            _StateManager = stateManager;
        }



        #region " Properties "


        /// <summary>
        /// Gets the Game to which this GameState belongs.
        /// </summary>
        public new TypeOfGame Game
        {
            get { return _StateManager.Game; }
        }



        /// <summary>
        /// Gets the InputHandler assigned to this GameState's Game.
        /// </summary>
        public InputHandler InputHandler
        {
            get { return _StateManager.Game.InputHandler; }
        }



        /// <summary>
        /// Gets a list of GameComponent instances assigned to this GameState.
        /// </summary>
        public List<GameComponent> GameComponents
        {
            get
            {
                return _GameComponents;
            }
        }
        private readonly List<GameComponent> _GameComponents;



        /// <summary>
        /// Gets the GameStateManager to which this GameState belongs.
        /// </summary>
        protected GameStateManager<TypeOfGame> StateManager
        {
            get
            {
                return _StateManager;
            }
        }
        private readonly GameStateManager<TypeOfGame> _StateManager;


        // End of Properties region
        #endregion


        #region " Methods "


        /// <summary>
        /// Shows and enables the GameState and any of its GameComponent children.
        /// </summary>
        public virtual void Show()
        {
            Visible = true;
            Enabled = true;

            foreach (GameComponent component in _GameComponents)
            {
                component.Enabled = true;

                DrawableGameComponent drawableComponent = component as DrawableGameComponent;
                if (drawableComponent != null)
                {
                    drawableComponent.Visible = true;
                }
            }
        }



        /// <summary>
        /// Hides and disables the GameState and any of its GameComponent children.
        /// </summary>
        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;

            foreach (GameComponent component in _GameComponents)
            {
                component.Enabled = false;

                DrawableGameComponent drawableComponent = component as DrawableGameComponent;
                if (drawableComponent != null)
                {
                    drawableComponent.Visible = false;
                }
            }
        }


        // End of Methods region
        #endregion


        #region " DrawableGameComponent overrides "


        /// <summary>
        /// Initializes the GameState and any of its GameComponents.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            foreach (GameComponent component in GameComponents)
            {
                component.Initialize();
            }
        }



        /// <summary>
        /// Updates the GameState and any of its DrawableGameComponent children.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Update.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in _GameComponents)
            {
                if (component.Enabled)
                {
                    component.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }



        /// <summary>
        /// Updates the GameState and any of its DrawableGameComponent children.
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent component in _GameComponents)
            {
                DrawableGameComponent drawableComponent = component as DrawableGameComponent;
                if (drawableComponent == null || drawableComponent.Visible == false)
                {
                    continue;
                }

                drawableComponent.Draw(gameTime);
            }

            base.Draw(gameTime);
        }


        // End of DrawableGameComponent region
        #endregion
    }
}