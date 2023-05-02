using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;

    public GameObject bullet;
    public float bulletSpeed = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = Vector2.zero;

        Vector2 dir = rb.velocity;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }

        rb.velocity = dir * speed;

        if (rb.velocity != Vector2.zero)
        {
            transform.right = rb.velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(
                bullet,
                transform.position,
                transform.rotation);

            go.GetComponent<Rigidbody2D>().velocity =
                transform.right.normalized * bulletSpeed;
        }
    }
}
