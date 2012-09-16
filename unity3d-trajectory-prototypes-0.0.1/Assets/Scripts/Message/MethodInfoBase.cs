#region MIT License

// MethodInfoBase.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/10 19:13
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
    public class MethodInfoBase
    {
        #region  MethodInfo

        public static MethodInfo GetInfo
            (object instance, string method, Type[] parameterTypes)
        {
            var methodInfo = default(MethodInfo);
            var type = instance.GetType();
            methodInfo = type.GetMethod(method, parameterTypes);

#if UNITY_EDITOR
            var log = String.Format("Method Not Found: {0}", method);
            ExceptionUtility.IsNull(methodInfo, log);
#endif

            return methodInfo;
        }

        public static bool GetInfo
            (object instance, string method, Type[] parameterTypes,
             out MethodInfo methodInfo)
        {
            methodInfo = GetInfo(instance, method, parameterTypes);

            var isFailed = ExceptionUtility.IsNull(methodInfo);
            if(isFailed)
            {
#if UNITY_EDITOR
                ExceptionUtility.NotFound(method, instance.GetType().Name);
#endif
            }

            return isFailed;
        }

        #endregion

        #region  Send

        /// <summary>
        /// SendMessageの上位互換。一つのインスタンスに狙うと、
        /// 複数のパラメーターを利用可能。
        /// MonoBehaviourに限らず、どんなクラスも対応。
        /// </summary>
        public static object Invoke
            (object instance, MethodInfo methodInfo, params object[] parameters)
        {
            var retuanValue = default(object);
            var isNull = false;

#if UNITY_EDITOR
            //TODO EXCEPTION
            //            ExceptionInfo.Null()

            isNull = ExceptionUtility.IsNull(instance)
                     || ExceptionUtility.IsNull(methodInfo);
#endif

            if(!isNull)
            {
                retuanValue = methodInfo.Invoke(instance, parameters);
            }
#if UNITY_EDITOR
            else
            {
                var log = "Invoke Failed";
                DebugUtility.LogError(log);
            }
#endif

            return retuanValue;
        }

        #endregion
    }
}