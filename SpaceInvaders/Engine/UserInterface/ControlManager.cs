using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.Engine.UserInterface
{
        internal class ControlManager : List<Control>
        {
                private readonly InputHandler _InputHandler;
                private int _IndexOfSelectedControl;


                public ControlManager(InputHandler inputHandler) : base()
                {
                        _InputHandler = inputHandler;
                }



                #region " Methods "


                public void Update(GameTime gameTime, PlayerIndex player)
                {
                        if (Count == 0)
                        {
                                return;
                        }

                        foreach (Control ctrl in this)
                        {
                                if (ctrl.Enabled)
                                {
                                        ctrl.Update(gameTime);
                                }

                                if (ctrl.HasFocus)
                                {
                                        ctrl.HandleInput(player);
                                }
                        }

                        if (_InputHandler.HasBeenPressed(Buttons.LeftThumbstickDown, player)
                                || _InputHandler.HasBeenPressed(Buttons.DPadDown, player)
                                || _InputHandler.HasBeenPressed(Keys.Up))
                        {
                                PreviousControl();
                        }

                        if (_InputHandler.HasBeenPressed(Buttons.LeftThumbstickUp, player)
                                || _InputHandler.HasBeenPressed(Buttons.DPadUp, player)
                                || _InputHandler.HasBeenPressed(Keys.Down))
                        {
                                NextControl();
                        }
                }



                public void Draw(SpriteBatch spriteBatch)
                {
                        foreach (Control ctrl in this)
                        {
                                if(ctrl.Visible)
                                {
                                        ctrl.Draw(spriteBatch);
                                }
                        }
                }



                public void PreviousControl()
                {
                        if (Count == 0)
                        {
                                return;
                        }

                        int indexOfNewlySelectedControl = _IndexOfSelectedControl;
                        this[_IndexOfSelectedControl].HasFocus = false;

                        do
                        {
                                indexOfNewlySelectedControl -= 1;

                                if (indexOfNewlySelectedControl < 0)
                                {
                                        indexOfNewlySelectedControl = Count - 1;
                                }

                                Control ctrl = this[indexOfNewlySelectedControl];
                                if (ctrl.Enabled && ctrl.TabStop)
                                {
                                        break;
                                }
                        } while (indexOfNewlySelectedControl != _IndexOfSelectedControl);

                        _IndexOfSelectedControl = indexOfNewlySelectedControl;
                        this[_IndexOfSelectedControl].HasFocus = true;
                }



                public void NextControl()
                {
                        if (Count == 0)
                        {
                                return;
                        }

                        int indexOfNewlySelectedControl = _IndexOfSelectedControl;
                        this[_IndexOfSelectedControl].HasFocus = false;

                        do
                        {
                                indexOfNewlySelectedControl += 1;

                                if (indexOfNewlySelectedControl == Count)
                                {
                                        indexOfNewlySelectedControl = 0;
                                }

                                Control ctrl = this[indexOfNewlySelectedControl];
                                if (ctrl.Enabled && ctrl.TabStop)
                                {
                                        break;
                                }
                        } while (indexOfNewlySelectedControl != _IndexOfSelectedControl);

                        _IndexOfSelectedControl = indexOfNewlySelectedControl;
                        this[_IndexOfSelectedControl].HasFocus = true;
                }


                // End of Methods region
                #endregion


                
        }
}