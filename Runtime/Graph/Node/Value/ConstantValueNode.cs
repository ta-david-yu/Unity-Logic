using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    /// <summary>
    /// ConstantValueNode is a generic value node of type IValueType, the Output port is dynamic based on the type of the instance
    /// </summary>
    [CreateNodeMenu(k_CreateNodeMenuNameRoot + "Constant")]
    public class ConstantValueNode : ValueNode
    {
        private const string k_OutputPortName = "Output";

        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        [DYSerializer.OnTypeChanged(nameof(onTypeChanged))]
        public IValueType Constant;

        public override object GetValue(NodePort port)
        {
            if (port.fieldName == k_OutputPortName)
            {
                return Constant;
            }
            else
            {
                return null;
            }
        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            // From this.Output
            if (from.fieldName == k_OutputPortName)
            {
                validateOutputConnection(from, to);
            }
        }

        private void Reset()
        {
            name = "Constant (Null)";
        }

        private void onTypeChanged(Type type)
        {
            if (this.HasPort(k_OutputPortName))
            {
                this.RemoveDynamicPort(k_OutputPortName);
            }

            if (type != null)
            {
                this.AddDynamicOutput(type, fieldName: k_OutputPortName);
                name = type.Name;
            }
            else
            {
                name = "Constant (Null)";
            }
        }
    }
}