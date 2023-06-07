using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    gun[] guns; //l�gger till alla guns i classen gun f�r alla guns
    bool shoot;
    int gunLevel = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        guns = transform.GetComponentsInChildren<gun>(); //guns �r alla guns i classen gun skapad i rad 7
        foreach (gun gun in guns) //s�g det h�r 5 g�nger snabt lol
        {
            if (gun.gunLevelRequierment != 0)
            {
                gun.enabled = false;
            }

        }
    }

    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //fethca muspostion
        rb.MovePosition(mousePosition); //flyta �player till mus

        shoot = Input.GetMouseButtonDown(0); //mouse_left �r shoot
        if (shoot) 
        {
            shoot = false; //du beh�ver trycka igen f�r varje g�ng du vill ha shoot
            foreach (gun gun in guns) //s�g det h�r 5 g�nger snabt lol
            {
                if (gun.enabled == true)
                {
                    gun.Shoot(); //skut en g�ng f�r varje gun jag hittar i classen gun i fileden gun
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        if (bullet != null) //f�rhindrar duplicate h�ndelser
        {
            if (bullet.enemyBullet) 
            {
                Destroy(gameObject); //d�da spelaren
                Destroy(bullet.gameObject); //trolla bort bullet som d�da
            }
        }

        destructable destructable = collision.GetComponent<destructable>(); //koliderar jag med n�gon finede (destructable)
        if (destructable != null) //f�rhindrar duplicate h�ndelser
        {
            Destroy(gameObject); //d�da spelaren
            Destroy(destructable.gameObject); //trolla bort bullet som d�da
        }

        powerUp powerUp = collision.GetComponent<powerUp>();
        {
            if (powerUp.gunUpgrade)
            {
                Debug.Log("in Power up");
                MoreGun();
            }
            Destroy(powerUp.gameObject); //trolla bort powerup
        }
    }

    private void MoreGun()
    {
        gunLevel++;
        Debug.Log("in Gun gun level = " + gunLevel);
        foreach(gun gun in guns)
        {
            if (gunLevel >= gun.gunLevelRequierment)
            {
                gun.enabled = true;
            }
        }
    }
}