using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowPointer : MonoBehaviour
{
    #region Singleton
    public static LightFollowPointer instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject container;
    public Vector2 PointerPosition {get; set;}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
        
        Vector2 scale = transform.localScale;
        if (direction.x < 0 && direction.y > 0)
        {
            scale.y = -1;
            scale.x = -1;
        }
        else if(direction.x > 0 && direction.y <= 0)
        {
            scale.y = 1;
            scale.x = 1;
        }
        else if(direction.x <= 0 && direction.y < 0)
        {
            scale.y = -1;
            scale.x = -1;
        }
        else if(direction.x > 0 && direction.y > 0)
        {
            scale.y = 1;
            scale.x = 1;
        }
        transform.localScale = scale;
    }

}
