#region MIT License

// DebugUtility.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 20:32
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

///<summary>
/// Unity3Dの原Debugクラスの改造バージョン
///</summary>
public static class DebugUtility
{
    public static DebugInspector inspector;

    #region Property

    public static bool ShowGUI
    {
        get
        {
            return inspector.showGUI;
        }
    }

    public static bool ShowLog
    {
        get
        {
            return inspector.showLog;
        }
    }

    public static bool ShowError
    {
        get
        {
            return inspector.showError;
        }
    }

    public static bool ShowLine
    {
        get
        {
            return inspector.showLine;
        }
    }

    public static float LineDelay
    {
        get
        {
            return inspector.lineDelay;
        }
    }

    #endregion

    #region Debug

    public static void Log(string log)
    {
        if(ShowLog)
        {
            Debug.Log(log);
        }
    }

    public static void LogError(string log)
    {
        if(ShowError)
        {
            if(log != null)
            {
                Debug.LogError(log);
            }
        }
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        if(ShowLine)
        {
            Debug.DrawLine(start, end, color, LineDelay);
        }
    }

    #endregion
}