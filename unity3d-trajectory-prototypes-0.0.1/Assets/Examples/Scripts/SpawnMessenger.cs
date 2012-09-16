#region MIT License

// SpawnMessenger.cs
// Author: Keigun Gi
// Mail: keigungi@yahoo.co.jp
// Blog: keigungi.hatenablog.com
// Last Modified: 2012/09/15 16:24
// Created: 2012/09/12 14:03
// 
// MIT License
// Copyright (c) 2012 Jing-Jun Wei
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using System;
using System.Collections.Generic;
using KeigunGi.General;
using UnityEngine;
using KeigunGi.Message;
using ObjectMode = KeigunGi.General.ObjectSelector.ObjectMode;

#endregion

/// <summary>
/// 生み出す制御用メーセージの設定
/// </summary>
public class SpawnMessenger : Messenger
{
    #region  Enum

    private enum ObjectTarget
    {
        Instantiator,
        NameCounter
    }

    private enum Target
    {
        Instantiator,
        NameCounter,
    }

    private enum Method
    {
        Spawn,
        OnSetNameMessage,
        OnNextCountMessage
    }

    protected override List<Type[]> ParameterTypes
    {
        get
        {
            return new List<Type[]>
            {
                Type.EmptyTypes,
                new[]
                {
                    typeof(GameObject)
                },
                Type.EmptyTypes,
            };
        }
    }

    #endregion

    #region Property

    protected virtual object TargetInstantiator
    {
        get
        {
            return GetTarget(Target.Instantiator);
        }
    }

    #endregion

    #region  Override

    protected override List<GameObject> TargetObjects
    {
        get
        {
            var counter = GetObject(ObjectTarget.NameCounter);

            return new List<GameObject>
            {
                GetObject(ObjectTarget.Instantiator),
                counter,
                counter
            };
        }
    }

    protected override List<string> TargetNames
    {
        get
        {
            var counter = GetName(Target.NameCounter);
            return new List<string>
            {
                GetName(Target.Instantiator),
                counter,
                counter
            };
        }
    }

    #endregion

    #region Public

    protected virtual GameObject Spawn()
    {
        var spawn = GetMethod(Method.Spawn);
        var spawnedObject = spawn.Send();

        return (GameObject)spawnedObject;
    }

    protected void SetName(GameObject target)
    {
        var setName = GetMethod(Method.OnSetNameMessage);
        setName.Send(target);
    }

    protected void Next()
    {
        GetMethod(Method.OnNextCountMessage).Send();
    }

    #endregion

    #region  Cache

    private MethodCacher SpawnCacher()
    {
        return GetMethod(Method.Spawn);
    }

    private MethodCacher SetNameCacher()
    {
        return GetMethod(Method.OnSetNameMessage);
    }

    private MethodCacher NextCacher()
    {
        return GetMethod(Method.OnNextCountMessage);
    }

    #endregion
}