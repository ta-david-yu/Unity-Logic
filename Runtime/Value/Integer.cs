using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [System.Serializable]
    public struct Integer : ValueType<int> //, IEquatable<Integer>, IComparable, IComparable<Integer>
    {
        [SerializeField]
        private int m_Value;
        public int Value { get { return m_Value; } set { m_Value = value; } }

        public Integer(int value)
        {
            m_Value = value;
        }

        public object Get()
        {
            return Value;
        }

        public static implicit operator int(Integer integer) => integer.Value;
        public static explicit operator Integer(int integer) => new Integer(integer);


        /*
        public bool Equals(Integer other)
        {
            return Value.Equals(other.Value);
        }

        public int CompareTo(Integer other)
        {
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                return (obj is Integer) ? CompareTo((Integer) obj) : 1;
            }
            else
            {
                return 1;
            }
        }
        */
    }
}