using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace SpaceInvaders.Engine
{
        /// <summary>
        /// Represents a single frame of an Animation.
        /// </summary>
        internal class AnimationFrame
        {
                /// <summary>
                /// Creates a new instance of an AnimationFrame.
                /// </summary>
                /// <param name="image">The image to display.</param>
                /// <param name="sourceRectangle">The area of the image which will be displayed.</param>
                /// <param name="millisecondsToShowFrame">The duration for which the image should be displayed.</param>
                public AnimationFrame(Texture2D image, Rectangle sourceRectangle,  Nullable<short> millisecondsToShowFrame)
                {
                        if(image == null)
                        {
                                throw new ArgumentNullException("image");
                        }
                        _Image = image;
                        
                        if(sourceRectangle == Rectangle.Empty)
                        {
                                throw new ArgumentException("An empty Rectangle is not acceptable.", "sourceRectangle");
                        }
                        _SourceRectangle = sourceRectangle;

                        if(millisecondsToShowFrame != null && millisecondsToShowFrame.Value < 1)
                        {
                                throw new ArgumentException("Must be a positive value.", "millisecondsToShowFrame");
                        }
                        _MillisecondsToShowFrame = millisecondsToShowFrame;

                }



                #region " Properties "


                /// <summary>
                /// The area of the image which will be drawn.
                /// </summary>
                public Rectangle SourceRectangle
                {
                        get { return _SourceRectangle; }
                }
                private readonly Rectangle _SourceRectangle;



                /// <summary>
                /// The duration for which the image should be displayed.
                /// </summary>
                public Nullable<short> MillisecondsToShowFrame
                {
                        get { return _MillisecondsToShowFrame; }
                        set { _MillisecondsToShowFrame = value; }
                }
                private Nullable<short> _MillisecondsToShowFrame;



                /// <summary>
                /// The image which will be drawn, in part or in whole.
                /// </summary>
                public Texture2D Image
                {
                        get { return _Image; }
                }
                private readonly Texture2D _Image;


                // End of Properties region
                #endregion
        }
}