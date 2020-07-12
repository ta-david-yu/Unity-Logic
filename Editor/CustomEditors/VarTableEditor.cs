using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DYLogic
{
    public class VarTableEditor : Editor
    {
        public static List<Type> s_IValueTypes;

        public override void OnInspectorGUI()
        {
            var varsProp = serializedObject.FindProperty("m_Variables");

            var varTable = target as IVarTable;
            var vars = new List<IVar>(varTable.Variables);

            var types = TypeCache.GetTypesDerivedFrom(typeof(IValueType)).Where((type) =>
                !type.IsSubclassOf(typeof(UnityEngine.Object)) &&
                !type.IsAbstract)
                .OrderBy((type) => type.Name);

            GenericMenu addVarMenu = new GenericMenu();

            foreach (var type in types)
            {
                addVarMenu.AddItem(new GUIContent(type.Name), false, addNewVar, type);
            }

            var bgCol = GUI.backgroundColor;

            var boxStyle = new GUIStyle("HelpBox");
            using (new GUILayout.VerticalScope(boxStyle))
            {
                var titleStyle = new GUIStyle("label");
                titleStyle.alignment = TextAnchor.MiddleCenter;
                GUILayout.Label("Actions", titleStyle);
                using (new GUILayout.HorizontalScope())
                {
                    GUI.backgroundColor = Color.yellow;
                    if (GUILayout.Button("Add"))
                    {
                        addVarMenu.ShowAsContext();
                    }

                    GUI.backgroundColor = Color.red;
                    if (GUILayout.Button("Move"))
                    {

                    }
                }
            }

            GUI.backgroundColor = bgCol;

            void addNewVar(object typeObj)
            {
                Type type = typeObj as Type;
                var newKeyName = (vars.Count).ToString("00") + "-" + type.Name;

                Undo.RecordObject(target, "Add new variable");
                varTable.AddVar(newKeyName, type);
            }

            base.OnInspectorGUI();
        }
    }

    [CustomEditor(typeof(LocalVarTable))]
    public class LocalVarTableEditor : VarTableEditor
    {

    }

    [CustomEditor(typeof(GlobalVarTable))]
    public class GlobalVarTableEditor : VarTableEditor
    {

    }
}
