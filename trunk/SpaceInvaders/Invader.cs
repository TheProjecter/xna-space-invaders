using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
    internal class Invader : DrawableGameComponent
    {
        private Animation _MovementAnimation;
        private SpaceInvaders _Game;



        public Invader(SpaceInvaders game) : base(game)
        {
            _Game = game;
        }



        public Animation MovementAnimation
        {
            get { return _MovementAnimation; }
            set { _MovementAnimation = value; }
        }



        public Vector2 Position
        {
            get { return Position; }
            set { _Position = value; }
        }
        private Vector2 _Position;



        public override void Update(GameTime gameTime)
        {
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