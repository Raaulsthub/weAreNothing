using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    
    CapsuleCollider2D myCollider;
    BoxCollider2D feetCollider;
    private bool grounded;

    private bool isJumping;
    private float jumpTime;
    public float jumpQuantity;
    private bool doubleJump;
    Animator myAnimator;
    private float moveInputX;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float moveSpeed;
    

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>(); 
        myAnimator = GetComponent<Animator>();
        feetCollider = GetComponent<BoxCollider2D>();
        grounded = true;
    }

    void FixedUpdate(){
        moveInputX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveInputX *= 1.5f;
        }

        Run();
        Jump();
    }
    void Update()
    {
        FlipSprite();
    }

    void Run()
    {
        myRigidBody.velocity = new Vector2(moveInputX * moveSpeed, myRigidBody.velocity.y);
        myAnimator.SetBool("isRunning", Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (grounded || doubleJump)){
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            myAnimator.SetBool("isJumping", true);
            grounded = false;

            jumpTime = jumpQuantity;
            isJumping = true;
            doubleJump = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && doubleJump){
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            myAnimator.SetBool("isJumping", true);

            jumpTime = jumpQuantity;
            isJumping = true;
            doubleJump = false;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true){
            if(jumpTime > 0){
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
                jumpTime -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
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
