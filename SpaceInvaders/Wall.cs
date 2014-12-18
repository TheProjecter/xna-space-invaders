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
                /// Determines what should happen when a collision occurs.
                /// </summary>
                /// <param name="other"></param>
                public void CollideWith(ICollidable other)
                {
                        throw new System.NotImplementedException();
                }


                // End of ICollidable overrides region
                #endregion
        }
}