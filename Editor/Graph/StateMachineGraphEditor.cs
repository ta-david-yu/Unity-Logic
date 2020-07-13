using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace DYLogic
{
    [CustomNodeGraphEditor(typeof(StateMachineGraph), "DYLogic.Settings")]
    public class StateMachineGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(Type type)
        {
            if (typeof(Node.ValueNode).IsAssignableFrom(type) ||
                typeof(Node.StateNode).IsAssignableFrom(type))
            {
                return base.GetNodeMenuName(type);
            }

            return null;
        }

        public override void OnGUI()
        {
            using (new GUILayout.VerticalScope(new GUIStyle("HelpBox"), GUILayout.Width(150)))
            {
                var titleStyle = new GUIStyle("label");
                titleStyle.alignment = TextAnchor.MiddleCenter;

                GUILayout.Label("StateMachine Graph", titleStyle);

                using (new GUILayout.VerticalScope(new GUIStyle("HelpBox"), GUILayout.Width(150)))
                    GUILayout.Label(target.name, titleStyle);
            }
        }
    }
}