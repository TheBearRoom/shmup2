using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Move : MonoBehaviour
{
    gun[] guns;
    bool shoot;

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
}
