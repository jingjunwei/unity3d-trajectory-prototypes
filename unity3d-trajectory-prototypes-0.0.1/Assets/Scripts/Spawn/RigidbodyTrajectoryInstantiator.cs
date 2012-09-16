#region MIT License

// RigidbodyTrajectoryInstantiator.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/02 16:29
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

/// <summary>
/// 数学計算した上で剛体オブジェクトを一つ作る。
/// その動きは放物線の起点・頂点・終点に合わせる。
/// </summary>
[Serializable]
public class RigidbodyTrajectoryInstantiator : RigidbodyInstantiator
{
    public TrajectoryPoints points;

    public override GameObject Spawn()
    {
        var calculator = new TrajectoryVelocityPhysics();
        velocity = calculator.GetTrajectoryVelocity(points);
        position = points.start;

#if UNITY_EDITOR
        DebugUtility.DrawLine(points.start, points.top, Color.red);
        DebugUtility.DrawLine(points.top, points.end, Color.yellow);
#endif

        return base.Spawn();
    }

    #region Reset

    protected virtual void Reset
        (Vector3 pointStart, Vector3 pointTop, Vector3 pointEnd)
    {
        points = new TrajectoryPoints
        {
            start = pointStart,
            top = pointTop,
            end = pointEnd
        };
    }

    #endregion
}