#region MIT License

// TagCollider.cs
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
using System.Collections.Generic;
using KeigunGi.General;
using Tag = KeigunGi.Example.TagBase.Tag;
using ActionType = KeigunGi.Example.TagBase.ActionType;

#endregion

/// <summary>
/// 衝突したオブジェクトのタグがタグリストに存在すると
/// 特定の処理をする。Triggerも対応。
/// </summary>
public class TagCollider : ResetableBehaviour
{
    #region Serialize

    [SerializeField]
    private List<Tag> tags;

    [SerializeField]
    private ActionType action;

    #endregion

    #region Reset

    //例。衝突した相手を破壊する。
    protected override void Reset()
    {
        tags = new List<Tag>
        {
            Tag.SpawnedObject
        };
        action = ActionType.Destroy;
    }

    #endregion

    #region Action

    //型の違った衝突情報をゲームオブジェクトに一致させる。
    private void CollideByTag(Collider target)
    {
        var tagUtility = new DelegateTag();
        tagUtility.ProcessByTag(target.gameObject, tags, action);
    }

    private void CollideByTag(Collision target)
    {
        CollideByTag(target.collider);
    }

    #endregion

    #region Collision

    private void OnCollisionEnter(Collision target)
    {
        CollideByTag(target);
    }

    private void OnTriggerEnter(Collider target)
    {
        CollideByTag(target);
    }

    private void OnCollisionStay(Collision target)
    {
        CollideByTag(target);
    }

    private void OnTriggerStay(Collider target)
    {
        CollideByTag(target);
    }

    private void OnCollisionExit(Collision target)
    {
        CollideByTag(target);
    }

    private void OnTriggerExit(Collider target)
    {
        CollideByTag(target);
    }

    #endregion
}