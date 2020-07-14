using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    /// <summary>
    /// The interface for ValueType, this should only be used for implementation
    /// </summary>
    public interface IValueType
    {
        object Get();
    }

    /// <summary>
    /// The interface for ValueType, any generic value or new value should be implemented from this IValueType<T>
    /// </summary>
    /// <typeparam name="T">The fallback Type</typeparam>
    public interface IValueType<T> : IValueType
    {
        T Value
        {
            get;
            set;
        }
    }
}
