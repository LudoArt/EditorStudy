using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); //这两者可能是等价的，至少在这个案例中表现是一样的
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("这是一个帮助信息", MessageType.Info);
    }
}
