#region MIT License

// AccessBase.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/10 12:58
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

using System.Reflection;

#endregion

namespace KeigunGi.Message
{
    public class AccessBase
    {
        #region InvokeMember

        //GetProperty
        protected virtual TReturn GetProperty<TReturn>
            (object instance, string invokeName)
        {
            return InvokeMember<TReturn>
                (instance, invokeName, BindingFlags.GetProperty);
        }

        protected virtual TReturn InvokeMember<TReturn>
            (object instance, string invokeName, BindingFlags partialFlags,
             params object[] parameters)
        {
            var type = instance.GetType();
            var invokeFlags = partialFlags | BindingFlags.Public;
            var returnValue = type.InvokeMember
                (invokeName, invokeFlags, null, instance, parameters);
            return (TReturn)returnValue;
        }

        #endregion
    }
}