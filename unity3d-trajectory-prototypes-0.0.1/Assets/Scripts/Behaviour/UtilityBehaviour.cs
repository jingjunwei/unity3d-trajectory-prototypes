#region MIT License

// UtilityBehaviour.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:57
// Created: 2012/09/12 9:45
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
using KeigunGi.Example;
using KeigunGi.Spawn;
using UnityEngine;
using KeigunGi.General;
using KeigunGi.Message;
using ObjectMode = KeigunGi.General.ObjectSelector.ObjectMode;

#endregion

public class UtilityBehaviour : ExtendBehaviour
{
    #region  Action

    protected readonly Action<int, Action<int>> For = (length, init) =>
    {
        for(var i = 0; i < length; i++)
        {
            init(i);
        }
    };

    #endregion

    #region  Func

    protected readonly Func<Type, int> GetLength = EnumUtility.GetLength;

    protected readonly Func<object, Enum, Type> GetEnumType =
        EnumUtility.GetInnerEnumType;

    protected readonly Func<Type, List<string>> GetNames = EnumUtility.GetNames;

    #endregion

    #region Message

    public readonly Type[] SenderParameterTypes = new[]
    {
        typeof(string), typeof(object[])
    };

    #endregion

    #region  Collection

    protected virtual List<T> Fill<T>(T value, int length)
    {
        return Collection.Fill(value, length);
    }

    #endregion

    #region Enum

    /// <summary>
    /// 便利で枚挙のストリングをゲット
    /// </summary>
    protected virtual string GetName<T>(T target)
    {
        return EnumUtility.GetName(target);
    }

    //TODO HACK: Func With Nested Gerneric
    protected virtual T GetById<T>(List<T> list, Enum method)
    {
        return EnumUtility.GetById(list, method);
    }

    #endregion
}