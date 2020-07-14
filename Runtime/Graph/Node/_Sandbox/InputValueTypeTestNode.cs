using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    [CreateNodeMenu("DYLogic/Test/InputValueTypeTestNode")]
    public class InputValueTypeTestNode : XNode.Node
    {
        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        public IValueType Value;
        
        [DYSerializer.OnTypeChanged(nameof(onSerializableTypeChanged))]
        [DYSerializer.InterfaceImplementation(typeof(IValueType), AllowAbstract = true)]
        public DYSerializer.SerializableType Type;

        [Input] public Integer InputB;

        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        [Output(dynamicPortList = true)] public IValueType[] m_TypeArray;

        private void onSerializableTypeChanged(Type newType)
        {
            if (newType != null)
            {
                this.AddDynamicOutput(newType, ConnectionType.Multiple, TypeConstraint.Strict, $"Output {newType.Name}");
                this.AddDynamicInput(newType, ConnectionType.Multiple, TypeConstraint.Strict, $"Input {newType.Name}");
            }
        }
    }
}
