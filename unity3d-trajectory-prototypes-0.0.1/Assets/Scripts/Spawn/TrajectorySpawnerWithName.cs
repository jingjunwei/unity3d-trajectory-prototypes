#region MIT License

// TrajectorySpawnerWithName.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/12 15:33
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

#endregion

//TODO Replace With Event System
public class TrajectorySpawnerWithName : SpawnMessenger, IPostSpawnControllable
{
    #region Message

    /// <summary>
    /// 放物線の生産者が作り出す前に、その規定値を何らかの処理に通る。パラメータ変更とか。
    /// <param name="actionObject">処理する方。
    /// </param>
    /// </summary>
    public virtual void OnModify(object actionObject)
    {
        Modify(actionObject);
    }

    /// <summary>
    /// 規定値で剛体一つを作り出す。動きは放物線に合わせる。
    /// </summary>
    public virtual void OnSpawn()
    {
        Spawn();
    }

    #endregion

    #region Method

    protected override GameObject Spawn()
    {
        var spawnedObject = base.Spawn();
        SetName(spawnedObject);
        Next();

        return spawnedObject;
    }

    /// <summary>
    /// objectを変換が必要
    /// </summary>
    /// <param name="actionObject"></param>
    protected virtual void Modify(object actionObject)
    {
        var action = (Action<RigidbodyTrajectoryInstantiator>)actionObject;
        var target = (RigidbodyTrajectoryInstantiator)TargetInstantiator;
        action(target);
    }

    #endregion
}