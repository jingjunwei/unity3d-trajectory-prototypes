#region MIT License

// ResourcePathLoader.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 9:33
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
    /// ResourcePathの情報でリソースをロードするクラス
    /// </summary>
    [Serializable]
    public class ResourcePathLoader : ResourceBase
    {
        #region Path

        [SerializeField]
        protected ResourcePath path;

        public virtual ResourcePath Path
        {
            get
            {
                return path;
            }
            protected set
            {
                path = value;
            }
        }

        #endregion

        #region Public

        public ResourcePathLoader(string directory, params string[] strings)
        {
            var fileList = new List<string>(strings);
            path = new ResourcePath(directory, fileList);
        }

        #region Save

        /// <summary>
        /// 設定したリソースをロード
        /// パラメーター分解チェイン 無 -> resourcePath -> directory & fileNames
        /// </summary>
        public virtual List<T> Reload<T>() where T: Object
        {
            return Reload<T>(Path);
        }

        #endregion

        public virtual List<T> Reload<T>(ResourcePath resourcePath)
            where T: Object
        {
            var loadedResrouces = new List<T>();

            var length = resourcePath.Length;
            var isHaveResources = length > 0;
            if(!isHaveResources)
            {
#if UNITY_EDITOR
                DebugUtility.LogError("Resources Load Failed: No Resrouces");
#endif
            }
            else
            {
                loadedResrouces = Reload<T>
                    (resourcePath.Directory, resourcePath.FileNames);
            }

            return loadedResrouces;
        }

        public virtual List<T> Reload<T>
            (string directory, List<string> fileNames) where T: Object
        {
            var loadedResrouces = new List<T>();

            fileNames.ForEach
                ((fileName) =>
                {
                    var resourcePath = directory + fileName;
                    var loadedResrouce = Load<T>(resourcePath);
                    loadedResrouces.Add(loadedResrouce);
                });

            return loadedResrouces;
        }

        #endregion
    }
}