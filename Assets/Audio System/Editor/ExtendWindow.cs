using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExtendWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty currentProperty;

    private string selectedPropertyPath;
    protected SerializedProperty selectedProperty;

    protected void DrawProperties(SerializedProperty prop, bool drawChildren)
    {
        string lastPropPath = string.Empty;
        foreach (SerializedProperty p in prop)
        {
            if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                EditorGUILayout.BeginHorizontal();
                p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                EditorGUILayout.EndHorizontal();

                if (p.isExpanded)
                {
                    DrawProperties(p, drawChildren);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath)) { continue; }
                lastPropPath = p.propertyPath;
                EditorGUILayout.PropertyField(p, drawChildren);
            }
        }
    }

    protected void DrawProperty(SerializedProperty prop, bool drawChildren)
    {
        string lastPropPath = string.Empty;
        if (prop.isArray && prop.propertyType == SerializedPropertyType.Generic)
        {
            EditorGUILayout.BeginHorizontal();
            prop.isExpanded = EditorGUILayout.Foldout(prop.isExpanded, prop.displayName);
            EditorGUILayout.EndHorizontal();

            if (prop.isExpanded)
            {
                EditorGUI.indentLevel++;
                DrawProperty(prop, drawChildren);
                EditorGUI.indentLevel--;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(lastPropPath) && prop.propertyPath.Contains(lastPropPath)) { return; }
            lastPropPath = prop.propertyPath;
            EditorGUILayout.PropertyField(prop, drawChildren);
        }
    }

    protected void DrawSidebar(SerializedProperty prop)
    {
        foreach (SerializedProperty p in prop)
        {
            if (GUILayout.Button(p.displayName))
            {
                selectedPropertyPath = p.propertyPath;
            }
        }

        if (!string.IsNullOrEmpty(selectedPropertyPath))
        {
            selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
        }
    }

    protected void Apply()
    {
        serializedObject.ApplyModifiedProperties();
    }
}
