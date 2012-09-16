#region MIT License

// MessageSender.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/04 6:51
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

namespace KeigunGi.Message
{
    /// <summary>
    /// Unity3Dの原SendMessageの不便なところを解決するため、
    /// 自作メーセージの発信原型クラス
    /// </summary>
    [Serializable]
    public class MessageSender : MessageBase
    {
        [SerializeField]
        protected MessageTarget target;

        #region Reset

        public virtual void Reset()
        {
            target.Reset();
        }

        /// <summary>
        /// 少し特別ですが、MessageSenderの派生クラスにResetをオーバーライドし必ず最後base.Reset()を呼ぶほうが無難です。
        /// 順番を強制させるのは、まず派生クラスでパラメータを指定しないと正しく利用できないためです。
        /// </summary>
        public virtual void Reset(params string[] parameters)
        {
            Reset();
        }

        #endregion

        #region Method

        public virtual object Send(string method, params object[] parameters)
        {
            target.method = method;
            return Send(target, parameters);
        }

        #endregion
    }
}