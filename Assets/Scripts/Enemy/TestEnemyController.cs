using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private int health;
    [SerializeField] private float knockBackX;
    [SerializeField] private float knockBackY;
    private Transform transform;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    public void takeHit(PlayerCombat player)
    {
        health -= 10;
        float knockDirectionX = Mathf.Sign(transform.position.x - player.transform.position.x);
        float knockDirectionY = Mathf.Sign(transform.position.y - player.transform.position.y);
        rigidBody.velocity += new Vector2(knockBackX * knockDirectionX, knockDirectionY * knockBackY);
    }
}
