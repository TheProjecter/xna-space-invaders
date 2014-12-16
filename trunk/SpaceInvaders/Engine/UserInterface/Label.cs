using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace SpaceInvaders.Engine.UserInterface
{
        internal class Label : Control
        {
                public Label(string name, InputHandler inputHandler, SpriteFont font, string text) : base(name, inputHandler)
                {
                        if(font == null)
                        {
                                throw new ArgumentNullException("font");
                        }
                        _Font = font;

                        _Text = text;

                        _Alignment = TextAlignment.Top | TextAlignment.Left;
                }



                #region " Properties "


                /// <summary>
                /// Gets or sets the text which will 
                /// </summary>
                public virtual string Text
                {
                        get { return _Text; }
                        set { _Text = value; }
                }
                private string _Text;



                /// <summary>
                /// Gets or Sets the SpriteFont in which the text will be drawn.
                /// </summary>
                public virtual SpriteFont Font
                {
                        get { return _Font; }
                        set { _Font = value; }
                }
                private SpriteFont _Font;



                /// <summary>
                /// Gets or sets the color in which the text will be drawn.
                /// </summary>
                public virtual Color Color
                {
                        get { return _Color; }
                        set { _Color = value; }
                }
                private Color _Color;



                /// <summary>
                /// Gets or sets the TextAlignment assigned to the Label.
                /// </summary>
                public virtual TextAlignment Alignment
                {
                        get { return _Alignment; }
                        set { _Alignment = value; }
                }
                private TextAlignment _Alignment;
                

                // End of Properties region
                #endregion


                #region " Control overrides "


                public override void Update(GameTime gameTime)
                {
                }



                public override void Draw(SpriteBatch spriteBatch)
                {
                        TextRenderingHelper.DrawString(spriteBatch, Font, Text, Position, Size, Alignment, Color);
                }



                public override void HandleInput(PlayerIndex player)
                {
                }


                // End of Control overrides region
                #endregion
        }
}