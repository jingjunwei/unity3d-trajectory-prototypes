#region MIT License

// MethodCacher.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/10 18:44
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KeigunGi.General;
using UnityEngine;

#endregion

namespace KeigunGi.Message
{
    /// <summary>
    /// 一旦ターゲットを見つかったら、呼び出し情報をセーブする
    /// </summary>
    [Serializable]
    public class MethodCacher : MethodInfoBase
    {
        #region  Field

        [SerializeField]
        protected string methodName;

        [SerializeField]
        protected List<string> parameterTypeNames;

        /// <summary>
        /// 一度だけセーブする
        /// </summary>
        protected Type[] parameterTypes;

        protected MethodInfo methodCache;
        protected object target;

        #endregion

        #region  Property

        protected virtual string MethodName
        {
            get
            {
                return methodName;
            }
            set
            {
                methodName = value;
            }
        }

        protected virtual List<string> ParameterTypeNames
        {
            get
            {
                return parameterTypeNames;
            }
            set
            {
                parameterTypeNames = value;
            }
        }

        protected virtual Type[] ParameterTypes
        {
            get
            {
                var types = Type.EmptyTypes;

                var valid = Collection.IsValid(ParameterTypeNames);
                if(valid)
                {
                    types = Collection.GetTypes(ParameterTypeNames);
                }

                return types;
            }
            set
            {
                ParameterTypeNames = Collection.SetTypes(value);
            }
        }

        protected virtual MethodInfo MethodCache
        {
            get
            {
                return methodCache;
            }
            set
            {
                methodCache = value;
            }
        }

        protected virtual object Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
            }
        }

        #endregion

        #region Constructor

        public MethodCacher(string method, Type[] types)
        {
            methodName = method;
            parameterTypeNames = Collection.SetTypes(types);
        }

        public virtual void GetInfo(object instance)
        {
            Target = instance;
            MethodCache = GetInfo(instance, MethodName, ParameterTypes);
        }

        #endregion

        #region Send

        public virtual object Send(params object[] parameters)
        {
            var retuanValue = Invoke(Target, MethodCache, parameters);

            return retuanValue;
        }

        #endregion
    }
}