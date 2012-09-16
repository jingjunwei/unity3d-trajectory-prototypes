#region MIT License

// Instantiator.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
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
using KeigunGi.General;
using Object = UnityEngine.Object;

#endregion

/// <summary>
/// Unity3DのInstantiateを利用した生成者達のベースクラス
/// パラメーターからオブジェクトを生成
/// </summary>
public class Instantiator : ExtendBehaviour
{
    #region Serialize

    public GameObject prefab;
    public Vector3 position;
    public Vector3 eulerAngles;

    public Quaternion Rotation
    {
        get
        {
            return Quaternion.Euler(eulerAngles);
        }
    }

    #endregion

    public virtual GameObject Spawn()
    {
        var spawnedObject = (GameObject)Instantiate(prefab, position, Rotation);
        return spawnedObject;
    }

    protected virtual void Reset(string prefabPath)
    {
        var resource = new ResourceLoader<GameObject>(prefabPath);
        prefab = resource.Load();
    }
}