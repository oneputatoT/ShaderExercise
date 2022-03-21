using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepteDissolve : MonoBehaviour
{
    public Renderer renderer;
    public Material material;
    public float speed;
    public float length;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        if (renderer != null)
            material = renderer.material;
    }

    private void Update()
    {
        speed = Mathf.Repeat(Time.time*0.3f, 1.0f);
        material.SetFloat("_BurnAmount", speed);
    }
}
