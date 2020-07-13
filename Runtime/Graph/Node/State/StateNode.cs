using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DYLogic.Node
{
    [NodeWidth(250)]
    [NodeTint("#ff5733")]
    public abstract class StateNode : XNode.Node
    {
        [Input(backingValue = ShowBackingValue.Never, typeConstraint = TypeConstraint.Inherited)] 
        public StateNode PrevState;

        [Output(typeConstraint = TypeConstraint.Inherited)] 
        public StateNode NextStateOnEnd;

        public virtual IEnumerator EnterState(MonoBehaviour executor)
        {
            onEnter();
            yield return executor.StartCoroutine(onStay(executor));
            onExit();
        }

        protected virtual void onEnter() { }
        protected abstract IEnumerator onStay(MonoBehaviour executor);
        protected virtual void onExit() { }
    }
}
