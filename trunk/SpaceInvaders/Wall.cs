using Microsoft.Xna.Framework;
using SpaceInvaders.Engine;



namespace SpaceInvaders
{
    internal class Wall : ICollidable
    {
        #region Implementation of IPositionable2D

        public Vector2 Position { get; set; }

        #endregion

        #region Implementation of IMovable2D

        public Vector2 Velocity { get; set; }

        #endregion

        #region " ICollidable overrides "


        /// <summary>
        /// The rectangular bounds of the object.
        /// </summary>
        public Rectangle BoundingBox { get; private set; }



        /// <summary>
        /// The circular bounds of the object.
        /// </summary>
        public Circle BoundingCircle { get; private set; }



        /// <summary>
        /// The polygonal bounds of the object.
        /// </summary>
        public Polygon BoundingPolygon { get; private set; }



        /// <summary>
        /// Determines what should happen when a collision occurs.
        /// </summary>
        /// <param name="other"></param>
        public void CollideWith(ICollidable other)
        {
            Invader invader = other as Invader;
            if (invader != null)
            {
                
            }
        }


        // End of ICollidable overrides region
        #endregion
    }
}