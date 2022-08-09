using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
