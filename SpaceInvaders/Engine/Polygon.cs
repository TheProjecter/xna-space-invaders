using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Xna.Framework;



namespace SpaceInvaders.Engine
{
        /*
            http://www.codeproject.com/Articles/15573/D-Polygon-Collision-Detection?msg=1675819#xx1675819xx

            The MIT License (MIT)

            Copyright (c) <2006> <Laurent Cozic>

            Permission is hereby granted, free of charge, to any person obtaining a copy
            of this software and associated documentation files (the "Software"), to deal
            in the Software without restriction, including without limitation the rights
            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
            copies of the Software, and to permit persons to whom the Software is
            furnished to do so, subject to the following conditions:

            The above copyright notice and this permission notice shall be included in
            all copies or substantial portions of the Software.

            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
            THE SOFTWARE.


            */
        /// <summary>
        /// A plane figure with at least three straight sides and angles.
        /// </summary>
        internal class Polygon
        {
                /// <summary>
                /// Create a polygon out of the provided verticies.
                /// </summary>
                /// <param name="verticies">The collection of points creating the polygon's verticies.</param>
                public Polygon(Vector2[] verticies)
                {
                        if (verticies == null)
                        {
                                throw new ArgumentNullException();
                        }

                        if (verticies.Length < 3)
                        {
                                throw new ArgumentException("Polygons require at least three verticies!");
                        }

                        _Vertecies.AddRange(verticies);
                        BuildEdges();
                        CalculateCenter();
                }



                #region " Properties "


                /// <summary>
                /// Gets the edges of the polygon.
                /// </summary>
                public ReadOnlyCollection<Vector2> Edges
                {
                        get { return new ReadOnlyCollection<Vector2>(_Edges); }
                }
                private readonly List<Vector2> _Edges = new List<Vector2>();



                /// <summary>
                /// Gets the verticies of the polygon.
                /// </summary>
                public ReadOnlyCollection<Vector2> Verticies
                {
                        get { return new ReadOnlyCollection<Vector2>(_Vertecies); }
                }
                private readonly List<Vector2> _Vertecies = new List<Vector2>();



                /// <summary>
                /// Gets the venter of the polygon.
                /// </summary>
                public Vector2 Center
                {
                        get { return _Center; }
                }
                private Vector2 _Center;


                // End of Properties region
                #endregion



                #region " Methods "


                /// <summary>
                /// Iterates through the polygon's verticies and creates an edge vector from each connected point.
                /// </summary>
                private void BuildEdges()
                {
                        for (int i = 0; i < _Vertecies.Count; i++)
                        {
                                Vector2 p1 = _Vertecies[i];
                                Vector2 p2 = _Vertecies[(i + 1) % _Vertecies.Count];
                                _Edges.Add(p2 - p1);
                        }
                }



                /// <summary>
                /// Determines the center of the polygon and applies it the resulting value to the polygon instance.
                /// </summary>
                private void CalculateCenter()
                {
                        float totalX = 0;
                        float totalY = 0;
                        for (int i = 0; i < _Vertecies.Count; i++)
                        {
                                totalX += _Vertecies[i].X;
                                totalY += _Vertecies[i].Y;
                        }

                        _Center = new Vector2(totalX / _Vertecies.Count, totalY / _Vertecies.Count);
                }



                /// <summary>
                /// Shifts each of the polygon's verticies by the given delta.
                /// </summary>
                /// <param name="delta">The directional displacement to apply to the polygon.</param>
                public void Offset(Vector2 delta)
                {
                        for (int verticeIndex = 0; verticeIndex < _Vertecies.Count; verticeIndex++)
                        {
                                _Vertecies[verticeIndex] += delta;
                        }
                        CalculateCenter();
                }


                // End of Methods region
                #endregion



                #region " Object overrides "


                /// <summary>
                /// Createa a string representation of the polygon.
                /// </summary>
                /// <returns></returns>
                public override string ToString()
                {
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < _Vertecies.Count; i++)
                        {
                                if (sb.Length > 0)
                                {
                                        sb.Append(" ");
                                }
                                sb.Append('{').Append(_Vertecies[i]).Append('}');
                        }

                        return sb.ToString();
                }


                // End of Object overrides
                #endregion

        }
}