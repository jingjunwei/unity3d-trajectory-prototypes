#region MIT License

// TrajectoryRandomizer.cs
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
using KeigunGi.Math;

#endregion

namespace KeigunGi.Spawn
{
    /// <summary>
    /// Randomize instantiator with preset parameters
    /// </summary>
    public class TrajectoryRandomizer : RandomUtility
    {
        #region ReadOnly

        private readonly List<GameObject> prefabs;
        private readonly Vector3Range pointRange;
        private readonly Vector3Range eulerAngleRange;
        private readonly Vector3Range angularVelocityRange;

        #endregion

        #region Constructors

        /// <summary>
        /// Reset local variables
        /// </summary>
        public TrajectoryRandomizer
            (List<GameObject> objects, List<Vector3Range> random)
            : this(objects, random[0], random[1], random[2])
        {
        }

        public TrajectoryRandomizer
            (List<GameObject> prefabList, Vector3Range pointRangeTrajectory,
             Vector3Range angularVelocityOnSpawn,
             Vector3Range eulerAnglesOnSpawn)
        {
            prefabs = prefabList;
            pointRange = pointRangeTrajectory;
            eulerAngleRange = eulerAnglesOnSpawn;
            angularVelocityRange = angularVelocityOnSpawn;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Regenerate randomized trajectory parameters
        /// </summary>
        public void Trajectory<T>(T instantiator)
            where T: RigidbodyTrajectoryInstantiator
        {
            instantiator.points = RandomizeTrajectory(pointRange);
        }

        /// <summary>
        /// Regenerate randomized spawner parameters
        /// </summary>
        public void Spawner(RigidbodyInstantiator instantiator)
        {
            instantiator.angularVelocity = MinMaxConstrained
                (angularVelocityRange);
            var eulerAngles = MinMaxConstrained(eulerAngleRange);
            instantiator.eulerAngles = eulerAngles;
            instantiator.prefab = RandomGet(prefabs);
        }

        #endregion
    }
}