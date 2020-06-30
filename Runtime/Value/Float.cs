using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [System.Serializable]
    public struct Float : ValueType<float>
    {
        [SerializeField]
        private float m_Value;
        public float Value { get { return m_Value; } set { m_Value = value; } }

        public Float(float value)
        {
            m_Value = value;
        }

        public object Get()
        {
            return Value;
        }

        public static implicit operator float(Float flt) => flt.Value;
        public static explicit operator Float(int flt) => new Float(flt);
    }
}