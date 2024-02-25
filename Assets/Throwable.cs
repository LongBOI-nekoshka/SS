using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    Camera cam;
    Vector2 mousePos;

    void Awake()
    {
        // gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 5f, ForceMode2D.Impulse);
    }

    void Update()
    {
        if(transform.parent != null)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void FixedUpdate()
    {
        if(transform.parent != null) 
        {
            transform.right = (mousePos - (Vector2)transform.position).normalized;
        }
    }
}
