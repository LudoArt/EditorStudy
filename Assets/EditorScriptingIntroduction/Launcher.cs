using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Launcher : MonoBehaviour
{
    public Rigidbody projectile;
    public Vector3 offset = Vector3.forward;
    // 添加一个Range属性，在Inspector中创建一个滑块来调整该值
    [Range(0, 100)] public float velocity = 10;

    // 右键组件调用该函数（注意函数的参数必须为空）
    [ContextMenu("Fire")]
    public void Fire()
    {
        var body = Instantiate(
            projectile,
            transform.TransformPoint(offset),
            transform.rotation);
        body.velocity = Vector3.forward * velocity;
    }
}
