using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    gun[] guns; //lägger till alla guns i classen gun för alla guns
    bool shoot;
    int gunLevel = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        guns = transform.GetComponentsInChildren<gun>(); //guns är alla guns i classen gun skapad i rad 7
        foreach (gun gun in guns) //säg det här 5 gånger snabt lol
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
        rb.MovePosition(mousePosition); //flyta ´player till mus

        shoot = Input.GetMouseButtonDown(0); //mouse_left är shoot
        if (shoot) 
        {
            shoot = false; //du behöver trycka igen för varje gång du vill ha shoot
            foreach (gun gun in guns) //säg det här 5 gånger snabt lol
            {
                if (gun.enabled == true)
                {
                    gun.Shoot(); //skut en gång för varje gun jag hittar i classen gun i fileden gun
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        if (bullet != null) //förhindrar duplicate händelser
        {
            if (bullet.enemyBullet) 
            {
                Destroy(gameObject); //döda spelaren
                Destroy(bullet.gameObject); //trolla bort bullet som döda
            }
        }

        destructable destructable = collision.GetComponent<destructable>(); //koliderar jag med någon finede (destructable)
        if (destructable != null) //förhindrar duplicate händelser
        {
            Destroy(gameObject); //döda spelaren
            Destroy(destructable.gameObject); //trolla bort bullet som döda
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