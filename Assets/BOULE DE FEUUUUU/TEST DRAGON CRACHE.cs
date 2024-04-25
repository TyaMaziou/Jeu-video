

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTDRAGONCRACHE1 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
 

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

    
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);


    }
}