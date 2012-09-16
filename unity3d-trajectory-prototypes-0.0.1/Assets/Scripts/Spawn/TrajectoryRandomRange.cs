#region MIT License

// TrajectoryRandomRange.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 10:03
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
using System;
using KeigunGi.Math;

#endregion

namespace KeigunGi.Spawn
{
    [Serializable]
    public class TrajectoryRandomRange
    {
        #region Serialize

        [SerializeField]
        protected Vector3Range pointRange;

        [SerializeField]
        protected Vector3Range angularVelocity;

        [SerializeField]
        protected Vector3Range eulerAngles;

        #endregion

        #region Property

        public Vector3Range PointRange
        {
            get
            {
                return pointRange;
            }
            protected set
            {
                pointRange = value;
            }
        }

        public Vector3Range AngularVelocity
        {
            get
            {
                return angularVelocity;
            }
            protected set
            {
                angularVelocity = value;
            }
        }

        public Vector3Range EulerAngles
        {
            get
            {
                return eulerAngles;
            }
            protected set
            {
                eulerAngles = value;
            }
        }

        #endregion

        #region Reset

        public TrajectoryRandomRange
            (Vector3Range point, Vector3Range angular, Vector3Range euler)
        {
            pointRange = point;
            angularVelocity = angular;
            eulerAngles = euler;
        }

        #endregion
    }
}