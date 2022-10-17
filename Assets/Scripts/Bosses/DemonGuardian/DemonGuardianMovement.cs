using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGuardianMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;
    private Animator animator;
    private Transform transform;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>(); 
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Run();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite();
    }

    private void Run()
    {
        int runDirection = 0;
        if (Input.GetKey(KeyCode.L))
            runDirection = 1;
        else if (Input.GetKey(KeyCode.J)) {
            runDirection = -1;
        }

        rigidBody.velocity = new Vector2(moveSpeed * runDirection, rigidBody.velocity.y);

        if (runDirection == 0)
            animator.SetBool("DemonGuardianWalking", false);
        else animator.SetBool("DemonGuardianWalking", true);
    }


    void FlipSprite()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(-Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }
}
