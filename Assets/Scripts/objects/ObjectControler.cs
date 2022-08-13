using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControler : MonoBehaviour
{
    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;
    private float xVelocity;
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        xVelocity = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(-xVelocity, myRigidbody.velocity.y);
    }

    
}
