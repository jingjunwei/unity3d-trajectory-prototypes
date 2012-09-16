#region MIT License

// RandomizeSpawnMessenger.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/07 15:01
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
using KeigunGi.Spawn;

#endregion

/// <summary>
/// Receive messages and send spawn messages
/// </summary>
public class RandomizeSpawnMessenger : PostSpawnMessenger, IWaveControllable
{
    #region Property

    protected virtual TrajectoryRandomizer Randomizer
    {
        get;
        set;
    }

    #endregion

    #region Interface

    public virtual void OnNext()
    {
        RandomizeTrajectory();
    }

    public virtual void OnSpawn()
    {
        SpawnRandomizer();
    }

    #endregion

    #region Initialize

    protected override void Awake()
    {
        base.Awake();
        InitRandomizer();
    }

    protected virtual void InitRandomizer()
    {
        var spawnObjects = GetObject();
        var ranges = GetRange();
        Randomizer = new TrajectoryRandomizer(spawnObjects, ranges);
    }

    protected virtual void SendAction(object action)
    {
        Modify(action);
    }

    protected virtual void RandomizeTrajectory()
    {
        Action<RigidbodyTrajectoryInstantiator> modifyAction =
            (target) => Randomizer.Trajectory(target);
        SendAction(modifyAction);
    }

    protected virtual void SpawnRandomizer()
    {
        Action<RigidbodyTrajectoryInstantiator> spawnAction =
            (target) => Randomizer.Spawner(target);
        SendAction(spawnAction);
        Spawn();
    }

    #endregion
}