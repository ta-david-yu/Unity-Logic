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
        public string Key { get { return m_Key; } set { m_Key = value; } }

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
                    Events.OnDataValueChanged.Invoke(Data, value);
                }
                m_Data = value;
            }
        }

        [System.Serializable]
        public struct VarEvents
        {
            [System.Serializable]
            public class DataValueChangedEvent : UnityEvent<IValueType, IValueType> { }
            public DataValueChangedEvent OnDataValueChanged;
        }
        public VarEvents Events;


        private Var() { }

        public class Factory
        {
            public static Var Create(string key, IValueType data)
            {
                return new Var() { m_Key = key, m_Data = data };
            }

            public static Var Copy(Var variable)
            {
                return new Var() { m_Key = variable.Key, m_Data = variable.Data, Events = variable.Events };
            }
        }
    }
}