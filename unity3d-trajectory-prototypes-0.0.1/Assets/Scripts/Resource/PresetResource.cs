#region MIT License

// PresetResource.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/07 14:26
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
using UnityEngine;
using System.Collections.Generic;
using KeigunGi.General;
using Object = UnityEngine.Object;

#endregion

/// <summary>
/// リソース利用設定のコンポーネントのベースクラス
/// </summary>
public class PresetResource : ResetableBehaviour
{
    #region ResetItem

    #endregion

    #region Serialize

    [SerializeField]
    protected ResourceModeSelector mode;

    [SerializeField]
    protected ResourcePathLoader path;

    #endregion

    #region Property

    public virtual ResourcePathLoader Path
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

    public virtual ResourceModeSelector Mode
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

    protected override void Reset()
    {
        Mode = new ResourceModeSelector();
    }

    #endregion

    #region Method

    public virtual List<T> GetResource<T>(List<T> resource) where T: Object
    {
        return Mode.GetResource(resource, Path);
    }

    #endregion
}