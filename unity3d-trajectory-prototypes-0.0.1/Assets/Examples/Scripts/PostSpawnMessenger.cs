#region MIT License

// PostSpawnMessenger.cs
// Author: Keigun Gi
// Mail: keigungi@yahoo.co.jp
// Blog: keigungi.hatenablog.com
// Last Modified: 2012/09/15 16:25
// Created: 2012/09/11 16:43
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
using KeigunGi.Math;
using UnityEngine;
using KeigunGi.Message;

#endregion

/// <summary>
/// 放物線の生産の制御に関係するメーセージ情報の設定
/// </summary>
public class PostSpawnMessenger : Messenger
{
    #region  Enum

    public enum ObjectTarget
    {
        PresetObject,
        TrajectoryRange,
        SpawnMessenger
    }

    public enum Target
    {
        PresetObject,
        TrajectoryRange,
        TrajectorySpawnerWithName
    }

    public enum Method
    {
        OnSpawnObjectGet,
        OnSpawnRangeGet,
        OnModify,
        OnSpawn
    }

    protected override List<Type[]> ParameterTypes
    {
        get
        {
            return new List<Type[]>
            {
                Type.EmptyTypes,
                Type.EmptyTypes,
                new[]
                {
                    typeof(object)
                },
                Type.EmptyTypes
            };
        }
    }

    #endregion

    #region  Override

    protected override List<GameObject> TargetObjects
    {
        get
        {
            var targetObjectModifySpawn = GetObject(ObjectTarget.SpawnMessenger);

            return new List<GameObject>
            {
                GetObject(ObjectTarget.PresetObject),
                GetObject(ObjectTarget.TrajectoryRange),
                targetObjectModifySpawn,
                targetObjectModifySpawn
            };
        }
    }

    protected override List<string> TargetNames
    {
        get
        {
            var spawnerName = GetName(Target.TrajectorySpawnerWithName);
            return new List<string>
            {
                GetName(Target.PresetObject),
                GetName(Target.TrajectoryRange),
                spawnerName,
                spawnerName
            };
        }
    }

    #endregion

    //TDOO NO SEND

    #region Method

    /// <summary>
    /// MethodCacherを呼んで、生み出すオブジェクトをゲット
    /// </summary>
    /// <returns></returns>
    protected List<GameObject> GetObject()
    {
        return (List<GameObject>)GetObjectCacher().Send();
    }

    protected List<Vector3Range> GetRange()
    {
        return (List<Vector3Range>)GetRangeCacher().Send();
    }

    protected void Modify(object actionObject)
    {
        ModifyCacher().Send(actionObject);
    }

    protected void Spawn()
    {
        SpawnCacher().Send();
    }

    #endregion

    #region Cacher

    protected MethodCacher GetObjectCacher()
    {
        return GetMethod(Method.OnSpawnObjectGet);
    }

    protected MethodCacher GetRangeCacher()
    {
        return GetMethod(Method.OnSpawnRangeGet);
    }

    protected MethodCacher ModifyCacher()
    {
        return GetMethod(Method.OnModify);
    }

    protected MethodCacher SpawnCacher()
    {
        var spawn = GetMethod(Method.OnSpawn);
        return spawn;
    }

    #endregion
}