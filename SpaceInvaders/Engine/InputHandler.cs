using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace SpaceInvaders.Engine
{
        /// <summary>
        /// This InputHandler encapsulates user input from Keyboard, Mouse, or GamePad devices.
        /// It is based on the InputHandler class created in Jamie McMahon's XNA 4.0 RPG Tutorials series (http://xnagpa.net/xna4rpg.php)
        /// </summary>
        internal class InputHandler : GameComponent
        {
                private readonly Dictionary<MouseButton, MouseActionTracker> _MouseActions;
 


                /// <summary>
                /// Creates an instance of the InputHandler class.
                /// </summary>
                /// <param name="game">The game to which this instance will belong.</param>
                public InputHandler(Game game) : base(game)
                {
                        _KeyboardState = Keyboard.GetState();
                        
                        _GamePadStates = GetGamePadStates();

                        _DoubleClickMillisecondCeiling = 500;
                        _MouseState = Mouse.GetState(game.Window);
                        _MouseActions = new Dictionary<MouseButton, MouseActionTracker>(5);
                }
                


                #region " Properties "


                #region " Keyboard "
                

                /// <summary>
                /// Gets the state of the keyboard at the last time this GameComponent was updated.
                /// </summary>
                public KeyboardState KeyboardState
                {
                        get
                        {
                                return _KeyboardState;
                        }
                }
                private KeyboardState _KeyboardState;



                /// <summary>
                /// Gets the previous state of the keyboard at the last time this GameComponent was updated.
                /// </summary>
                public KeyboardState LastKeyboardState
                {
                        get { return _LastKeyboardState; }
                }
                private KeyboardState _LastKeyboardState;


                // End of Keyboard region
                #endregion


                #region " Mouse "


                /// <summary>
                /// Gets or sets the maximum number of milliseconds that may pass between
                /// clicks in order for subsequent clicks to be considered double clicks.
                /// </summary>
                public short DoubleClickMillisecondCeiling
                {
                        get
                        {
                                return _DoubleClickMillisecondCeiling;
                        }
                        set
                        {
                                _DoubleClickMillisecondCeiling = value;
                        }
                }
                private short _DoubleClickMillisecondCeiling;



                /// <summary>
                /// Gets the state of the mouse at the last time this GameComponent was updated.
                /// </summary>
                public MouseState MouseState
                {
                        get
                        {
                                return _MouseState;
                        }
                }
                private MouseState _MouseState;



                /// <summary>
                /// Gets the previous state of the mouse at the last time this GameComponent was updated.
                /// </summary>
                public MouseState LastMouseState
                {
                        get { return _LastMouseState; }
                }
                private MouseState _LastMouseState;



                /// <summary>
                /// Gets the location of the mouse cursor at the last time this GameComponent was updated.
                /// </summary>
                public Point MousePosition
                {
                        get { return _MouseState.Position; }
                }



                /// <summary>
                /// Gets the location of the mouse cursor at the last time this GameComponent was updated.
                /// </summary>
                public Vector2 MouseLocation
                {
                        get
                        {
                                Point position = MousePosition;
                                return new Vector2(position.X, position.Y);
                        }
                }


                // End of Mouse region
                #endregion


                #region " GamePad "


                /// <summary>
                /// Gets the states of each of the GamePad devices at the last time this GameComponent was updated.
                /// </summary>
                public Dictionary<PlayerIndex, GamePadState> GamePadStates
                {
                        get
                        {
                                return _GamePadStates;
                        }
                }
                private Dictionary<PlayerIndex, GamePadState> _GamePadStates;


                /// <summary>
                /// Gets the previous state of each of the GamePad devices at the last time this GameComponent was updated.
                /// </summary>
                public Dictionary<PlayerIndex, GamePadState> LastGamePadStates
                {
                        get { return _LastGamePadStates; }
                }
                private Dictionary<PlayerIndex, GamePadState> _LastGamePadStates;


                // End of GamePad region
                #endregion


                // End of Properties region
                #endregion


                #region " Methods "


                /// <summary>
                /// Clears the state cache for each input device.
                /// </summary>
                /// <remarks>
                /// Useful for verifying that input from one GameState doesn't carry over to another GameState.
                /// </remarks>
                public void ClearStateCache()
                {
                        _LastKeyboardState = _KeyboardState;
                        _LastGamePadStates = null;
                        _LastMouseState = _MouseState;
                        _MouseActions.Clear();
                }



                #region " Keyboard "


                /// <summary>
                /// Determines if the specified key is currently pressed, but used to not be pressed.
                /// </summary>
                /// <param name="key">The key whose state should be checked.</param>
                /// <returns>True if the key has been recently pressed, false otherwise.</returns>
                public bool HasBeenPressed(Keys key)
                {
                        return _KeyboardState.IsKeyDown(key) && _LastKeyboardState.IsKeyUp(key);
                }



                /// <summary>
                /// Determines if the specified key used to be pressed, but isn't currently pressed.
                /// </summary>
                /// <param name="key">The key whose state should be checked.</param>
                /// <returns>True if the key has been recently released, false otherwise.</returns>
                public bool HasBeenReleased(Keys key)
                {
                        return _KeyboardState.IsKeyUp(key) && _LastKeyboardState.IsKeyDown(key);
                }



                /// <summary>
                /// Determines if the specified key is actively being held down.
                /// </summary>
                /// <param name="key">The key whose state should be checked.</param>
                /// <returns>True if the key is currently being held down, false otherwise.</returns>
                public bool IsCurrentlyPressed(Keys key)
                {
                        return _KeyboardState.IsKeyDown(key);
                }
                

                // End of Keyboard region
                #endregion


                #region " Mouse "
                

                /// <summary>
                /// Determines if the specified MouseButton has the expected ButtonState value.
                /// </summary>
                /// <param name="mouseState">The MouseState which should be checked.</param>
                /// <param name="mouseButton">The MouseButton which should be checked.</param>
                /// <param name="buttonState">The expected ButtonState value.</param>
                /// <returns></returns>
                private static bool IsButtonState(MouseState mouseState, MouseButton mouseButton, ButtonState buttonState)
                {
                        return mouseButton.HasState(mouseState, buttonState);
                }



                /// <summary>
                /// Determines if the specified button is currently pressed.
                /// </summary>
                /// <param name="state">The MouseState which should be checked.</param>
                /// <param name="button">The MouseButton which should be checked.</param>
                /// <returns>Returns true if the button is currently pressed, false otherwise.</returns>
                private static bool IsDown(MouseState state, MouseButton button)
                {
                        return IsButtonState(state, button, ButtonState.Pressed);
                }



                /// <summary>
                /// Determines if the specified button is currently released.
                /// </summary>
                /// <param name="state">The MouseState which should be checked.</param>
                /// <param name="button">The MouseButton which should be checked.</param>
                /// <returns>Returns true if the button is currently released, false otherwise.</returns>
                private static bool IsUp(MouseState state, MouseButton button)
                {
                        return IsButtonState(state, button, ButtonState.Released);
                }



                /// <summary>
                /// Determines if the specified button is currently pressed, but used to not be pressed.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <returns>True if the button has been recently pressed, false otherwise.</returns>
                public bool HasBeenPressed(MouseButton button)
                {
                        return IsDown(_MouseState, button) && IsUp(_LastMouseState, button);
                }



                /// <summary>
                /// Determines if the specified button used to be pressed, but isn't currently pressed.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <returns>True if the button has been recently released, false otherwise.</returns>
                public bool HasBeenReleased(MouseButton button)
                {
                        return IsUp(_MouseState, button) && IsUp(_LastMouseState, button);
                }



                /// <summary>
                /// Determines if the specified button is actively being held down.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <returns>True if the button is currently being held down, false otherwise.</returns>
                public bool IsCurrentlyPressed(MouseButton button)
                {
                        return IsDown(_MouseState, button);
                }



                /// <summary>
                /// Determines if the specified button has been pressed and released twice in quick succession.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <returns>True if the button has been recently double clicked, false otherwise.</returns>
                public bool HasBeenDoubleClicked(MouseButton button)
                {
                        MouseActionTracker clickOptions;
                        if (_MouseActions.TryGetValue(button, out clickOptions) == false)
                        {
                                return false;
                        }

                        return clickOptions.LastClickWasConsideredDoubleClick;
                }


                // End of Mouse region
                #endregion


                #region " GamePad "


                /// <summary>
                /// Gets the current states of each GamePad device.
                /// </summary>
                /// <returns></returns>
                private static Dictionary<PlayerIndex, GamePadState> GetGamePadStates()
                {
                        System.Array playerIndecies = System.Enum.GetValues(typeof(PlayerIndex));
                        int numberOfPlayers = playerIndecies.Length;

                        Dictionary<PlayerIndex, GamePadState> gamePadStates = new Dictionary<PlayerIndex, GamePadState>(numberOfPlayers);
                        foreach (PlayerIndex playerIndex in playerIndecies)
                        {
                                gamePadStates[playerIndex] = GamePad.GetState(playerIndex);
                        }

                        return gamePadStates;
                }



                /// <summary>
                /// Gets the GamePadState associated with the specified PlayerIndex.
                /// </summary>
                /// <param name="gamePadStates">The collection of GamePadStates in which to search for the player.</param>
                /// <param name="player">The player who owns the GamePadState which should be located.</param>
                /// <returns>The player's GamePadState if it has one, a default GamePadState otherwise.</returns>
                private static GamePadState GetGamePadStateForPlayer(IDictionary<PlayerIndex, GamePadState> gamePadStates, PlayerIndex player)
                {
                        if(gamePadStates == null)
                        {
                                return default(GamePadState);
                        }

                        GamePadState gamePadState;
                        if (gamePadStates.TryGetValue(player, out gamePadState) == false)
                        {
                                gamePadState = default(GamePadState);
                        }

                        return gamePadState;
                }



                /// <summary>
                /// Determines if the specified button is currently pressed, but used to not be pressed.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <param name="player">The PlayerIndex whose GamePad state should be checked.</param>
                /// <returns>True if the button has been recently pressed, false otherwise.</returns>
                public bool HasBeenPressed(Buttons button, PlayerIndex player)
                {
                        GamePadState gamePadState = GetGamePadStateForPlayer(_GamePadStates, player);
                        GamePadState lastGamePadState = GetGamePadStateForPlayer(_LastGamePadStates, player);
                        
                        return gamePadState.IsButtonDown(button) && lastGamePadState.IsButtonUp(button);
                }



                /// <summary>
                /// Determines if the specified button used to be pressed, but isn't currently pressed.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <param name="player">The PlayerIndex whose GamePad state should be checked.</param>
                /// <returns>True if the button has been recently released, false otherwise.</returns>
                public bool HasBeenReleased(Buttons button, PlayerIndex player)
                {
                        GamePadState gamePadState = GetGamePadStateForPlayer(_GamePadStates, player);
                        GamePadState lastGamePadState = GetGamePadStateForPlayer(_LastGamePadStates, player);

                        return gamePadState.IsButtonUp(button) && lastGamePadState.IsButtonDown(button);
                }



                /// <summary>
                /// Determines if the specified button is actively being held down.
                /// </summary>
                /// <param name="button">The button whose state should be checked.</param>
                /// <param name="player">The PlayerIndex whose GamePad state should be checked.</param>
                /// <returns>True if the button is currently being held down, false otherwise.</returns>
                public bool IsCurrentlyPressed(Buttons button, PlayerIndex player)
                {
                        GamePadState gamePadState = GetGamePadStateForPlayer(_GamePadStates, player);

                        return gamePadState.IsButtonDown(button);
                }


                // End of GamePad region
                #endregion


                // End of Methods region
                #endregion
                

                #region " GameComponent overrides "


                /// <summary>
                /// Updates the caches with the current states for each input device.
                /// </summary>
                /// <param name="gameTime">The amount of time that has passed since the last call to Update.</param>
                public override void Update(GameTime gameTime)
                {
                        _LastKeyboardState = _KeyboardState;
                        _KeyboardState = Keyboard.GetState();

                        _LastGamePadStates = _GamePadStates;
                        _GamePadStates = GetGamePadStates();

                        _LastMouseState = _MouseState;
                        _MouseState = Mouse.GetState(Game.Window);

                        foreach (MouseButton button in new MouseButton[]{MouseButton.Left, MouseButton.Right, MouseButton.Middle, MouseButton.XButton1, MouseButton.XButton2})
                        {
                                MouseActionTracker clickOptions;
                                if(_MouseActions.TryGetValue(button, out clickOptions) == false)
                                {
                                        clickOptions = new MouseActionTracker();
                                        _MouseActions[button] = clickOptions;
                                }
                                clickOptions.ElapsedMillisecondsSinceLastClick = System.Convert.ToInt32(clickOptions.ElapsedMillisecondsSinceLastClick + gameTime.ElapsedGameTime.TotalMilliseconds);

                                if(HasBeenPressed(button) == false)
                                {
                                        clickOptions.LastClickWasConsideredDoubleClick = false;
                                        continue;
                                }

                                clickOptions.LastClickWasConsideredDoubleClick = (clickOptions.ElapsedMillisecondsSinceLastClick < DoubleClickMillisecondCeiling);

                                clickOptions.ElapsedMillisecondsSinceLastClick = 0;
                        }

                        base.Update(gameTime);
                }


                // End of GameComponent region
                #endregion
                

                #region " Inner Classes "


                /// <summary>
                /// This class is used to track mouse actions, such as determining double clicks.
                /// </summary>
                private sealed class MouseActionTracker
                {
                        public MouseActionTracker()
                        {
                                ElapsedMillisecondsSinceLastClick = short.MaxValue;
                                LastClickWasConsideredDoubleClick = false;
                        }

                        public int ElapsedMillisecondsSinceLastClick;
                        public bool LastClickWasConsideredDoubleClick;
                }


                // End of inner class region
                #endregion
        }
}