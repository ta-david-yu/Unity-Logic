using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DYLogic
{
    /// <summary>
    /// IVariable: an interface for variable data, containing a key (name) and a data (IValueType value)
    /// </summary>
    public interface IVar
    {
        string Key { get; }
        IValueType Data { get; set; }
    }

    [System.Serializable]
    public class Var : IVar
    {
        [SerializeField]
        private string m_Key = "Variable";
        public string Key { get { return m_Key; } private set { m_Key = value; } }

        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        private IValueType m_Data;
        public IValueType Data
        {
            get { return m_Data; }
            set
            {
                if (m_Data != value)
                {
                    OnDataValueChanged.Invoke(Data, value);
                }
                m_Data = value;
            }
        }

        private Var(string key, IValueType data)
        {
            m_Key = key;
            m_Data = data;
        }

        public UnityEvent<IValueType, IValueType> OnDataValueChanged;

        public class Factory
        {
            public static Var Create(string key, IValueType data)
            {
                return new Var(key, data);
            }

            public static Var Copy(Var variable)
            {
                return new Var(variable.Key, variable.Data);
            }
        }
    }
}