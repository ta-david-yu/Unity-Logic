using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace DYLogic
{
    [CustomPropertyDrawer(typeof(TableVarReferenceBase), true)]
    public class TableVarReferenceDrawer : PropertyDrawer
    {
        protected virtual IEnumerable<string> getListOfVarKeys(IVarTable table)
        {
            return table.Vars.Select((ivar) => ivar.Key);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 2 + 1 * EditorGUIUtility.standardVerticalSpacing;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (var propScope = new EditorGUI.PropertyScope(position, label, property))
            {
                // draw rect size
                var tableFieldPos = position;
                tableFieldPos.height = EditorGUIUtility.singleLineHeight;
                tableFieldPos.width = position.width;

                var popupPos = position;
                popupPos.height = EditorGUIUtility.singleLineHeight;
                popupPos.width -= EditorGUIUtility.labelWidth;
                popupPos.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                popupPos.x += EditorGUIUtility.labelWidth;

                // draw table obj reference field
                var tableProp = property.FindPropertyRelative("m_TargetTable");
                EditorGUI.ObjectField(tableFieldPos, tableProp, label);

                // draw popup selection
                var keyProp = property.FindPropertyRelative("m_TargetKey");

                // get var list in the IVarTable
                if (tableProp.objectReferenceValue != null)
                {
                    var varTableObj = tableProp.objectReferenceValue as IVarTable;

                    List<string> variableNames = new List<string>();
                    variableNames.Add("<None>");
                    variableNames.AddRange(getListOfVarKeys(varTableObj));

                    string propertyString = keyProp.stringValue;
                    int index = -1;

                    if (propertyString == "")
                    {
                        // The tag is empty
                        index = 0; // first index is the special <notag> entry
                    }
                    else
                    {
                        // check if there is an entry that matches the entry and get the index
                        // we skip index 0 as that is a special custom case
                        for (int i = 1; i < variableNames.Count; i++)
                        {
                            if (variableNames[i] == propertyString)
                            {
                                index = i;
                                break;
                            }
                        }
                    }

                    // Draw the popup box with the current selected index
                    index = EditorGUI.Popup(popupPos, index, variableNames.ToArray());

                    // Adjust the actual string value of the property based on the selection
                    if (index == 0)
                    {
                        keyProp.stringValue = "";
                    }
                    else if (index >= 1)
                    {
                        keyProp.stringValue = variableNames[index];
                    }
                    else
                    {
                        keyProp.stringValue = "";
                    }
                }
                else
                {
                    EditorGUI.HelpBox(popupPos, "You need to reference a table!", MessageType.Warning);
                }
            }
        }
    }
}

