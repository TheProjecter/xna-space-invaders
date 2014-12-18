using System;
using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        internal static class CollisionDetection
        {
                // https://developer.mozilla.org/en-US/docs/Games/Techniques/2D_collision_detection


                public static class AxisAlignedBoundingBoxes
                {
                        /// <summary>
                        /// Determines if two objects have collided using Axis-Aligned Bounding Box
                        /// </summary>
                        /// <param name="first">The first object to check.</param>
                        /// <param name="second">The second object to check.</param>
                        /// <returns>True if a collision was detected, false otherwise.</returns>
                        /// <remarks>
                        ///
                        ///    Ax,Ay                    Bx,By
                        ///      ---------------          ---------------
                        ///      -             -          -             -
                        ///      -             -          -             -
                        ///      -             -          -             -
                        ///      -             -          -             -
                        ///      ---------------          ---------------
                        ///                  AX,AY                     BX,BY
                        ///
                        /// They are seperate if any of these statements are true:
                        ///
                        ///  AX is less than Bx
                        ///  BX is less than Ax
                        ///  AY is less than By
                        ///  BY is less than Ay
                        ///
                        /// </remarks>
                        public static bool HaveCollided(ICollidable first, ICollidable second)
                        {
                                if (first == null)
                                {
                                        throw new ArgumentNullException("first");
                                }

                                if (second == null)
                                {
                                        throw new ArgumentNullException("second");
                                }

                                Rectangle a = first.BoundingBox;
                                Rectangle b = second.BoundingBox;

                                //return !(a.Right < b.X
                                //         || b.Right < a.X
                                //         || a.Bottom < b.Y
                                //         || b.Bottom < a.Y);

                                return (a.Right > b.X && b.Right > a.X && a.Bottom > b.Y && b.Bottom > a.Y);
                        }
                }



                
        }
}