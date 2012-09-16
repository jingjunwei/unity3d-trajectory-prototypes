#region MIT License

// TrajectoryVelocityPhysics.cs
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

#endregion

namespace KeigunGi.Math
{
    /// <summary>
    /// 剛体が放物線のような動きができるための速度を計算
    /// </summary>
    public class TrajectoryVelocityPhysics : PhysicsBase
    {
        #region Trajectory

        public virtual Vector3 GetTrajectoryVelocity(TrajectoryPoints points)
        {
            var height = Mathf.Abs(points.top.y - points.start.y);
            var velocityY = GetVelocityVertical(height);

            var veloctiyX = GetVelocityHorizontalFromTo
                (points.start.x, points.end.x, velocityY);
            var veloctiyZ = GetVelocityHorizontalFromTo
                (points.start.z, points.end.z, velocityY);

            return new Vector3(veloctiyX, velocityY, veloctiyZ);
        }

        protected virtual float GetVelocityHorizontalFromTo
            (float start, float end, float velocityVertical)
        {
            var direction = default(float);
            if(end > start)
            {
                direction = 1.0f;
            }
            else
            {
                direction = -1.0f;
            }

            var range = Mathf.Abs(end - start);
            var veloctiyHorizontal = GetVelocityHorizontal
                (range, velocityVertical, Gravity);
            veloctiyHorizontal *= direction;

            return veloctiyHorizontal;
        }

        protected virtual float GetVelocityVertical(float height)
        {
            return Mathf.Sqrt(2.0f * Gravity * height);
        }

        protected virtual float GetVelocityHorizontal
            (float distanceHorizontal, float verticalVelocity, float gravity)
        {
            float time = (2.0f * verticalVelocity) / gravity;
            return (distanceHorizontal / time);
        }

        #endregion
    }
}