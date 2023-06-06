using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    gun[] guns;
    bool shoot;
    bool isHit = false; // Flag to track if the player is hit

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        guns = transform.GetComponentsInChildren<gun>();
    }

    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(mousePosition);

        shoot = Input.GetMouseButtonDown(0);
        if (shoot)
        {
            shoot = false;
            foreach (gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        if (bullet != null)
        {
            if (bullet.enemyBullet)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        destructable destructable = collision.GetComponent<destructable>();
        if (destructable != null)
        {
            Destroy(gameObject);
            Destroy(destructable.gameObject);
        }
    }
}