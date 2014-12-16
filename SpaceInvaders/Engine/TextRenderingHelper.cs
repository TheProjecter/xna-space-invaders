using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace SpaceInvaders.Engine
{
        internal static class TextRenderingHelper
        {
                /// <summary>
                /// Calculates the position and origin vectors that should be used when calling a SpriteBatch.DrawString method.
                /// </summary>
                /// <param name="font">The SpriteFont that will be used to draw the string.</param>
                /// <param name="text">The string that will be rendered.</param>
                /// <param name="bounds">The rendering boundary.</param>
                /// <param name="alignment">The alignment of the string.</param>
                /// <param name="shiftPositionUsingOrigin">
                /// If true the position will be at the center of the bounding box and origin will be modified to move text into place.
                /// If false, the origin will remain at 0,0 and the position will be directly modified.
                /// </param>
                public static TextRenderingSettings CreateTextRenderingSettings(SpriteFont font, string text, Rectangle bounds, TextAlignment alignment, bool shiftPositionUsingOrigin)
                {
                        // Start by determining the amount of space the text will require
                        Vector2 sizeOfText = font.MeasureString(text);

                        float halfWidthOfBoundary = bounds.Width * 0.5f;
                        float halfHeightOfBoundary = bounds.Height * 0.5f;
                        float halfOfWidthRequiredToRenderText = sizeOfText.X * 0.5f;
                        float halfOfHeightRequiredToRenderText = sizeOfText.Y * 0.5f;
                        float deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText = halfWidthOfBoundary - halfOfWidthRequiredToRenderText;
                        float deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText = halfHeightOfBoundary - halfOfHeightRequiredToRenderText;


                        Vector2 position;
                        Vector2 origin;

                        if(shiftPositionUsingOrigin == true)
                        {
                                // Position the text at the center of the allowed boundry
                                position = new Vector2(halfWidthOfBoundary + bounds.X, halfHeightOfBoundary + bounds.Y);

                                // Set the origin at the center of the text
                                origin = new Vector2(halfOfWidthRequiredToRenderText, halfOfHeightRequiredToRenderText);
                        }
                        else
                        {
                                // Position the text at the center of the allowed boundry
                                position = new Vector2(deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText, deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText);

                                // Position the origin at the center of the allowed boundry
                                origin = Vector2.Zero;
                        }
                        

                        

                        //
                        // The below code can seem a bit tricky at first glance, but it works because shifting
                        // the origin in a direction, causes the text to be moved in the opposite direction.
                        //

                        if (alignment.HasFlag(TextAlignment.Left))
                        {
                                if (shiftPositionUsingOrigin == true)
                                {
                                        // Shift the origin to the right
                                        origin.X += deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText;
                                }
                                else
                                {
                                        // Shift the position to the left
                                        position.X -= deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText;
                                }
                        }

                        if (alignment.HasFlag(TextAlignment.Right))
                        {
                                if (shiftPositionUsingOrigin == true)
                                {
                                        // Shift the origin to the left
                                        origin.X -= deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText;
                                }
                                else
                                {
                                        // Shift the position to the right
                                        position.X += deltaBetweenHalfWidthOfBoundaryAndHalfOfWidthRequiredToRenderText;
                                }
                        }

                        if (alignment.HasFlag(TextAlignment.Top))
                        {
                                if (shiftPositionUsingOrigin == true)
                                {
                                        // Shift the origin down
                                        origin.Y += deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText;
                                }
                                else
                                {
                                        // Shift the position up
                                        position.Y -= deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText;
                                }
                        }

                        if (alignment.HasFlag(TextAlignment.Bottom))
                        {
                                if (shiftPositionUsingOrigin == true)
                                {
                                        // Shift the origin up
                                        origin.Y -= deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText;
                                }
                                else
                                {
                                        // Shift the position down
                                        position.Y += deltaBetweenHalfHeightOfBoundaryAndHalfOfHeightRequiredToRenderText;
                                }
                        }


                        TextRenderingSettings renderingSettings = new TextRenderingSettings(text, origin + position, origin, sizeOfText);
                        return renderingSettings;
                }



                public static void DrawString(SpriteBatch spriteBatch, SpriteFont font, string text, Rectangle bounds, TextAlignment alignment, Color color)
                {
                        TextRenderingSettings renderingSettings = CreateTextRenderingSettings(font, text, bounds, alignment, true);

                        spriteBatch.DrawString(font, text, renderingSettings.Position, color, 0, renderingSettings.Origin, 1, SpriteEffects.None, 0);
                }



                public static void DrawString(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 size, TextAlignment alignment, Color color)
                {
                        Rectangle bounds =
                                new Rectangle(
                                        System.Convert.ToInt32(position.X),
                                        System.Convert.ToInt32(position.Y),
                                        System.Convert.ToInt32(size.X),
                                        System.Convert.ToInt32(size.Y));

                        TextRenderingSettings renderingSettings = CreateTextRenderingSettings(font, text, bounds, alignment, true);

                        spriteBatch.DrawString(font, text, renderingSettings.Position, color, 0, renderingSettings.Origin, 1, SpriteEffects.None, 0);
                }
        }



        internal struct TextRenderingSettings
        {
                public TextRenderingSettings(string text, Vector2 position, Vector2 origin, Vector2 size)
                {
                        _Text = text;
                        _Position = position;
                        _Origin = origin;
                        _Size = size;
                }



                public string Text
                {
                        get { return _Text; }
                }
                private readonly string _Text;



                public Vector2 Size
                {
                        get { return _Size; }
                }
                private readonly Vector2 _Size;



                public Vector2 Position
                {
                        get { return _Position; }
                        set { _Position = value; }
                }
                private Vector2 _Position;



                public Vector2 Origin
                {
                        get { return _Origin; }
                        set { _Origin = value; }
                }
                private Vector2 _Origin;
        }



        [System.Flags]
        internal enum TextAlignment : byte
        {
                Center = 0,
                Left = 1,
                Right = 2,
                Top = 4,
                Bottom = 8
        }
}