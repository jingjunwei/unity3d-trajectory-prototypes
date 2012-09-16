#region MIT License

// Motion2dTrajectoryPreset.cs
// Author: Keigun Gi
// Mail: keigungi@yahoo.co.jp
// Blog: keigungi.hatenablog.com
// Last Modified: 2012/09/08 20:48
// Created: 2012/09/08 20:31
// 
// MIT License
// Copyright (c) 2012 Jing-Jun Wei
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using UnityEngine;
using KeigunGi.Math;

#endregion

/// <summary>
/// ２Ｄ放物線の乱数変動範囲の規定値クラス
/// </summary>
public sealed class TrajectoryRange2d : TrajectoryRange
{
    private void Reset()
    {
        var point = new Vector3Range
        {
            defaultValue = new Vector3(0, -2, 0),
            min = new Vector3(-2, 3, 0),
            max = new Vector3(2, 7, 0),
            constrainX = false,
            constrainY = false,
            constrainZ = true
        };
        var angular = new Vector3Range
        {
            defaultValue = new Vector3(0, 0, 0),
            min = new Vector3(0, 0, -5),
            max = new Vector3(0, 0, 5),
            constrainX = true,
            constrainY = true,
            constrainZ = false
        };
        var euler = new Vector3Range
        {
            defaultValue = new Vector3(0, 0, 0),
            min = new Vector3(0, 0, 0),
            max = new Vector3(0, 0, 360),
            constrainX = true,
            constrainY = true,
            constrainZ = false
        };
        Reset(point, angular, euler);
    }
}