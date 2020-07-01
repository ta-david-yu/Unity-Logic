using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FilterVarTableTypeAttribute : PropertyAttribute
    {
        public HashSet<Type> FilterTypes;

        public FilterVarTableTypeAttribute(params Type[] types)
        {
            FilterTypes = new HashSet<Type>(types);
        }
    }
}
