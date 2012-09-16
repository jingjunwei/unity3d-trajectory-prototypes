#region MIT License

// Counter.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/03 13:18
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

/// <summary>
/// ˜”¡©¤Ê¥«¥¦¥ó¥¿©`¤Î¥Ù©`¥¹¥¯¥é¥¹
/// </summary>
public class Counter : ResetableBehaviour
{
    protected int countTotal;

    #region Property

    public virtual int CountTotal
    {
        get
        {
            return countTotal;
        }
        protected set
        {
            countTotal = value;
        }
    }

    #endregion

    #region Method

    protected override void Reset()
    {
        CountTotal = 0;
    }

    public virtual void OnNextCountMessage()
    {
        Next();
    }

    protected virtual void Next()
    {
        countTotal++;
    }

    #endregion
}