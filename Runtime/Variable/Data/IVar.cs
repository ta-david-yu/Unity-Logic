using System;
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
        IValueType Data { get; }

        void SetData(IValueType value);
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

        public void SetData(IValueType value)
        {
            // Do type checking
            if (Data?.GetType() != value.GetType())
            {
                throw new ArgumentException(
                    string.Format("Type mismatch when trying to assign '{0}' to Variable '{2}' of type '{1}'", 
                    value.GetType().Name, 
                    Data?.GetType().Name,
                    Key)
                    );
            }

            if (!m_Data.Get().Equals(value.Get()))
            {
                Events.OnDataValueChanged.Invoke(Data, value);
            }
            m_Data = value;
        }

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