using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myCollider;
    Animator myAnimator;
    private float moveInputX;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>(); 
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInputX = Input.GetAxisRaw("Horizontal");
        Run();
        Jump();
        FlipSprite();
    }

    void Run()
    {
        myRigidBody.velocity = new Vector2(moveInputX * moveSpeed, myRigidBody.velocity.y);
        myAnimator.SetBool("isRunning", Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon);
    }
    void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        myRigidBody.velocity += new Vector2(0f, jumpSpeed);
        myAnimator.SetBool("isJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            myAnimator.SetBool("isJumping", false);
        }
    }

    void FlipSprite()
    {
        if (Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
