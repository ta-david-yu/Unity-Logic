using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [System.Serializable]
    public struct String : IValueType<string>
    {
        [SerializeField]
        private string m_Value;
        public string Value { get { return m_Value; } set { m_Value = value; } }

        public String(string value)
        {
            m_Value = value;
        }

        public object Get()
        {
            return Value;
        }

        public static implicit operator string(String str) => str.Value;
        public static explicit operator String(string str) => new String(str);
    }
}
