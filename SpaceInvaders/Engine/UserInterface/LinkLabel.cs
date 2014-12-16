using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace SpaceInvaders.Engine.UserInterface
{
        internal class LinkLabel : Label
        {
                public LinkLabel(string name, InputHandler inputHandler, SpriteFont font, string text) : base(name, inputHandler, font, text)
                {
                        _TabStop = true;
                        _SelectedColor = Color.DeepSkyBlue;
                }



                #region " Properties "


                /// <summary>
                /// Gets or sets the color in which the text will be drawn when the LinkLabel is selected.
                /// </summary>
                public Color SelectedColor
                {
                        get { return _SelectedColor; }
                        set { _SelectedColor = value; }
                }
                private Color _SelectedColor;



                /// <summary>
                /// Gets or sets the color in which the text will be drawn when the LinkLabel is not selected.
                /// </summary>
                public override Color Color
                {
                        get
                        {
                                return base.Color;
                        }
                        set
                        {
                                base.Color = value;
                        }
                }


                // End of Properties region

                #endregion



                #region " Label overrides "


                #region " Properties "


                public override bool TabStop
                {
                        get
                        {
                                return _TabStop;
                        }
                        set
                        {
                                _TabStop = value;
                        }
                }
                private bool _TabStop;


                // End of Properties region
                #endregion


                #region " Methods "


                public override void Draw(SpriteBatch spriteBatch)
                {
                        if(HasFocus == true)
                        {
                                TextRenderingHelper.DrawString(spriteBatch, Font, Text, Position, Size, Alignment, SelectedColor);
                                return;
                        }

                        TextRenderingHelper.DrawString(spriteBatch, Font, Text, Position, Size, Alignment, Color);
                }



                public override void HandleInput(PlayerIndex player)
                {
                        if(HasFocus == false)
                        {
                                return;
                        }

                        if(InputHandler.HasBeenReleased(Keys.Enter)
                                || InputHandler.HasBeenReleased(Keys.Space)
                                || InputHandler.HasBeenReleased(Buttons.A, player)
                                || InputHandler.HasBeenReleased(Buttons.Start, player))
                        {
                                OnSelected(System.EventArgs.Empty);
                        }
                }


                // End of Methods region
                #endregion


                // End of Label overrides region

                #endregion
        }
}