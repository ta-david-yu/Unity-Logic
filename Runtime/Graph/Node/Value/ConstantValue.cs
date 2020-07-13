using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/Value/Constant")]
    public class ConstantValue : ValueNode<IValueType>
    {
        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        public IValueType Constant;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == nameof(Output))
            {
                return Constant;
            }
            else
            {
                return null;
            }
        }

        private void Reset()
        {
            name = "Constant";
        }
    }
}