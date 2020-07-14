using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu(k_CreateNodeMenuNameRoot + "Experimental/Int")]
    public class IntNode : ValueNode<Integer>
    {
        public int Value;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "Output")
            {
                return new Integer(Value);
            }

            return null;
        }

        private void Reset()
        {
            name = "Integer";
        }
    }
}