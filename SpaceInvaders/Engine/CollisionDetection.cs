using System;
using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        internal static partial class CollisionDetection
        {
                // Structure that stores the results of the PolygonCollision function
                public struct CollisionResult
                {
                        /// <summary>
                        /// Gets or sets the value specifying if the two objects are will collide sometime in the future
                        /// </summary>
                        public Nullable<bool> WillCollide;


                        /// <summary>
                        /// Gets or sets the value specifying that the two objects are currently intersecting
                        /// </summary>
                        public Nullable<bool> HaveCollided;
                        
                        
                        /// <summary>
                        /// The translation which should be applied to first colliding object in order to push the two colliding objects apart.
                        /// </summary>
                        public Nullable<Vector2> CorrectionVector;
                }
        }
}