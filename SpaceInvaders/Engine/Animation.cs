using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace SpaceInvaders.Engine
{
    internal class Animation
    {
        private short _MillisecondsFrameHasBeenDisplayed;



        public Animation(short defaultNumberOfMillisecondsToDisplayEachFrame, IEnumerable<AnimationFrame> frames)
        {
            if (defaultNumberOfMillisecondsToDisplayEachFrame < 1)
            {
                throw new ArgumentException("Must be a positive value.", "defaultNumberOfMillisecondsToDisplayEachFrame");
            }
            _DefaultNumberOfMillisecondsToDisplayEachFrame = defaultNumberOfMillisecondsToDisplayEachFrame;


            if (frames != null)
            {
                _AnimationFrames = new List<AnimationFrame>(frames);
            }

            _MillisecondsFrameHasBeenDisplayed = 0;
            _CurrentFrameIndex = 0;
        }



        /// <summary>
        /// Gets the frames, in sequential order, which create the animation.
        /// </summary>
        protected IList<AnimationFrame> AnimationFrames
        {
            get
            {
                if (_AnimationFrames == null)
                {
                    _AnimationFrames = new List<AnimationFrame>();
                }

                return _AnimationFrames;
            }
        }
        private List<AnimationFrame> _AnimationFrames;



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
                IList<AnimationFrame> frames = AnimationFrames;
                if (frames == null || frames.Count < 1)
                {
                    _CurrentFrameIndex = 0;
                    return;
                }

                if (value < 0)
                {
                    _CurrentFrameIndex = Convert.ToInt16(frames.Count - 1);
                    return;
                }

                // Keep the index between 0 and AnimationFrames.Length
                _CurrentFrameIndex = Convert.ToInt16(value % AnimationFrames.Count);
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
                if (_CurrentFrameIndex < 0)
                {
                    return null;
                }


                IList<AnimationFrame> frames = AnimationFrames;
                if (frames == null || _CurrentFrameIndex >= frames.Count)
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
            if (currentFrame == null)
            {
                IncrementFrame();
                return;
            }

            _MillisecondsFrameHasBeenDisplayed = Convert.ToInt16(_MillisecondsFrameHasBeenDisplayed + gameTime.ElapsedGameTime.TotalMilliseconds);
            if ((currentFrame.MillisecondsToShowFrame != null && _MillisecondsFrameHasBeenDisplayed >= currentFrame.MillisecondsToShowFrame.Value)
                    || (currentFrame.MillisecondsToShowFrame == null && _MillisecondsFrameHasBeenDisplayed >= _DefaultNumberOfMillisecondsToDisplayEachFrame))
            {
                IncrementFrame();
            }
        }



        public void Draw(SpriteBatch spriteBatch, Rectangle bounds, Vector2 origin, float rotation, Vector2 scale, Color tint, SpriteEffects effects, float depth)
        {
            AnimationFrame currentFrame = CurrentFrame;
            if (currentFrame == null)
            {
                return;
            }

            spriteBatch.Draw(currentFrame.Image, null, bounds, currentFrame.SourceRectangle, origin, rotation, scale, tint, effects, depth);
        }



        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 origin, float rotation, Vector2 scale, Color tint, SpriteEffects effects, float depth)
        {
            AnimationFrame currentFrame = CurrentFrame;
            if (currentFrame == null)
            {
                return;
            }

            spriteBatch.Draw(currentFrame.Image, position, null, currentFrame.SourceRectangle, origin, rotation, scale, tint, effects, depth);
        }
    }
}