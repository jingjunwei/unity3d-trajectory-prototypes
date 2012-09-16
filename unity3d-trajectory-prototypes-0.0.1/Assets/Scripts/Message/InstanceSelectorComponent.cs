#region MIT License

// InstanceSelectorComponent.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/10 15:02
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
using KeigunGi.General;
using KeigunGi.Message;

#endregion

/// <summary>
/// 指定クラスのインスタンスをゲット
/// </summary>
public class InstanceSelectorComponent : ExtendBehaviour
{
    #region Mode

    /// <summary>
    /// FindOnObject: インスペクターでゲームオブジェクトを指定、クラス名で探し出す
    /// Specify :インスペクターで標的クラスを指定
    /// </summary>
    protected enum InstanceMode
    {
        FindOnObject,
        Specify
    }

    [SerializeField]
    protected InstanceMode mode;

    protected virtual InstanceMode Mode
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
    protected MonoBehaviour behaviourSerialized;

    [SerializeField]
    protected string targetClass;

    // 標的オブジェクトがシリアライズされていないため、
    // 代わりにオブジェクトの選択者をシリアライズで覚えておく必要がある
    [SerializeField]
    protected PropertyAccessor targetObjectAccesor;

    //ここはシリアライズしない。他のルートでゲット。
    protected GameObject TargetObject
    {
        get
        {
            return targetObjectAccesor.Get<GameObject>();
        }
    }

    #endregion

    #region Public

    public object TargetSelected
    {
        get
        {
            var target = default(object);

            switch(Mode)
            {
                case InstanceMode.Specify:
                case InstanceMode.FindOnObject:
                    target = BehaviourSelected;
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

    #region Property

    protected MonoBehaviour BehaviourSerialized
    {
        get
        {
            return behaviourSerialized;
        }
        set
        {
            behaviourSerialized = value;
        }
    }

    protected MonoBehaviour BehaviourSelected
    {
        get
        {
            var target = default(MonoBehaviour);

            switch(Mode)
            {
                case InstanceMode.Specify:
                    target = BehaviourSerialized;
                    break;

                case InstanceMode.FindOnObject:
                    target =
                        TargetObject.GetComponent(targetClass) as MonoBehaviour;

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

    protected virtual void Reset()
    {
        mode = InstanceMode.Specify;
    }

    protected virtual void Reset
        (MonoBehaviour accessTarget, string accessMember, string initClassName)
    {
        mode = InstanceMode.FindOnObject;
        targetObjectAccesor = new PropertyAccessor(accessTarget, accessMember);
        targetClass = initClassName;

        Save();
    }

    #endregion

    #region  Method

    protected void Save()
    {
        BehaviourSerialized = BehaviourSelected;
    }

    #endregion
}