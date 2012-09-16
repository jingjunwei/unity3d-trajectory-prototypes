#region MIT License

// RandomUtility.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/02 10:36
// 
// Author: Jing-Jun Wei
// Mail: jingjunwei@outlook.com
// Homepage: http://jingjunwei.github.com/unity3d-trajectory-prototypes/
// 
// MIT License
// Copyright (c) 2012 Jing-Jun Wei
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using UnityEngine;
using System.Collections.Generic;

#endregion

namespace KeigunGi.Math
{
    /// <summary>
    /// Unity3Dの原Randomクラスを利用した自作乱数機能拡張クラス
    /// </summary>
    public class RandomUtility : Vector3Utility
    {
        #region Misc

        /// <summary>
        /// Randomly get a value in a list
        /// </summary>
        protected virtual T RandomGet<T>(List<T> list)
        {
            var randomId = Random.Range(0, list.Count);
            return list[randomId];
        }

        #endregion

        #region RandomMinMax

        protected virtual Vector3 RandomMinMax(Vector3 min, Vector3 max)
        {
            return new Vector3
                (Random.Range(min.x, max.x), Random.Range(min.y, max.y),
                 Random.Range(min.z, max.z));
        }

        protected virtual Vector3 RandomMinMax(Vector3Range range)
        {
            return RandomMinMax(range.min, range.max);
        }

        /// <summary>
        /// Randomly get constrained vector3 in range
        /// </summary>
        protected virtual Vector3 MinMaxConstrained(Vector3Range range)
        {
            var randomizedValue = RandomMinMax(range);
            return Constrain(range, randomizedValue);
        }

        #endregion

        #region Trajectory

        /// <summary>
        /// Randomly get trajectory points in range
        /// Geerate randomized trajectory points and calculate velocity on spawn
        /// </summary>
        protected virtual TrajectoryPoints RandomizeTrajectory
            (Vector3Range range)
        {
            var points = new TrajectoryPoints();
            points.start = TrajecoryHorizontalPoint(range);
            points.end = TrajecoryHorizontalPoint(range);
            points.top = TrajecoryVerticalPoint(points, range);
            return points;
        }

        protected Vector3 TrajecoryHorizontalPoint(Vector3Range range)
        {
            var origin = range.defaultValue;
            var min = range.min;
            var max = range.max;
            return new Vector3
                (Random.Range(min.x, max.x), origin.y,
                 Random.Range(min.z, max.z));
        }

        protected Vector3 TrajecoryVerticalPoint
            (TrajectoryPoints points, Vector3Range range)
        {
            var origin = range.defaultValue;
            var min = range.min;
            var max = range.max;
            return new Vector3
                ((points.start.x + points.end.x) / 2.0f,
                 Random.Range(min.y, max.y),
                 (points.start.z + points.end.z) / 2.0f);
        }

        #endregion
    }
}