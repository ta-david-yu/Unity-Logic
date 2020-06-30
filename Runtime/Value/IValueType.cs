using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    public interface IValueType
    {
        object Get();
    }

    public interface ValueType<T> : IValueType
    {
        T Value
        {
            get;
            set;
        }
    }
}
