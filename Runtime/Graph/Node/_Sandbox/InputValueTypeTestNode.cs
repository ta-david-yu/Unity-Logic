using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic
{
    public class InputValueTypeTestNode : XNode.Node
    {
        [SerializeReference]
        [DYSerializer.SerializeRefUI]
        public IValueType Value;

        [DYSerializer.InterfaceImplementation(typeof(IValueType), AllowAbstract = true)]
        public DYSerializer.SerializableType Type;

        [Input] public Integer InputB;
    }
}
