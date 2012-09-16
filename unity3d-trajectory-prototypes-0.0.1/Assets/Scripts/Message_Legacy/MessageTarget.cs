#region MIT License

// MessageTarget.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/04 12:56
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

#endregion

namespace KeigunGi.Message
{
    /// <summary>
    /// 発信情報を格納するクラス
    /// ターゲットのゲームオブジェクトを取り得る機能も搭載
    /// </summary>
    [Serializable]
    public class MessageTarget
    {
        #region Fields

        /// <summary>
        /// MonoBehaviour：インスペクターで直接指定
        /// FindName:：ゲームオブジェクト名で探し出す
        /// Instance：コードで何かのクラスのinstanceを指定
        /// </summary>
        public enum TargetMode
        {
            MonoBehaviour,
            FindName,
            Instance
        }

        public TargetMode mode;

        public string objectName;
        public GameObject objectTarget;
        public string className;

        [NonSerialized]
        public object instance;

        [NonSerialized]
        public string method;

        #endregion

        #region Reset

        /// <summary>
        /// 標的オブジェクト探し出す
        /// </summary>
        public virtual void Reset(TargetMode defaultMode)
        {
            mode = defaultMode;
            switch(mode)
            {
                case TargetMode.FindName:
                    objectTarget = TargetObject;
                    break;
                default:
                    break;
            }
        }

        public virtual void Reset()
        {
            Reset(TargetMode.FindName);
        }

        #endregion

        #region Properties

        public object Instance
        {
            get
            {
                var targetInstance = default(object);

                switch(mode)
                {
                    case TargetMode.MonoBehaviour:
                    case TargetMode.FindName:
                        targetInstance = TargetMonoBehaviour;
                        break;
                    case TargetMode.Instance:
                        if(instance == null)
                        {
#if UNITY_EDITOR
                            DebugUtility.LogError
                                ("instance is null on InstanceMode.Instance");
#endif
                        }
                        else
                        {
                            targetInstance = instance;
                        }
                        break;
                    default:
#if UNITY_EDITOR
                        DebugUtility.LogError
                            ("Instance failed on switch default");
#endif
                        break;
                }

                return targetInstance;
            }
        }

        public object TargetMonoBehaviour
        {
            get
            {
                var target = TargetObject.GetComponent(className);

#if UNITY_EDITOR
                if(!target)
                {
                    DebugUtility.LogError("Instance failed");
                }

#endif
                return target;
            }
        }

        public GameObject TargetObject
        {
            get
            {
                GameObject targetObject = default(GameObject);

                switch(mode)
                {
                    case TargetMode.MonoBehaviour:
                        if(objectTarget)
                        {
                            targetObject = objectTarget;
                        }
                        else
                        {
#if UNITY_EDITOR
                            DebugUtility.LogError
                                ("Failed at InstanceMode.MonoBehaviour");
#endif
                        }
                        break;
                    case TargetMode.FindName:

                        var findedOjbect = GameObject.Find(objectName);
                        if(findedOjbect)
                        {
                            targetObject = findedOjbect;
                        }
                        else
                        {
#if UNITY_EDITOR
                            DebugUtility.LogError("Failed at ObjectSerialized");
#endif
                        }
                        break;
                    default:
                    {
#if UNITY_EDITOR
                        DebugUtility.LogError
                            ("Failed at switch default ObjectSerialized");
#endif
                    }
                        break;
                }

                return targetObject;
            }
        }

        #endregion
    }
}