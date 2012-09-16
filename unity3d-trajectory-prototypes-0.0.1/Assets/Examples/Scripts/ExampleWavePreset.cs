#region MIT License

// ExampleWavePreset.cs
// Author: Keigun Gi
// Mail: keigungi@yahoo.co.jp
// Blog: keigungi.hatenablog.com
// Last Modified: 2012/09/06 20:46
// Created: 2012/09/02 10:36
// 
// MIT License
// Copyright (c) 2012 Jing-Jun Wei
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using System;
using KeigunGi.General;
using KeigunGi.Message;

#endregion

namespace KeigunGi.Example
{
    [Serializable]
    public class ExampleWavePreset
    {
        public WaveControlMessage message;

        #region Property

        public WaveControlMessage Message
        {
            get
            {
                return message;
            }
        }

        #endregion

        public virtual void Reset()
        {
            Message.Reset();
        }
    }
}