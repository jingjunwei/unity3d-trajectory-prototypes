#region MIT License

// DebugInspector.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 20:41
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

using KeigunGi.General;
using UnityEngine;
using System.Collections.Generic;

#endregion

/// <summary>
/// デバッグOn/Off値の設定
/// デバッグ情報表示をOn/Offさせる
/// </summary>
[ExecuteInEditMode]
public class DebugInspector : ResetableBehaviour
{
    #region Serialize

    public bool showGUI;
    public bool showLog;
    public bool showError;
    public bool showLine;
    public float lineDelay;
    public float triggerDelay;
    public List<MonoBehaviour> guiBehaviours;

    #endregion

    protected virtual void Awake()
    {
        UpdateCache();
        InvokeRepeating("TriggerGUI", triggerDelay, triggerDelay);
    }

    protected virtual void OnEnable()
    {
        UpdateCache();
    }

    protected void TriggerGUI()
    {
        guiBehaviours.ForEach
            ((behaviour) =>
            {
                behaviour.enabled = showGUI;
            });
    }

    protected virtual void UpdateCache()
    {
        DebugUtility.inspector = this;
    }

    protected override void Reset()
    {
        UpdateCache();

        showGUI = true;
        showLog = false;
        showError = false;
        showLine = true;
        lineDelay = 3.0f;
        triggerDelay = 1.0f;
        var guiNames = new List<string>
        {
            "ExampleWave",
            "ExampleWave3d",
            "ExampleSpawn"
        };

        guiBehaviours = new List<MonoBehaviour>();
        guiNames.ForEach
            ((name) =>
            {
                var gui = (MonoBehaviour)FindComponent(name, name);
                var valid = gui != null;
                if(valid)
                {
                    guiBehaviours.Add(gui);
                }
            });
    }
}