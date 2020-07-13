using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DYLogic.Node
{
    public abstract class ValueNode<T> : XNode.Node where T : IValueType
    {
        [Output] public T Output;

    }
}
