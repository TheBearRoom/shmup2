using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5;

    public GameObject bullet;
    public float bulletSpeed = 100;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(mousePosition); 


        if (Input.GetMouseButtonDown(0))
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
