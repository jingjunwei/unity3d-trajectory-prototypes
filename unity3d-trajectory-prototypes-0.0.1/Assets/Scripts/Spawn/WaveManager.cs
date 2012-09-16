#region MIT License

// WaveManager.cs
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
using KeigunGi.Spawn;
using KeigunGi.Message;

#endregion

/// <summary>
/// Manage the prefab and counter.
/// As a entry, reveive messages.
/// Run main loop.
/// </summary>
public class WaveManager : ResetableBehaviour
{
    #region Serialize

    [SerializeField]
    protected WavePreset preset;

    #endregion

    #region Bridge Property

    protected WaveSpawnMessage Message
    {
        get
        {
            return preset.Message;
        }
    }

    protected WaveCounter Counter
    {
        get
        {
            return preset.Counter;
        }
    }

    protected virtual void ResetSerial()
    {
        preset.ResetSerial();
    }

    #endregion

    #region Public

    public virtual void OnAddWaveMessage()
    {
        AddWave();
    }

    public virtual void OnStopAllWaveMessage()
    {
        StopAllWave();
    }

    protected override void Reset()
    {
        preset.Reset();
    }

    #endregion

    #region NonPublic

    protected virtual void AddWave()
    {
        PrepareNextWave();
        //HACK C# version InvokeRepeating
        InvokeRepeating
            ("RepeatSpawn", preset.TimeBeforeStart, preset.TimeRepeat);
    }

    protected virtual void PrepareNextWave()
    {
        Counter.RandomizeWave();
        Message.Send(Message.next);
    }

    protected virtual void RepeatSpawn()
    {
        var isEnd = OnTotalEnd();
        if(!isEnd)
        {
            OnWaveEnd();
            Message.Send(Message.spawn);
            Counter.OnNextCountMessage();
        }
        else
        {
#if UNITY_EDITOR
            DebugUtility.Log("TotalWaveCount Reached!");
#endif
        }
    }

    /// <summary>
    /// Generate new wave and path
    /// on all spawn finished
    /// </summary>
    protected virtual void OnWaveEnd()
    {
        if(Counter.IsWaveOver)
        {
            PrepareNextWave();
        }
    }

    /// <summary>
    /// Stop on spawned all resources
    /// </summary>
    protected virtual bool OnTotalEnd()
    {
        var isEnd = Counter.IsTotalOver;
        if(isEnd)
        {
            StopAllWave();
        }
        return isEnd;
    }

    protected virtual void StopAllWave()
    {
        //HACK C# version InvokeRepeating
        CancelInvoke();
    }

    #endregion
}