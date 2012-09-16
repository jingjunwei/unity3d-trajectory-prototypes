#region MIT License

// ExampleWave.cs
// Author: Keigun Gi
// Mail: keigungi@yahoo.co.jp
// Blog: keigungi.hatenablog.com
// Last Modified: 2012/09/15 16:26
// Created: 2012/09/02 10:36
// 
// MIT License
// Copyright (c) 2012 Jing-Jun Wei
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using UnityEngine;
using KeigunGi.Example;
using KeigunGi.Message;

#endregion

/// <summary>
/// 連続で放物線剛体を生成する例。
/// </summary>
public class ExampleWave : ResetableBehaviour
{
    [SerializeField]
    protected ExampleWavePreset preset;

    #region Property

    public ExampleWavePreset Preset
    {
        get
        {
            return preset;
        }
    }

    protected WaveControlMessage Message
    {
        get
        {
            return Preset.Message;
        }
    }

    #endregion

    #region Common Method

    protected virtual void Start()
    {
        AddWave();
    }

#if UNITY_EDITOR
    /// <summary>
    /// Addボタンを押すと、追加メーセージが発信され、生成が早くなる。
    /// StopAllボタンを押すと、生成が段々停止する
    /// </summary>
    protected virtual void OnGUI()
    {
        if(DebugUtility.ShowGUI)
        {
            if(GUILayout.Button("Add"))
            {
                AddWave();
            }
            if(GUILayout.Button("StopAll"))
            {
                StopAllWave();
            }
        }
        else
        {
            enabled = false;
        }
    }

#endif

    protected override void Reset()
    {
        Preset.Reset();
    }

    #endregion

    #region Wave Method

    protected virtual void AddWave()
    {
        Message.Send(Message.add);
    }

    protected virtual void StopAllWave()
    {
        Message.Send(Message.stopAll);
    }

    #endregion
}