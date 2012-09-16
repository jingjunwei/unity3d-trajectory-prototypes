#region MIT License

// ExtendBehaviour.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:57
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
using System.Collections.Generic;
using KeigunGi.General;
using KeigunGi.Example;

#endregion

/// <summary>
/// 自作機能追加用モーノーベッハビオー
/// 原MonoBehaviourの代わりにこれを継承
/// </summary>
public class ExtendBehaviour : MonoBehaviour
{
    #region Property

    /// <summary>
    /// 同ゲームオブジェクト上の自分以外のMonoBehaviourを探し出す
    /// </summary>
    public virtual List<MonoBehaviour> MonoBehaviourOthers
    {
        get
        {
            var list = GetComponentList<MonoBehaviour>();
            list.Remove(this);
            return list;
        }
    }

    #endregion

    #region GetComponent

    /// <summary>
    /// 公式GetComponentsを自動List化
    /// </summary>
    public virtual List<T> GetComponentList<T>() where T: Component
    {
        return new List<T>(GetComponents<T>());
        ;
    }

    #endregion

    #region FindComponent

    /// <summary>
    /// 所在オブジェクトから標的コンポーネントを探し出す
    /// </summary>
    /// <param name="targetObjectName">標的のゲームオブジェクト名</param>
    /// <param name="targetName">標的のクラス名</param>
    /// <returns></returns>
    public static Component FindComponent
        (string targetObjectName, string targetName)
    {
        Component component = default(Component);
        var targetObject = GameObject.Find(targetObjectName);
        if(targetObject)
        {
            component = targetObject.GetComponent(targetName);
        }
        return component;
    }

    #endregion
}