#region MIT License

// ExceptionUtility.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/09 8:45
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

using System;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// デバッグ用例外検査・報告
    /// </summary>
    public static class ExceptionUtility
    {
        #region Check

        public static bool IsNull(object checker, string log = null)
        {
            bool isNull = checker == null;

#if UNITY_EDITOR
            if(isNull)
            {
                Null(log);
            }
#endif
            return isNull;
        }

        #endregion

        #region Exception 

        public static void NotFound(string nameA, string nameB)
        {
#if UNITY_EDITOR
            if(DebugUtility.ShowLog)
            {
                var log = String.Format("Not Found: {0} on {1}", nameA, nameB);
                DebugUtility.Log(log);
            }
#endif
        }

        public static void SwitchDefault()
        {
#if UNITY_EDITOR
            DebugUtility.LogError("Switch Case Not Found!");
#endif
        }

        public static void Null(string log = "Null")
        {
#if UNITY_EDITOR
            if(DebugUtility.ShowError)
            {
                DebugUtility.LogError(log);
            }
#endif
        }

        public static void IllegalComponent(MonoBehaviour target)
        {
            DebugUtility.Log("This base class coundn't be component.");
            Object.Destroy(target);
        }

        #endregion
    }
}