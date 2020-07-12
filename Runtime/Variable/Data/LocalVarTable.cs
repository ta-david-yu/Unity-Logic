using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    /// <summary>
    /// Local Variables stores a table of Variable (Var) in the Monobehaviour, therefore the lifetime of the table is the same as the gameobject that it's attached to
    /// </summary>
    public class LocalVarTable : MonoBehaviour, IVarTable, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<Var> m_Variables = new List<Var>();
        public IEnumerable<IVar> Variables { get { return m_Variables; } }

        private Dictionary<string, Var> m_Table = new Dictionary<string, Var>();

        public Var GetVar(string key)
        {
            return m_Table[key];
        }

        public void SetVar(string key, IValueType data)
        {
            m_Table[key].SetData(data);
        }

        public void AddVar(string key, Type type)
        {
            m_Table.Add(key, Var.Factory.Create(key, Activator.CreateInstance(type) as IValueType));
            //m_Vars.Add(Var.Factory.Create(key, Activator.CreateInstance(type) as IValueType));
        }

        public void OnBeforeSerialize()
        {
            m_Variables.Clear();

            foreach (var pair in m_Table)
            {
                m_Variables.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            m_Table = new Dictionary<string, Var>();
            for (int i = 0; i < m_Variables.Count; i++)
            {
                var variable = m_Variables[i];
                if (m_Table.ContainsKey(variable.Key))
                {
                    var newKey = variable.Key + i.ToString();
                    Debug.LogWarningFormat("There is already a variable named \'{0}\' at index {1}, renamed it to \'{2}\'", variable.Key, i, newKey);

                    variable.Key = newKey;
                }
                m_Table.Add(variable.Key, variable);
            }
        }
    }
}