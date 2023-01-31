using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Move player in 2D space
    public float movementSpeed = 4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public float groundCheckDistance = 1f;
    public Camera mainCamera;
    public LayerMask groundLayer;
    float moveDirection = 0;
    Rigidbody2D r2d;

    BoxCollider2D mainCollider;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        moveDirection = Mathf.Lerp(moveDirection, Input.GetAxis("Horizontal"), 0.03f);
        Debug.Log(moveDirection);

        if(moveDirection < 0.1f)
        {
            r2d.velocity = new Vector2(0, r2d.velocity.y);
        }

        if (moveDirection != 0)
        {
            if (moveDirection > 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if(moveDirection < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            r2d.velocity = new Vector2(r2d.velocity.x * movementSpeed, jumpHeight);
        }

        r2d.velocity = new Vector2(moveDirection * movementSpeed, r2d.velocity.y);

    }

    void FixedUpdate()
    {
        Debug.DrawRay(mainCollider.bounds.center, Vector2.down * (mainCollider.bounds.extents.y + groundCheckDistance));
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(mainCollider.bounds.center, Vector2.down, mainCollider.bounds.extents.y + groundCheckDistance, groundLayer);
        
        return hit.collider != null;
    }
}