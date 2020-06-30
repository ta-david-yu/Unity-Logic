using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    /// <summary>
    /// VarReferenceBase is the base class for a reference representation to a Variable (IVar)
    /// </summary>
    public interface IVarReference
    {
        IVar GetVar();
        IVar SetVar(IValueType valueType);
    }

    [System.Serializable]
    public class LocalVarReference : IVarReference
    {
        [SerializeField]
        private LocalVarTable m_LocalTable;

        [SerializeField]
        private string m_TargetKey;

        public IVar GetVar()
        {
            throw new System.NotImplementedException();
        }

        public IVar SetVar(IValueType valueType)
        {
            throw new System.NotImplementedException();
        }
    }

    [System.Serializable]
    public class GlobalVarReference : IVarReference
    {
        [SerializeField]
        private LocalVarTable m_LocalTable;

        [SerializeField]
        private string m_TargetKey;

        public IVar GetVar()
        {
            throw new System.NotImplementedException();
        }

        public IVar SetVar(IValueType valueType)
        {
            throw new System.NotImplementedException();
        }
    }
}
