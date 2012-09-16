#region MIT License

// ObjectSelector.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/11 4:33
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

#endregion

namespace KeigunGi.General
{
    [Serializable]
    public class ObjectSelector
    {
        #region Mode

        // TODO ADD: Find All
        // Begin at: 2012/9/9 8:34:27

        /// <summary>
        /// FindName: ゲームオブジェクト名で探し出す
        /// Specify :インスペクターで標的クラスを指定
        /// </summary>
        public enum ObjectMode
        {
            FindName,
            FindTag,
            //            FindNameAll,
            //            FindTagAll,
            Specify
        }

        [SerializeField]
        protected ObjectMode mode;

        protected virtual ObjectMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }

        #endregion

        #region Target

        [SerializeField]
        protected string targetNameOrTag;

        [SerializeField]
        protected GameObject objectSerialized;

        #endregion

        #region Property

        protected virtual string TargetNameOrTag
        {
            get
            {
                return targetNameOrTag;
            }
            set
            {
                targetNameOrTag = value;
            }
        }

        /// <summary>
        /// シリアライズ値の更新や読み取りに多使われているだけ
        /// </summary>
        protected virtual GameObject ObjectSerialized
        {
            get
            {
                return objectSerialized;
            }
            set
            {
                objectSerialized = value;
            }
        }

        /// <summary>
        /// モード設定に影響され、公開で使われている値
        /// </summary>
        public virtual GameObject ObjectSelected
        {
            get
            {
                GameObject target = default(GameObject);

                switch(Mode)
                {
                    case ObjectMode.Specify:

                        target = ObjectSerialized;
                        break;

                        // 標的オブジェクト探し出す
                    case ObjectMode.FindName:
                    case ObjectMode.FindTag:
                        var findedOjbect = FindObject(Mode, TargetNameOrTag);
                        target = findedOjbect;
                        break;

                    default:
#if UNITY_EDITOR
                        ExceptionUtility.SwitchDefault();
#endif
                        break;
                }

#if UNITY_EDITOR
                ExceptionUtility.IsNull(target);
#endif
                return target;
            }
        }

        #endregion

        #region Reset

        public ObjectSelector()
        {
            mode = ObjectMode.Specify;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initMode">同じくストリングefあるタグとネームを区別させるため、タイプを指定</param>
        /// <param name="stringValue"></param>
        public ObjectSelector(ObjectMode initMode, string stringValue)
        {
            switch(initMode)
            {
                case ObjectMode.FindName:
                case ObjectMode.FindTag:
                    //                case ObjectMode.FindTagAll:
                    mode = initMode;
                    targetNameOrTag = stringValue;
                    Save();
                    break;

                default:
#if UNITY_EDITOR
                    ExceptionUtility.SwitchDefault();
#endif
                    break;
            }
        }

        #endregion

        #region Method

        protected void Save()
        {
            ObjectSerialized = ObjectSelected;
        }

        protected GameObject FindObject(ObjectMode findMode, string stringValue)
        {
            var findedObject = default(GameObject);

            switch(findMode)
            {
                case ObjectMode.FindName:
                    findedObject = GameObject.Find(stringValue);
                    break;

                case ObjectMode.FindTag:
                    findedObject = GameObject.FindWithTag(stringValue);
                    break;

                default:
#if UNITY_EDITOR
                    ExceptionUtility.SwitchDefault();
#endif
                    break;
            }

#if UNITY_EDITOR
            ExceptionUtility.IsNull(findedObject);
#endif

            return findedObject;
        }

        #endregion
    }
}