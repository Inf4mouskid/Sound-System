using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        SoundObject obj = EditorUtility.InstanceIDToObject(instanceId) as SoundObject;
        if (obj != null)
        {
            AudioEditorWindow.Open(obj);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(SoundObject))]
public class AudioEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open Collection"))
        {
            AudioEditorWindow.Open((SoundObject)target);
        }
    }
}
