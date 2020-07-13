using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/ValueNode/GetIntVar")]
    public class GetIntVarNode : ValueNode<Integer>
    {
        [SerializeField]
        [DYLogic.FilterVarTableType(typeof(Integer))]
        private DYLogic.LocalVarReference m_LocalVarRef;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "Output")
            {
                return m_LocalVarRef.GetVar().Data;
            }

            return null;
        }

        private void Reset()
        {
            name = "Integer Variable";
        }
    }
}