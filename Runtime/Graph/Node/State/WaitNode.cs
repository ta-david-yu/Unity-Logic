using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/State/Wait")]
    public class WaitNode : StateNode
    {
        [Input(connectionType = ConnectionType.Override)] 
        public Float WaitTime;

        protected override IEnumerator onStay(MonoBehaviour executor)
        {
            yield return new WaitForSeconds(GetInputValue<Float>(nameof(WaitTime)));
        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            if (to.fieldName == nameof(WaitTime))
            {
                // Connet Input for WaitTime
                var fromValue = from.GetOutputValue();
                /*
                if (typeof(IValueType).IsAssignableFrom(fromValue.GetType()))
                {
                    var valueTypeValue = fromValue as IValueType;
                    if (typeof(float).IsAssignableFrom(valueTypeValue.Get().GetType()))
                    {
                        Debug.Log("OK! - " + valueTypeValue.Get().GetType().Name);
                    }
                    else
                    {
                        Debug.Log("FK! - " + valueTypeValue.Get().GetType().Name);
                        Debug.Log(typeof(float).IsAssignableFrom(typeof(int)));
                    }
                }
                else
                {
                    Debug.Log("FK!");
                }
                */
            }
        }
    }
}
