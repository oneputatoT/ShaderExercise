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
        //��ʼ�ķ�������
        Dir = transform.position - target.transform.position;

        //��ʼ����Ŀ������Ĺ̶����루���������֮��ľ��룩
        distance = Vector3.Distance(transform.position, target.transform.position);
    }


    void Update()
    {
        //transform.position = target.transform.position + Dir.normalized * distance;

        //��Ŀ��������ת
        transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);

        //ÿ֡���·�������
        //Dir = transform.position - target.transform.position;
        transform.Rotate(new Vector3(0,-rotaa,0));
    }
}
