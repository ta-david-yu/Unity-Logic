using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    /// <summary>
    /// ValueNode is the abstract base class for Value Provider, it should always have only one Output port, which is of type IValueType
    /// </summary>
    [NodeWidth(220)]
    [NodeTint("#e43f5a")]
    public abstract class ValueNode : XNode.Node 
    {
        protected const string k_CreateNodeMenuNameRoot = "DYLogic/Value/";

        protected void validateOutputConnection(NodePort from, NodePort to)
        {
            // fromType ---> toType
            var fromType = (from.GetOutputValue() as IValueType).Get().GetType();
            var toType = (to.ValueType.GetProperty("Value").PropertyType);//.GetInputValue() as IValueType).Get().GetType();

            bool isValidConnection = DYSerializer.ReflectionUtility.HasImplicitConversion(toType, fromType) || toType.IsAssignableFrom(fromType);

            if (!isValidConnection)
            {
                Debug.LogErrorFormat("Try to connect port to inconvertible / unassignable types: {0} -> {1}", fromType != null ? fromType.Name : "Null", toType.Name);
                from.Disconnect(to);
            }
        }
    
    }

    /// <summary>
    /// ValueNode is the abstract base class for Value Provider, it should always have only one Output port, which is of type IValueType
    /// </summary>
    public abstract class ValueNode<T> : ValueNode where T : IValueType
    {
        [Output] public T Output;

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            // From this.Output
            if (from.fieldName == nameof(Output))
            {
                validateOutputConnection(from, to);
            }
        }
    }
}
