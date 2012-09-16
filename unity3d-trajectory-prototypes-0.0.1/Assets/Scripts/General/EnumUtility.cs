#region MIT License

// EnumUtility.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/02 10:36
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

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// System.Enumの拡張
    /// </summary>
    public class EnumUtility
    {
        public static Type GetType(string fullName)
        {
            var type = Type.GetType(fullName);
            return type;
        }

        /// <summary>
        /// 指定クラスの枚挙型のタイプをゲット
        /// </summary>
        /// <param name="classInstance">指定クラスのインスタンス</param>
        /// <param name="enumElement">枚挙型の名前を格納した枚挙</param>
        /// <returns></returns>
        public static Type GetInnerEnumType
            (object classInstance, Enum enumElement)
        {
            var enumName = GetName(enumElement);
            var instanceType = classInstance.GetType();
            var classType = instanceType.BaseType;
            var type = GetInnerEnumType(classType, enumName);
            return type;
        }

        private static Type GetInnerEnumType(Type classType, string enumName)
        {
            var thisName = classType.Name;
            var fullName = String.Format("{0}+{1}", thisName, enumName);
            var type = GetType(fullName);
            return type;
        }

        /// <summary>
        /// 枚挙型のID番号ゲット
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetId(Enum target)
        {
            var id = -1;
            var type = target.GetType();
            var names = Enum.GetNames(type);
            var name = Enum.GetName(type, target);

            var namesList = new List<string>(names);
            id = namesList.IndexOf(name);

            return id;
        }

        /// <summary>
        /// 枚挙型の長さをゲット
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetLength<T>()
        {
            return GetLength(typeof(T));
        }

        public static int GetLength(Type enumType)
        {
            var names = Enum.GetNames(enumType);
            var length = names.Length;
            return length;
        }

        /// <summary>
        /// 枚挙からストリングに転換
        /// </summary>
        /// <typeparam name="T">枚挙のタイプ名</typeparam>
        /// <param name="type">枚挙</param>
        /// <returns>転換した後のストリング</returns>
        public static string GetName<T>(T type)
        {
            return Enum.GetName(typeof(T), type);
        }

        public static string GetName(Enum enumElement)
        {
            var enumType = enumElement.GetType();
            var enumName = Enum.GetName(enumType, enumElement);
            return enumName;
        }

        public static List<string> GetNames<T>()
        {
            return GetNames(typeof(T));
        }

        public static List<string> GetNames(Type enumType)
        {
            return new List<string>(Enum.GetNames(enumType));
        }

        /// <summary>
        /// 枚挙リストから文字列リストに変換
        /// </summary>
        public static List<string> GetNames<T>(List<T> enums)
        {
            var names = new List<string>();
            enums.ForEach(type => names.Add(GetName(type)));
            return names;
        }

        /// <summary>
        /// 指定リストから枚挙の番号が代表する値を取り出す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static T GetById<T>(List<T> list, Enum method)
        {
            var id = GetId(method);

            return list[id];
        }
    }
}