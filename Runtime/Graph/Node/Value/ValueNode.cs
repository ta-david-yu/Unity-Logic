using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    public abstract class ValueNode : XNode.Node { }

    [NodeWidth(220)]
    [NodeTint("#e43f5a")]
    public abstract class ValueNode<T> : ValueNode where T : IValueType
    {
        [Output] public T Output;

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            // TODO: Check if Output and Input type are the same IValueType
            // From this.Output
            if (from.fieldName == nameof(Output))
            {
                //from.Disconnect
            }
        }
    }
}
