using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        internal interface ICollidable : IMovable2D
        {
                /// <summary>
                /// The rectangular bounds of the object.
                /// </summary>
                Rectangle BoundingBox { get; }



                /// <summary>
                /// Determines what should happen when a collision occurs.
                /// </summary>
                /// <param name="other"></param>
                void CollideWith(ICollidable other);
        }
}