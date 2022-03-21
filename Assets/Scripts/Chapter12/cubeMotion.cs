using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMotion : MonoBehaviour
{
    public GameObject target;
    Vector3 Dir;
    private float distance;
    [Range(0,10)]
    public float rotaa = 1;
    [Range(0, 100)]
    public float speed = 10;

    void Start()
    {
        //初始的方向向量
        Dir = transform.position - target.transform.position;

        //初始距离目标物体的固定距离（月球与地球之间的距离）
        distance = Vector3.Distance(transform.position, target.transform.position);
    }


    void Update()
    {
        //transform.position = target.transform.position + Dir.normalized * distance;

        //绕目标物体旋转
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);

        //每帧更新方向向量
        //Dir = transform.position - target.transform.position;
        transform.Rotate(new Vector3(0,-rotaa,0));
    }
}
