using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;
    private Rigidbody2D rigidBody;
    private Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeHit(int damage, Transform enemy, int knockBackX, int knockBackY) {
        health -= damage;
        float knockDirectionX = Mathf.Sign(transform.position.x - enemy.transform.position.x);
        float knockDirectionY = Mathf.Sign(transform.position.y - enemy.transform.position.y);
        rigidBody.velocity += new Vector2(knockBackX * knockDirectionX, knockDirectionY * knockBackY);
    }
}
