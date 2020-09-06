using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Projectile))]
public class ProjectileEditor : Editor
{
    // 添加一个Gizmo，当没有可渲染几何体的时候，可以在场景视图中看到Gizmo
    // 当Obj被选中或没被选中时，都绘制该Gizmo
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmosSelected(Projectile projectile, GizmoType gizmoType)
    {
        Gizmos.DrawSphere(projectile.transform.position, 0.125f);
    }


    void OnSceneGUI()
    {
        var projectile = target as Projectile;
        var transform = projectile.transform;

        // 使用Handles.RadiusHandle可以可视化该字段，并允许在场景视图中对其进行调整
        projectile.damageRadius = Handles.RadiusHandle(
            transform.rotation,
            transform.position,
            projectile.damageRadius);
    }
}
