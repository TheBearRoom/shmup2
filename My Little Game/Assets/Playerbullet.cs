using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float bullet_speed = 1;
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 velocity;

    void Start()
    {
        Destroy(gameObject, 5); 
    }

    void Update()
    {
        velocity = direction * bullet_speed; //Hur mycket ska bullet förflyta sig?
        Vector2 pos = transform.position; //fetch bullet position
        pos += velocity * Time.fixedDeltaTime; //lägg till förflyting
        transform.position = pos; //förflyta bullet
    }
}
