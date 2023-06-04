using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{


    public bullet2 bullet;
    Vector2 direction;

    public bool autoshoot = false;
    public float firingSpeed = 0.5f;
    public float ShootDelaySeconds = 2.0f;
    public float shootTimer = 0f;
    public float deleyTimer = 0f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;

        if (autoshoot)
        {
            if (deleyTimer >= ShootDelaySeconds) 
            { 
                if (shootTimer >= firingSpeed)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                deleyTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        bullet2 gobullet = go.GetComponent<bullet2>();
        gobullet.direction = direction;

    }
}
