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
            base.OnInspectorGUI();

            var varsProp = serializedObject.FindProperty("m_Variables");

            var varTable = target as IVarTable;
            var vars = new List<IVar>(varTable.Variables);

            var types = TypeCache.GetTypesDerivedFrom(typeof(IValueType)).Where((type) =>
                !type.IsSubclassOf(typeof(UnityEngine.Object)) &&
                !type.IsAbstract)
                .OrderBy((type) => type.Name);

            foreach (var type in types)
            {
                if (GUILayout.Button(type.Name))
                {
                    var newKeyName = type.Name + (vars.Count - 1).ToString();

                    varTable.AddVar(newKeyName, type);

                    varsProp.InsertArrayElementAtIndex(0);
                    var elementProp = varsProp.GetArrayElementAtIndex(vars.Count - 1);
                    elementProp.FindPropertyRelative("m_Key").stringValue = newKeyName;
                }
            }
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
