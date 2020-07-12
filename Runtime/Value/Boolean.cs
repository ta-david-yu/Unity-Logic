using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [System.Serializable]
    public struct Boolean : IValueType<bool>
    {
        [SerializeField]
        private bool m_Value;
        public bool Value { get { return m_Value; } set { m_Value = value; } }

        public Boolean(bool value)
        {
            m_Value = value;
        }

        public object Get()
        {
            return Value;
        }

        public static implicit operator bool(Boolean boolean) => boolean.Value;
        public static explicit operator Boolean(bool boolean) => new Boolean(boolean);
    }
}