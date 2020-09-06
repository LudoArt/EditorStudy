using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectBuilderScript myScript = (ObjectBuilderScript)target;

        // 添加一个按钮，名叫Build Object
        if (GUILayout.Button("Build Object"))
        {
            // 当按钮被按下时执行
            myScript.BuildObject();
        }
    }
}
