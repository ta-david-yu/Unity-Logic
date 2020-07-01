using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [CreateAssetMenu(fileName ="GlobalVarTable", menuName = "DYLogic/GlobalVarTable")]
    public class GlobalVarTable : ScriptableObject, IVarTable, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<Var> m_Vars = new List<Var>();
        public IEnumerable<IVar> Vars { get { return m_Vars; } }

        private Dictionary<string, Var> m_Table = new Dictionary<string, Var>();

        public Var GetVar(string key)
        {
            return m_Table[key];
        }

        public void SetVar(string key, IValueType data)
        {
            throw new System.NotImplementedException();
        }

        public void AddVar(string key, Type type)
        {
            m_Table.Add(key, Var.Factory.Create(key, Activator.CreateInstance(type) as IValueType));
            //m_Vars.Add(Var.Factory.Create(key, Activator.CreateInstance(type) as IValueType));
        }

        public void OnBeforeSerialize()
        {
            m_Vars.Clear();

            foreach (var pair in m_Table)
            {
                m_Vars.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            m_Table = new Dictionary<string, Var>();
            for (int i = 0; i < m_Vars.Count; i++)
            {
                var variable = m_Vars[i];
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