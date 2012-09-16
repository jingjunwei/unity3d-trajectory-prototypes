#region MIT License

// NameCounter.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/03 13:22
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
using System;

#endregion

/// <summary>
/// Êý¤ò¤·¤Æ¥²©`¥à¥ª¥Ö¥¸¥§¥¯¥È¤ÎÃûÇ°¤Ë¸¶¤±¤µ¤ì¤ë¤¿¤á¤Î¥¯¥é¥¹
/// </summary>
public class NameCounter : Counter
{
    #region Serialize

    [SerializeField]
    protected string nameTarget;

    [SerializeField]
    protected string format;

    #endregion

    #region Method

    public virtual void OnSetNameMessage(GameObject target)
    {
        SetName(target);
    }

    //HACK counter name with prefab name
    protected virtual void SetName(GameObject target)
    {
        var nameFormatted = String.Format(format, nameTarget, CountTotal);
        target.name = nameFormatted;
    }

    #endregion

    #region Reset

    //TODO HACK: NO Params
    protected virtual void Reset(params string[] parameters)
    {
        nameTarget = parameters[0];
        format = parameters[1];
    }

    protected virtual void Reset()
    {
        Reset("objectSpawned", "{0}_{1}");
    }

    #endregion
}