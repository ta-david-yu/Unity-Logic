using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DYLogic.Node
{
    [CreateNodeMenu("DYLogic/State/UnityEvent")]
    public class UnityEventNode : StateNode
    {
        public UnityEvent Event;

        protected override IEnumerator onStay(MonoBehaviour executor)
        {
            Event.Invoke();
            yield return null;
        }
    }
}
