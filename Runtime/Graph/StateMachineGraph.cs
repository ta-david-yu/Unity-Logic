using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic
{
    [CreateAssetMenu]
    public class StateMachineGraph : XNode.NodeGraph
    {
        public override XNode.Node AddNode(Type type)
        {
            

            Debug.Log("Add New Node");
            return base.AddNode(type);
        }
    }
}