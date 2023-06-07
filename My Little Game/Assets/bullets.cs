using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_class : MonoBehaviour
{
    public float bullet_speed = 5;
    public Vector2 direction = new Vector2(1, 0); //f�rflyta i Y led
    public Vector2 velocity;
    public bool enemyBullet = false;

    void Start()
    {
        Destroy(gameObject, 4); 
    }

    void Update()
    {
        velocity = direction * bullet_speed; //Hur snabt ska bullet f�rflyta sig?
        Vector2 pos = transform.position; //fetch bullet position
        pos += velocity * Time.fixedDeltaTime; //l�gg till f�rflyting
        transform.position = pos; //f�rflyta bullet
    }
}
