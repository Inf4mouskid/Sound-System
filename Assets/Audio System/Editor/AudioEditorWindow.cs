using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioEditorWindow : ExtendWindow
{
    GUIStyle Style;
    public static void Open(SoundObject SoundDataObject)
    {
        AudioEditorWindow Window = GetWindow<AudioEditorWindow>("Audio Collection");
        Window.serializedObject = new SerializedObject(SoundDataObject);
    }

    private void OnGUI()
    {
        currentProperty = serializedObject.FindProperty("Group");
        DrawProperty(currentProperty, true);
        currentProperty = serializedObject.FindProperty("SoundFiles");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(145), GUILayout.ExpandHeight(true));
        DrawSidebar(currentProperty);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        if (selectedProperty != null)
        {
            DrawProperties(selectedProperty, true);
        }
        else
        {
            EditorGUILayout.LabelField("Select a sound!");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add"))
        {
            currentProperty.arraySize++;
        }

        if (GUILayout.Button("Remove"))
        {
            currentProperty.arraySize--;
        }
        EditorGUILayout.EndVertical();
        Apply();
    }
}
