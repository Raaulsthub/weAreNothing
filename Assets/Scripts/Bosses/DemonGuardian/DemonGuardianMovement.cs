using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGuardianMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>(); 

    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void Run()
    {
        int RunDirection = 0;
        if (Input.GetKey(KeyCode.L))
            RunDirection = 1;
        else if (Input.GetKey(KeyCode.J))
            RunDirection = -1;

        rigidBody.velocity = new Vector2(moveSpeed * RunDirection, rigidBody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.I) && grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
