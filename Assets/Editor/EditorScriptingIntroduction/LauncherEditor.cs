using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor
{

    [DrawGizmo(GizmoType.Pickable | GizmoType.Selected)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
    {
        // 从本地坐标到世界坐标的一个转换
        var offsetPosition = launcher.transform.TransformPoint(launcher.offset);
        // 从发射器对象到偏移位置画了一条虚线
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        // 添加标签
        Handles.Label(offsetPosition, "Offset");
        if (launcher.projectile != null)
        {
            // 预测运动位置信息
            var positions = new List<Vector3>();
            var velocity = launcher.transform.forward *
                launcher.velocity /
                launcher.projectile.mass;
            var position = offsetPosition;
            var physicsStep = 0.1f;
            for (var i = 0f; i <= 1f; i += physicsStep)
            {
                positions.Add(position);
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }
            using (new Handles.DrawingScope(Color.yellow))
            {
                // 根据一堆位置信息画一条曲线
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count - 1], 0.125f);
                Handles.Label(positions[positions.Count - 1], "Estimated Position (1 sec)");
            }
        }
    }


    // 使用OnSceneGUI方法，这样我们就可以拥有一个小部件
    // 允许我们在场景视图中显示和调整偏移位置
    void OnSceneGUI()
    {
        var launcher = target as Launcher;
        var transform = launcher.transform;

        using (var cc = new EditorGUI.ChangeCheckScope())
        {
            var newOffset = transform.InverseTransformPoint(

            // Transform.InverseTransformPoint和Transform.TransformPoint方法
            // 将偏移量转换为世界空间供Handles.PositionHandle方法使用
            Handles.PositionHandle(
                transform.TransformPoint(launcher.offset),
                transform.rotation));

            if (cc.changed)
            {
                // 使用Undo.RecordObject，在偏移量被改变时记录一个被撤销的操作
                Undo.RecordObject(launcher, "Offset Change");
                launcher.offset = newOffset;
            }
        }


        Handles.BeginGUI();
        //                                                       计算绘制GUI的矩形空间位置
        var rectMin = Camera.current.WorldToScreenPoint(
            launcher.transform.position +
            launcher.offset);
        var rect = new Rect();
        rect.xMin = rectMin.x;
        rect.yMin = SceneView.currentDrawingSceneView.position.height -
            rectMin.y;
        rect.width = 64;
        rect.height = 18;

        GUILayout.BeginArea(rect);
        // 使用EditorGUI.DisabledGroupScope方法，仅在Play模式下才会启用该按钮
        using (new EditorGUI.DisabledGroupScope(!Application.isPlaying))
        {
            if (GUILayout.Button("Fire"))
                launcher.Fire();
        }
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}
