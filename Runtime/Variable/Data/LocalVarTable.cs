using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    /// <summary>
    /// Local Variables stores a table of Variable (Var) in the Monobehaviour, therefore the lifetime of the table is the same as the gameobject that it's attached to
    /// </summary>
    public class LocalVarTable : MonoBehaviour, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<Var> m_Vars = new List<Var>();

        public Dictionary<string, Var> Table = new Dictionary<string, Var>();

        public void OnBeforeSerialize()
        {
            m_Vars.Clear();

            foreach (var pair in Table)
            {
                m_Vars.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Table = new Dictionary<string, Var>();
            for (int i = 0; i < m_Vars.Count; i++)
            {
                var variable = m_Vars[i];
                if (Table.ContainsKey(variable.Key))
                {
                    var newKey = variable.Key + i.ToString();
                    Debug.LogWarningFormat("There is already a variable named \'{0}\' at index {1}, renamed it to \'{2}\'", variable.Key, i, newKey);
                    variable = Var.Factory.Create(newKey, variable.Data);
                }
                Table.Add(variable.Key, variable);
            }
        }
    }
}