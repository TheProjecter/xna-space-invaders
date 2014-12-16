using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
        internal class SmallInvader : DrawableGameComponent
        {
                private Animation _MovementAnimation;
                private BaseGame _Game;


                public SmallInvader(BaseGame game) : base(game)
                {
                        _Game = game;
                }



                public override void Initialize()
                {
                        _MovementAnimation = new MovementAnimation();
                        _MovementAnimation.Initialize();

                        base.Initialize();
                }



                protected override void LoadContent()
                {
                        _MovementAnimation.LoadContent(Game.Content);

                        base.LoadContent();
                }



                public override void Update(GameTime gameTime)
                {
                        _MovementAnimation.Update(gameTime);

                        base.Update(gameTime);
                }



                public override void Draw(GameTime gameTime)
                {
                        base.Draw(gameTime);

                        _MovementAnimation.Draw(
                                _Game.SpriteBatch,
                                new Rectangle(50, 300, 32, 32),
                                Vector2.Zero,
                                0,
                                Vector2.One,
                                Color.Purple,
                                SpriteEffects.None,
                                1);
                }



                private sealed class MovementAnimation : Animation
                {
                        private Texture2D _SpriteSheet;



                        public MovementAnimation() : base(350)
                        {
                        }



                        #region " Animation overrides "


                        public override void Initialize()
                        {
                        }



                        public override void LoadContent(ContentManager contentManager)
                        {
                                _SpriteSheet = contentManager.Load<Texture2D>("SpriteSheet");

                                _AnimationFrames =
                                        new AnimationFrame[]
                                                {
                                                        //new AnimationFrame(_SpriteSheet, new Rectangle(0, 0, 32, 32), null), 
                                                        //new AnimationFrame(_SpriteSheet, new Rectangle(0, 32, 32, 32), null), 
                                                        new AnimationFrame(_SpriteSheet, new Rectangle(0, 64, 32, 32), 1000), 
                                                        new AnimationFrame(_SpriteSheet, new Rectangle(32, 64, 32, 32), 100), 
                                                        new AnimationFrame(_SpriteSheet, new Rectangle(64, 64, 32, 32), 100), 
                                                        new AnimationFrame(_SpriteSheet, new Rectangle(96, 64, 32, 32), 100), 
                                                };
                        }



                        /// <summary>
                        /// Gets the frames, in sequential order, which create the animation.
                        /// </summary>
                        protected override AnimationFrame[] AnimationFrames
                        {
                                get { return _AnimationFrames; }
                        }
                        private AnimationFrame[] _AnimationFrames;


                        // End of Animation overrides region

                        #endregion
                }
        }
}