#region MIT License

// WaveCounter.cs
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
using System;
using Random = UnityEngine.Random;

#endregion

/// <summary>
/// Operate and judge counts
/// </summary>
public class WaveCounter : Counter
{
    #region Serialize

    [SerializeField]
    protected int countWaveMin;

    [SerializeField]
    protected int countWaveMax;

    [SerializeField]
    protected int countTotalMax;

    #endregion

    #region Field

    // there are how many resources will be spawned in current wave
    protected int countWaveRemain;

    #endregion

    #region Property

    public virtual bool IsWaveOver
    {
        get
        {
            return countWaveRemain <= 0;
        }
    }

    public virtual bool IsTotalOver
    {
        get
        {
            var isOver = default(bool);
            if(countTotalMax == 0)
            {
                isOver = false;
            }
            else
            {
                isOver = CountTotal > countTotalMax;
            }
            return isOver;
        }
    }

    #endregion

    #region Method

    protected override void Reset()
    {
        countWaveMin = 1;
        countWaveMax = 5;
        countTotalMax = 0;
    }

    public void RandomizeWave()
    {
        countWaveRemain = Random.Range(countWaveMin, countWaveMax);
    }

    protected override void Next()
    {
        base.Next();
        countWaveRemain--;

#if UNITY_EDITOR
        if(DebugUtility.ShowLog)
        {
            //how many resources have been spawned
            var logNext = String.Format
                ("countTotal: {0}\ncountWaveRemain: {1}", CountTotal,
                 countWaveRemain);
            DebugUtility.Log(logNext);
        }
#endif
    }

    #endregion
}