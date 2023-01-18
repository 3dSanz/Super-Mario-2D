using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    // Start is called before the
     private Transform target;
     public Vector3 offset;
    void Start()
    {
        target = GameObject.Find("Mario_0").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
