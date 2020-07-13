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
            // From this.Output
            if (from.fieldName == nameof(Output))
            {
                // fromType ---> toType
                var fromType = (from.GetOutputValue() as IValueType).Get().GetType();
                var toType = (to.GetInputValue() as IValueType).Get().GetType();

                bool isValidConnection = DYSerializer.ReflectionUtility.HasImplicitConversion(fromType, toType) || toType.IsAssignableFrom(fromType);

                if (!isValidConnection)
                {
                    Debug.LogWarning("Error Connection");
                    from.Disconnect(to);
                }
            }
        }
    }
}
