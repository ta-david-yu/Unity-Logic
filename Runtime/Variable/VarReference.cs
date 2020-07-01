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
        void SetVar(IValueType data);
    }

    [System.Serializable]
    public abstract class TableVarReferenceBase : IVarReference
    {
        public abstract IVarTable TargetTable { get; }

        [SerializeField]
        protected string m_TargetKey;

        public IVar GetVar()
        {
            return TargetTable.GetVar(m_TargetKey);
        }

        public void SetVar(IValueType data)
        {
            TargetTable.SetVar(m_TargetKey, data);
        }
    }

    [System.Serializable]
    public class LocalVarReference : TableVarReferenceBase
    {
        [SerializeField]
        private LocalVarTable m_TargetTable;

        public override IVarTable TargetTable => m_TargetTable;
    }

    [System.Serializable]
    public class GlobalVarReference : TableVarReferenceBase
    {
        [SerializeField]
        private GlobalVarTable m_TargetTable;

        public override IVarTable TargetTable => m_TargetTable;
    }

    // TODO
    [System.Serializable]
    public class GenericVarReference : IVarReference
    {
        public enum Scope
        {
            Local,
            Global
        }

        [SerializeField]
        private Scope m_TargetScope;

        [SerializeField]
        private LocalVarTable m_TargetLocalTable;

        [SerializeField]
        private GlobalVarTable m_TargetGlobalTable;

        public IVar GetVar()
        {
            throw new System.NotImplementedException();
        }

        public void SetVar(IValueType data)
        {
            throw new System.NotImplementedException();
        }
    }
}
