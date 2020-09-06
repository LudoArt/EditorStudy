using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 绑定对应的脚本
[CustomEditor(typeof(LevelScript))]
public class LevelScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // 通过target获取目标脚本，进行类型的强制转换
        LevelScript myLevelScript = (LevelScript)target;

        // IntField可读可写
        myLevelScript.experience = EditorGUILayout.IntField("Experience", myLevelScript.experience);

        // LabelField仅可读
        EditorGUILayout.LabelField("Level", myLevelScript.Level.ToString());
    }
}
