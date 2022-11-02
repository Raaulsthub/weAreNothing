using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private GameObject player;
    public bool chasing = false;
    public Transform idlePoint;
    [SerializeField] private float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!player)
            return;
        if (chasing)
            chase();
        else
            returnToIdlePoint();
        flip();
    }

    private void returnToIdlePoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, idlePoint.position, speed * Time.deltaTime);
    }

    private void chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
