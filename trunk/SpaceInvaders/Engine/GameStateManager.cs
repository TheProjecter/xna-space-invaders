using System.Collections.Generic;
using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
    /// <summary>
    /// The GameStateManager class handles all the ins and outs that occur when a game changes between GameState instances.
    /// It is based on the GameStateManager class created in Jamie McMahon's XNA 4.0 RPG Tutorials series (http://xnagpa.net/xna4rpg.php)
    /// </summary>
    internal class GameStateManager<TypeOfGame> : GameComponent where TypeOfGame : BaseGame<TypeOfGame>
    {
        private readonly int _StartingDrawOrder;
        private readonly int _DrawOrderDelta;

        private readonly Stack<GameState<TypeOfGame>> _GameStates;
        private int _DrawOrder;

        private readonly TypeOfGame _Game;


        

        /// <summary>
        /// Creates a new instance of the GameStateManager class.
        /// </summary>
        /// <param name="game">The game to which this manager will belong.</param>
        public GameStateManager(TypeOfGame game) : this(game, 5000, 100) { }



        /// <summary>
        /// Creates a new instance of the GameStateManager class.
        /// </summary>
        /// <param name="game">The game to which this manager will belong.</param>
        /// <param name="startingDrawOrder">The draw order of base game states.</param>
        /// <param name="drawOrderDelta">The amound in which the draw order will change as the GameState stack chages.</param>
        public GameStateManager(TypeOfGame game, int startingDrawOrder, int drawOrderDelta)
            : base(game)
        {
            _GameStates = new Stack<GameState<TypeOfGame>>();
            _StartingDrawOrder = startingDrawOrder;
            _DrawOrderDelta = drawOrderDelta;

            _DrawOrder = startingDrawOrder;

            _Game = game;
        }



        #region " Properties "


        /// <summary>
        /// Gets the Game associated with the GameStateManager.
        /// </summary>
        public new TypeOfGame Game
        {
            get { return _Game; }
        }



        /// <summary>
        /// Returns the GameState that resides on the top of the GameState stack.
        /// </summary>
        public GameState<TypeOfGame> CurrentState
        {
            get
            {
                return _GameStates.Peek();
            }
        }


        // End of Properties region
        #endregion


        #region " Methods "


        /// <summary>
        /// Adds the given state to the GameState stack.
        /// </summary>
        /// <param name="state">The GameState which needs to be added.</param>
        private void AddState(GameState<TypeOfGame> state)
        {
            _GameStates.Push(state);
            Game.Components.Add(state);
        }



        /// <summary>
        /// Removes the current state from the GameState stack.
        /// </summary>
        private void RemoveState()
        {
            GameState<TypeOfGame> removedState = _GameStates.Pop();
            Game.Components.Remove(removedState);
        }



        /// <summary>
        /// Adds the given state to the GameState stack, setting the draw order accordingly.
        /// </summary>
        /// <param name="state">The GameState which needs to be added.</param>
        public void PushState(GameState<TypeOfGame> state)
        {
            _DrawOrder += _DrawOrderDelta;
            state.DrawOrder = _DrawOrder;

            AddState(state);
        }



        /// <summary>
        /// Clears the GameState stack of all execpt for the given state.
        /// </summary>
        /// <param name="state">The only GameState that should be on the stack.</param>
        public void ChangeState(GameState<TypeOfGame> state)
        {
            while (_GameStates.Count > 0)
            {
                RemoveState();
            }

            state.DrawOrder = _StartingDrawOrder;
            _DrawOrder = _StartingDrawOrder;

            AddState(state);
        }



        /// <summary>
        /// Removes the current state from the GameState stack.
        /// </summary>
        public void PopState()
        {
            if (_GameStates.Count <= 1)
            {
                return;
            }

            RemoveState();
            _DrawOrder -= _DrawOrderDelta;
        }


        // End of Methods region
        #endregion
    }
}