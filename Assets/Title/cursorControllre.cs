using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cursorControllre : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    float speed;

    void Start()
    {
         speed = 3f;
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
}
