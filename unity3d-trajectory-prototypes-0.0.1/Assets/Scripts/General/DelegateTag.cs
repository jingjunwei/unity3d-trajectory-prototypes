#region MIT License

// DelegateTag.cs
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
using System;
using System.Collections.Generic;
using KeigunGi.Example;
using Object = UnityEngine.Object;

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// タグを判断して異なる処理をするクラス
    /// タグが合ってればそのタグの持ち主を指定した対応を取る
    /// </summary>
    public class DelegateTag : TagBase
    {
        #region Public

        /// <summary>
        /// 枚挙型でタグとデリゲート情報を読み出して本番の処理に移行
        /// </summary>
        public virtual void ProcessByTag
            (GameObject target, List<Tag> tags, ActionType action)
        {
            ProcessByTag
                (target, EnumUtility.GetNames(tags),
                 DelegateLibrary.GetAction(action));
        }

        #endregion

        #region Protected

        /// <summary>
        /// //単体バージョン。タグが標的だった場合、
        /// そのゲームオブジェクトをActionで処理
        /// </summary>
        protected virtual void ProcessByTag
            (GameObject target, string tag, Action<Object> action)
        {
            var isAction = target.CompareTag(tag);
            if(isAction)
            {
                action(target);
            }
        }

        /// <summary>
        /// リストから一つずつ単体処理。
        /// </summary>
        protected virtual void ProcessByTag
            (GameObject target, List<string> tags, Action<Object> action)
        {
            tags.ForEach(tag => ProcessByTag(target, tag, action));
        }

        #endregion
    }
}