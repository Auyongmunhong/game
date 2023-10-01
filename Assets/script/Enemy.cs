using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D _rb;
    public int moveSpeed;
    int direction;

    public Transform[] patrolPoint;
    void Start()
    {
        direction = 1;       
    }

    void Update()
    {
        if (transform.position.x < patrolPoint[0].position.x)
        {
            direction = 1;
        }        
        else if (transform.position.x > patrolPoint[1].position.x)
        {
            direction = -1;
        }
        _rb.velocity = new Vector2(moveSpeed * direction, _rb.velocity.y);
    }
}
