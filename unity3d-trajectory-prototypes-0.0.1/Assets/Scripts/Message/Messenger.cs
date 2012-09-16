#region MIT License

// Messenger.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/11 14:42
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
using KeigunGi.General;
using KeigunGi.Message;
using ObjectMode = KeigunGi.General.ObjectSelector.ObjectMode;

#endregion

public abstract class Messenger : UtilityBehaviour
{
    #region  EnumName

    private enum EnumNames
    {
        ObjectTarget,
        Target,
        Method
    }

    #endregion

    #region  Serialize

    [SerializeField]
    protected List<ObjectSelector> objects;

    [SerializeField]
    protected List<InstanceSelector> targets;

    [SerializeField]
    protected List<MethodCacher> methods;

    #endregion

    #region  Field

    private int objectLength;

    #endregion

    #region  Property

    protected virtual int ObjectLength
    {
        get
        {
            return objectLength;
        }
        set
        {
            objectLength = value;
        }
    }

    protected virtual int TargetLength
    {
        get;
        set;
    }

    protected virtual int MethodLength
    {
        get;
        set;
    }

    protected virtual List<MethodCacher> Methods
    {
        get
        {
            return methods;
        }
        set
        {
            methods = value;
        }
    }

    protected virtual List<string> MethodNames
    {
        get
        {
            return GetNames(MethodEnum);
        }
    }

    protected virtual List<InstanceSelector> Targets
    {
        get
        {
            return targets;
        }
        set
        {
            targets = value;
        }
    }

    protected virtual List<ObjectSelector> Objects
    {
        get
        {
            return objects;
        }
        set
        {
            objects = value;
        }
    }

    /// <summary>
    /// 規定値でモード
    /// </summary>
    protected virtual List<ObjectMode> ObjectModes
    {
        get
        {
            return Fill(ObjectMode.FindName, objectLength);
        }
    }

    protected virtual List<string> ObjectNames
    {
        get
        {
            return EnumUtility.GetNames(ObjectEnum);
        }
    }

    #endregion

    #region  Abstract

    protected abstract List<Type[]> ParameterTypes
    {
        get;
    }

    protected abstract List<GameObject> TargetObjects
    {
        get;
    }

    protected abstract List<string> TargetNames
    {
        get;
    }

    #endregion

    #region  Load

    protected virtual void Awake()
    {
        LoadMethods();
    }

    #endregion

    #region  Reset

    /// <summary>
    /// 自動的に枚挙で定義したタイプをゲット
    /// </summary>
    protected virtual void Reset()
    {
        var types = new List<Type>
        {
            ObjectEnum,
            MethodEnum
        };

        Reset(types);
    }

    /// <summary>
    /// 規定値にリセット
    /// TargetLengthを使わない。代わりに、MethodLengthを使う
    /// </summary>
    private void Reset(List<Type> enums)
    {
        ObjectLength = GetLength(enums[0]);
        TargetLength = GetLength(enums[1]);
        MethodLength = GetLength(enums[1]);

        InitObjects();
        InitTargets();
        InitMethods();
    }

    #endregion

    #region  Init Load

    protected void InitObjects()
    {
        var length = ObjectLength;
        Objects = new List<ObjectSelector>(length);

        For
            (length, (i) =>
            {
                var newSelector = new ObjectSelector
                    (ObjectModes[i], ObjectNames[i]);
                Objects.Add(newSelector);
            });
    }

    protected void InitTargets()
    {
        int length = TargetLength;
        Targets = new List<InstanceSelector>(length);

        For
            (length, (i) =>
            {
                var newSelector = new InstanceSelector
                    (TargetObjects[i], TargetNames[i]);
                Targets.Add(newSelector);
            });
    }

    protected void InitMethods()
    {
        int length = MethodLength;
        Methods = new List<MethodCacher>(length);

        For
            (length, (i) =>
            {
                var newCacher = new MethodCacher
                    (MethodNames[i], ParameterTypes[i]);
                Methods.Add(newCacher);
            });
    }

    /// <summary>
    /// メソッド情報を読み取る
    /// </summary>
    private void LoadMethods()
    {
        var i = 0;
        Targets.ForEach
            ((target) =>
            {
                Methods[i].GetInfo(target.TargetSelected);
                i++;
            });
    }

    #endregion

    #region  Get

    /// <summary>
    /// 枚挙で標的オブジェクトをゲット
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected virtual GameObject GetObject(Enum target)
    {
        return GetById(Objects, target).ObjectSelected;
    }

    protected virtual object GetTarget(Enum target)
    {
        return GetById(Targets, target).TargetSelected;
    }

    protected virtual MethodCacher GetMethod(Enum target)
    {
        return GetById(Methods, target);
    }

    #endregion

    #region EnumType

    private Type ObjectEnum
    {
        get
        {
            var type = GetEnumType(this, EnumNames.ObjectTarget);
            return type;
        }
    }

    private Type TargetEnum
    {
        get
        {
            var type = GetEnumType(this, EnumNames.Target);
            return type;
        }
    }

    private Type MethodEnum
    {
        get
        {
            var type = GetEnumType(this, EnumNames.Method);
            return type;
        }
    }

    #endregion
}