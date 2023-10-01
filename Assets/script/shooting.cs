using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D _rb;
    public int moveSpeed;
    public int direction;
    
    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        _rb.velocity = new Vector2(moveSpeed * direction, _rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "box")
        {

        }

        if (col.gameObject.tag == "Enemy")
        {
            //deduct enemy hp
            //enemy die animation
            //explosion effect

            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
