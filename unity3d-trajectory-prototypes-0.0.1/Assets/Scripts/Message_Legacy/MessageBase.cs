#region MIT License

// MessageBase.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/03 16:33
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
using System.Reflection;
using KeigunGi.General;

#endregion

namespace KeigunGi.Message
{
    /// <summary>
    /// 自作CSharpバージョンSendMessage機能のベースクラス
    /// </summary>
    public class MessageBase
    {
        /// <summary>
        /// Sendの一連オーバーロードの最終バージョン。
        /// SendMessageの上位互換。一つのインスタンスに狙うと、複数のパラメーターを利用可能。
        /// MonoBehaviourに限らず、どんなクラスも対応。
        /// </summary>
        protected virtual object Send
            (object instane, Type type, string method,
             params object[] parameters)
        {
            return type.InvokeMember
                (method,
                 BindingFlags.InvokeMethod | BindingFlags.Public
                 | BindingFlags.NonPublic, null, instane, parameters);
        }

        /// <summary>
        /// Sendメソッド。string -> Type転換用バージョン。
        /// </summary>
        protected virtual object Send
            (object instane, string className, string method,
             params object[] parameters)
        {
            var classType = Type.GetType(className);
            return Send(instane, classType, method, parameters);
        }

        /// <summary>
        /// Sendメソッド。パラメーター圧縮バージョン。
        /// </summary>
        protected virtual object Send
            (MessageTarget target, params object[] parameters)
        {
            return Send
                (target.Instance, target.className, target.method, parameters);
        }
    }
}