using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  
    Vector3 Dir;
    private float distance;
    [Range(0, 10)]
    public float rotaa = 1;
    [Range(0, 100)]
    public float speed = 10;

    


    void Update()
    {
        
        transform.Rotate(new Vector3(0, -rotaa, 0));
    }
}
