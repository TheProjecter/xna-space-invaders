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
                /// The circular bounds of the object.
                /// </summary>
                Circle BoundingCircle { get; }



                /// <summary>
                /// The polygonal bounds of the object.
                /// </summary>
                Polygon BoundingPolygon { get; }



                /// <summary>
                /// Determines what should happen when a collision occurs.
                /// </summary>
                /// <param name="other"></param>
                void CollideWith(ICollidable other);
        }
}