using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        internal struct Circle
        {
                /// <summary>
                /// Creates a new Circle.
                /// </summary>
                /// <param name="radius">The radius of the circle.</param>
                /// <param name="x">The location on the x-axis for the center of the circle.</param>
                /// <param name="y">The location on the y-axis for the center of the circle.</param>
                public Circle(int radius, int x, int y)
                {
                        _X = x;
                        _Y = y;
                        _Radius = radius;
                }



                #region " Properties "


                /// <summary>
                /// Gets the X coordinate of the center of the circle.
                /// </summary>
                public int X
                {
                        get { return _X; }
                }
                private int _X;



                /// <summary>
                /// Gets the Y coordinate of the center of the circle.
                /// </summary>
                public int Y
                {
                        get { return _Y; }
                }
                private int _Y;



                /// <summary>
                /// Gets the radius of the circle.
                /// </summary>
                public int Radius
                {
                        get { return _Radius; }
                }
                private int _Radius;


                /// <summary>
                /// Gets or sets the location of the center of the circle.
                /// </summary>
                public Point Center
                {
                        get
                        {
                                return new Point(_X, _Y);
                        }
                        set
                        {
                                _X = value.X;
                                _Y = value.Y;
                        }
                }


                // End of Properties region
                #endregion



                #region " Methods "


                /// <summary>
                /// Determines if the specified point is within the circle.
                /// </summary>
                /// <param name="point">The location to check.</param>
                /// <returns>True if the point is within the circle, false otherwise.</returns>
                public bool ContainsPoint(Point point)
                {
                        Vector2 vector = new Vector2(_X, _Y);
                        return vector.Length() <= _Radius;
                }


                // End of Methods region
                #endregion
        }
}