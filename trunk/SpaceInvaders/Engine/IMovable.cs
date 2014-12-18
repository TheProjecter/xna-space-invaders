using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        public interface IMovable2D : IPositionable2D
        {
                Vector2 Velocity { get; set; }
        }
}