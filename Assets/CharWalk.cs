using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharWalk : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public Rigidbody2D rigidbody2d;
    public Light2D globalLight;
    Vector2 movement;
    Vector2 pointerInput;
    LightFollowPointer lightFollow;
    Vector2 mousePos2;
    Vector2 playerPos;
    Vector2 mousePos;
    Vector2 playerToMouseVector;
    // Start is called before the first frame update
    void Start()
    {
        lightFollow = GetComponentInChildren<LightFollowPointer>();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rigidbody2d.velocity = movement * movementSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        pointerInput = GetPointerInput();
        lightFollow.PointerPosition = pointerInput;
        mousePos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        playerPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = Input.mousePosition;
        playerToMouseVector = (mousePos - playerPos).normalized;
    }

    Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public float GetDistance() 
    {
        return Vector2.Distance(transform.position,globalLight.transform.position);
    }
}
