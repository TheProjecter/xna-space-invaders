using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace SpaceInvaders.Engine.UserInterface
{
        internal abstract class Control
        {
                protected Control(string name, InputHandler inputHandler)
                {
                        if(string.IsNullOrEmpty(name))
                        {
                                throw new ArgumentNullException("name");
                        }
                        Name = name;


                        if (inputHandler == null)
                        {
                                throw new ArgumentNullException("inputHandler");
                        }
                        _InputHandler = inputHandler;


                        _Enabled = true;
                        _Visible = true;
                        _HasFocus = false;
                        _TabStop = true;
                        _Position = Vector2.Zero;
                }



                #region " Properties "


                public InputHandler InputHandler
                {
                        get { return _InputHandler; }
                }
                private InputHandler _InputHandler;



                public string Name { get; protected set; }



                public virtual Vector2 Size
                {
                        get { return _Size; }
                        set { _Size = value; }
                }
                private Vector2 _Size;



                public virtual bool Enabled
                {
                        get { return _Enabled; }
                        set { _Enabled = value; }
                }
                private bool _Enabled;



                public virtual bool Visible
                {
                        get { return _Visible; }
                        set { _Visible = value; }
                }
                private bool _Visible;



                public virtual bool HasFocus
                {
                        get { return _HasFocus; }
                        set { _HasFocus = value; }
                }
                private bool _HasFocus;



                public virtual bool TabStop
                {
                        get { return _TabStop; }
                        set { _TabStop = value; }
                }
                private bool _TabStop;



                public virtual Vector2 Position
                {
                        get { return _Position; }
                        set
                        {
                                _Position = value;

                                // XNA doesn't like to draw text if the Y coordinate isn't an integer,
                                // so the value is cast to an integer just to be on the safe side.
                                _Position.Y = Convert.ToInt32(value.Y);
                        }
                }
                private Vector2 _Position;


                // End of Properties region
                #endregion


                #region " Methods "


                /// <summary>
                /// Called when the Control needs to be updated.
                /// </summary>
                /// <param name="gameTime">Time elapsed since the last call to Update.</param>
                public abstract void Update(GameTime gameTime);



                /// <summary>
                /// Called when the Control needs to be drawn.
                /// </summary>
                /// <param name="spriteBatch">Time passed since the last call to Draw.</param>
                public abstract void Draw(SpriteBatch spriteBatch);



                /// <summary>
                /// Called when the Control receives input.
                /// </summary>
                /// <param name="player">The player providing the input.</param>
                public abstract void HandleInput(PlayerIndex player);



                /// <summary>
                /// Fires the Selected event.
                /// </summary>
                /// <param name="e"></param>
                protected virtual void OnSelected(EventArgs e)
                {
                        Selected(this, e);
                }
                public event EventHandler Selected = delegate { };


                // End of Methods region

                #endregion
        }
}