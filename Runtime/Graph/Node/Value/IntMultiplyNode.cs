using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/Value/IntMultiply")]
    public class IntMultiplyNode : ValueNode<Integer>
    {
        [Input] public Integer InputA;
        [Input] public Integer InputB;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == "Output")
            {
                return GetInputValue<Integer>(nameof(InputA)).Value * GetInputValue<Integer>(nameof(InputB)).Value;
            }

            return null;
        }

        private void Reset()
        {
            name = "IntMultiply";
        }
    }
}