using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
        internal class Invader : DrawableGameComponent, ICollidable
        {
                private Animation _MovementAnimation;
                private SpaceInvaders _Game;



                public Invader(SpaceInvaders game)
                        : base(game)
                {
                        _Game = game;

                        _Velocity = Vector2.Zero;
                }



                public Animation MovementAnimation
                {
                        get { return _MovementAnimation; }
                        set { _MovementAnimation = value; }
                }



                public Vector2 Position
                {
                        get { return _Position; }
                        set { _Position = value; }
                }
                private Vector2 _Position;



                public Vector2 Velocity
                {
                        get { return _Velocity; }
                        set { _Velocity = value; }
                }
                private Vector2 _Velocity;



                /// <summary>
                /// The rectangular bounds of the object.
                /// </summary>
                public Rectangle BoundingBox
                {
                        get
                        {
                                if(_MovementAnimation == null)
                                {
                                        return Rectangle.Empty;
                                }

                                AnimationFrame currentFrame = _MovementAnimation.CurrentFrame;
                                if(currentFrame == null)
                                {
                                        return Rectangle.Empty;
                                }

                                Rectangle sourceRectangle = currentFrame.SourceRectangle;

                                return new Rectangle(
                                        System.Convert.ToInt32(_Position.X),
                                        System.Convert.ToInt32(_Position.Y),
                                        sourceRectangle.Width,
                                        sourceRectangle.Height);
                        }
                }



                /// <summary>
                /// The circular bounds of the object.
                /// </summary>
                public Circle BoundingCircle { get; private set; }



                /// <summary>
                /// The polygonal bounds of the object.
                /// </summary>
                public Polygon BoundingPolygon { get; private set; }



                public void CollideWith(ICollidable other)
                {
                }



                public override void Update(GameTime gameTime)
                {
                        Position += Velocity;

                        if (_MovementAnimation != null)
                        {
                                _MovementAnimation.Update(gameTime);
                        }

                        base.Update(gameTime);
                }



                public override void Draw(GameTime gameTime)
                {
                        base.Draw(gameTime);

                        if (_MovementAnimation != null)
                        {
                                _MovementAnimation.Draw(
                                    _Game.SpriteBatch,
                                    _Position,
                                    Vector2.Zero,
                                    0,
                                    Vector2.One,
                                    Color.White,
                                    SpriteEffects.None,
                                    0);
                        }
                }
        }
}