#region MIT License

// ResourcePath.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/05 8:35
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
using UnityEngine;

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// リソースをLoadする際のpath情報を格納するクラス
    /// 一つのディレクトリに複数のファイル名対応可能
    /// </summary>
    [Serializable]
    public class ResourcePath
    {
        #region Serialize

        [SerializeField]
        protected string directory;

        [SerializeField]
        protected List<string> fileNames;

        #endregion

        #region Property

        public int Length
        {
            get
            {
                return fileNames.Count;
            }
        }

        public string Directory
        {
            get
            {
                return directory;
            }
            protected set
            {
                directory = value;
            }
        }

        public List<string> FileNames
        {
            get
            {
                return fileNames;
            }
            protected set
            {
                fileNames = value;
            }
        }

        #endregion

        #region Constructor

        public ResourcePath(string directory, List<string> fileNames)
        {
            Directory = directory;
            FileNames = fileNames;
        }

        #endregion
    }
}