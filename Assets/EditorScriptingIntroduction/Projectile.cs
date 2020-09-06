using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))] // 若当前物体不存在Rigidbody这个组件的时候，当第一次给物体添加这个组件，将会自动添加一个Rigidbody
public class Projectile : MonoBehaviour
{
    // 使用HideInInspector属性，将该rigidbody隐藏起来
    [HideInInspector] new public Rigidbody rigidbody;
    public float damageRadius = 1;

    // Reset函数将在添加组件的时候自动被调用
    // 也可以通过在Inspector界面右键组件手动调用
    private void Reset()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
