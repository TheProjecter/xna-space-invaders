using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace SpaceInvaders.Engine
{
        internal abstract class Animation
        {
                private short _MillisecondsFrameHasBeenDisplayed;


                
                protected Animation(short defaultNumberOfMillisecondsToDisplayEachFrame)
                {
                        if(defaultNumberOfMillisecondsToDisplayEachFrame < 1)
                        {
                                throw new ArgumentException("Must be a positive value.", "defaultNumberOfMillisecondsToDisplayEachFrame");
                        }
                        _DefaultNumberOfMillisecondsToDisplayEachFrame = defaultNumberOfMillisecondsToDisplayEachFrame;

                        _MillisecondsFrameHasBeenDisplayed = 0;
                        _CurrentFrameIndex = 0;
                }



                public abstract void Initialize();
                public abstract void LoadContent(ContentManager contentManager);



                /// <summary>
                /// Gets the frames, in sequential order, which create the animation.
                /// </summary>
                protected abstract AnimationFrame[] AnimationFrames { get; }



                /// <summary>
                /// Gets the number of milliseconds each frame should be
                /// displayed, unless the frame explicitly states otherwise.
                /// </summary>
                protected short DefaultNumberOfMillisecondsToDisplayEachFrame
                {
                        get { return _DefaultNumberOfMillisecondsToDisplayEachFrame; }
                }
                private short _DefaultNumberOfMillisecondsToDisplayEachFrame;



                /// <summary>
                /// Gets or sets the index of the selected frame.
                /// </summary>
                protected short CurrentFrameIndex
                {
                        get { return _CurrentFrameIndex; }
                        set
                        {
                                AnimationFrame[] frames = AnimationFrames;
                                if(frames == null || frames.Length < 1)
                                {
                                        _CurrentFrameIndex = 0;
                                        return;
                                }

                                if (value < 0)
                                {
                                        _CurrentFrameIndex = Convert.ToInt16(frames.Length - 1);
                                        return;
                                }
                                
                                // Keep the index between 0 and AnimationFrames.Length
                                _CurrentFrameIndex = Convert.ToInt16(value % AnimationFrames.Length);
                        }
                }
                private short _CurrentFrameIndex;



                /// <summary>
                /// Gets the current AnimationFrame of the Animation.
                /// </summary>
                protected AnimationFrame CurrentFrame
                {
                        get
                        {
                                if(_CurrentFrameIndex < 0)
                                {
                                        return null;
                                }


                                AnimationFrame[] frames = AnimationFrames;
                                if(frames == null || _CurrentFrameIndex >= frames.Length)
                                {
                                        return null;
                                }

                                return frames[_CurrentFrameIndex];
                        }
                }



                protected void IncrementFrame()
                {
                        CurrentFrameIndex += 1;
                        _MillisecondsFrameHasBeenDisplayed = 0;
                }



                protected void DecrementFrame()
                {
                        CurrentFrameIndex -= 1;
                        _MillisecondsFrameHasBeenDisplayed = 0;
                }



                protected void Reset()
                {
                        CurrentFrameIndex = 0;
                        _MillisecondsFrameHasBeenDisplayed = 0;
                }



                public void Update(GameTime gameTime)
                {
                        AnimationFrame currentFrame = CurrentFrame;
                        if(currentFrame == null)
                        {
                                IncrementFrame();
                                return;
                        }

                        _MillisecondsFrameHasBeenDisplayed = Convert.ToInt16(_MillisecondsFrameHasBeenDisplayed + gameTime.ElapsedGameTime.TotalMilliseconds);
                        if((currentFrame.MillisecondsToShowFrame != null && _MillisecondsFrameHasBeenDisplayed >= currentFrame.MillisecondsToShowFrame.Value)
                                || (currentFrame.MillisecondsToShowFrame == null && _MillisecondsFrameHasBeenDisplayed >= _DefaultNumberOfMillisecondsToDisplayEachFrame))
                        {
                                IncrementFrame();
                        }
                }



                public void Draw(SpriteBatch spriteBatch, Rectangle bounds, Vector2 origin, float rotation, Vector2 scale, Color tint, SpriteEffects effects, float depth)
                {
                        AnimationFrame currentFrame = CurrentFrame;
                        if(currentFrame == null)
                        {
                                return;
                        }

                        spriteBatch.Draw(currentFrame.Image, null, bounds, currentFrame.SourceRectangle, origin, rotation, scale, tint, effects, depth);
                }
        }
}