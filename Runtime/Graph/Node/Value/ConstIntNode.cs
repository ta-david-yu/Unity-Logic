using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/ValueNode/Int")]
    public class ConstIntNode : ValueNode<Integer>
    {
        public int Value;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "Output")
            {
                return Value;
            }

            return null;
        }

        private void Reset()
        {
            name = "Integer";
        }
    }
}