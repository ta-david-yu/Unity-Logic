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

    public interface IValueType<T> : IValueType
    {
        T Value
        {
            get;
            set;
        }
    }
}
