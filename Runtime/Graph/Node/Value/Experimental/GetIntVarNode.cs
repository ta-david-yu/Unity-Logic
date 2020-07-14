using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu(k_CreateNodeMenuNameRoot + "Experimental/Int Variable")]
    public class GetIntVarNode : ValueNode<Integer>
    {
        [SerializeField]
        [DYLogic.FilterVarTableType(typeof(Integer))]
        private DYLogic.LocalVarReference m_Ref;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Output))
            {
                return m_Ref.GetVar().Data;
            }

            return null;
        }

        private void Reset()
        {
            name = "Integer Variable";
        }
    }
}