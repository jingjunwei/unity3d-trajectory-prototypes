#region MIT License

// ResourceModeSelector.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 11:15
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
using Object = UnityEngine.Object;

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// リソースの取り得る方を制御するクラス
    /// 直接指定か、またはFindで探し出す
    /// </summary>
    [Serializable]
    public class ResourceModeSelector
    {
        #region ResourceMode

        public enum ResourceMode
        {
            Serialize,
            Load
        }

        [SerializeField]
        protected ResourceMode mode;

        public virtual ResourceMode Mode
        {
            get
            {
                return mode;
            }
            protected set
            {
                mode = value;
            }
        }

        #endregion

        #region Reset

        public ResourceModeSelector(ResourceMode initMode)
        {
            mode = initMode;
        }

        public ResourceModeSelector()
            : this(ResourceMode.Load)

        {
        }

        public virtual List<T> GetResource<T>
            (List<T> resourceList, ResourcePathLoader resourcePath)
            where T: Object
        {
            var resouces = new List<T>();
            switch(Mode)
            {
                case ResourceMode.Serialize:
                    resouces = resourceList;
                    break;
                case ResourceMode.Load:
                    resouces = resourcePath.Reload<T>();
                    break;
            }
            return resouces;
        }

        #endregion
    }
}