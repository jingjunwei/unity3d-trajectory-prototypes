#region MIT License

// CollectionUtility.cs
// Version: 0.01
// Last Modified: 2012/09/16 15:59
// Created: 2012/09/07 6:53
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
using System.Linq;

#endregion

namespace KeigunGi.General
{
    /// <summary>
    /// コレクション処理用ツールクラス
    /// </summary>
    public static class Collection
    {
        /// <summary>
        /// 指定した値と値の数で充填したリストを返す
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static List<T> Fill<T>(T value, int length)
        {
            var filledList = new List<T>();

            for(var i = length; i > 0; i--)
            {
                filledList.Add(value);
            }
            return filledList;
        }

        /// <summary>
        /// 文字列は値があるかどうかをチェック
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static bool IsValid(IEnumerable<string> strings)
        {
            var isNullOrEmpty = true;
            var hasCount = strings.Any();
            if(hasCount)
            {
                var invalidList = from checker in strings
                                  where String.IsNullOrEmpty(checker)
                                  select checker;
                isNullOrEmpty = invalidList.Any();
            }
            var valid = hasCount && !isNullOrEmpty;
            return valid;
        }

        /// <summary>
        /// Type数列を文字列に変換
        /// </summary>
        /// <param name="typeNames"></param>
        /// <returns></returns>
        public static List<string> SetTypes(Type[] types)
        {
            var typeList = from type in types
                           select type.AssemblyQualifiedName;
            var names = typeList.ToList();
            return names;
        }

        /// <summary>
        /// 文字列をType数列に変換
        /// </summary>
        /// <param name="typeNames"></param>
        /// <returns></returns>
        public static Type[] GetTypes(List<string> typeNames)
        {
            //            var typeList = from typeName in typeNames
            //                           select Type.GetType(typeName);
            var typeList = new List<Type>();
            typeNames.ForEach
                ((name) =>
                {
                    var type = Type.GetType(name);
                    typeList.Add(type);
                });

            var types = typeList.ToArray();
            return types;
        }

        /// <summary>
        /// リストで指定番号の値を消して返す
        /// </summary>
        public static T RemoveValueAt<T>(List<T> list, int id)
        {
            var value = list[id];
            list.RemoveAt(id);
            return value;
        }

        /// <summary>
        /// リストの最初の値を取り出す
        /// </summary>
        public static T GetSingle<T>(List<T> list)
        {
            var singleValue = default(T);
            if(list.Count > 0)
            {
                singleValue = list[0];
            }
            return singleValue;
        }

        /// <summary>
        /// 値は有効かどうかを判断
        /// </summary>
        /// <typeparam name="T">型違いじゃだめ</typeparam>
        /// <param name="value">null値じゃだめ</param>
        public static bool IsValid<T>(object value)
        {
            var isEqual = false;
            var isValue = value != default(object);
            if(isValue)
            {
                var valueType = value.GetType();
                isEqual = valueType == typeof(T);
            }
            var valid = isEqual && isValue;
            return valid;
        }

        /// <summary>
        /// リストのリストを一つのリストに纏める
        /// </summary>
        public static List<T> MergeList2d<T>(List<List<T>> list2d)
        {
            var mergedList = new List<T>();

            bool isMerge = list2d.Count > 0;
            if(isMerge)
            {
                list2d.ForEach(mergedList.AddRange);
            }
            else
            {
#if UNITY_EDITOR
                if(DebugUtility.ShowError)
                {
                    DebugUtility.LogError("MergeList2d Nothing!");
                }
#endif
            }
            return mergedList;
        }
    }
}