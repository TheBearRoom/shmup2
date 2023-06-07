using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public int gunLevelRequierment = 0;


    public bullet_class bullet;
    Vector2 direction;

    public bool autoshoot = false; //fiende har autoshoot
    //Fiendernar andvänder följande värderna för att bestäma hur ofta de ska sjkuta 
    public float firingSpeed = 0.5f; //Hur ofta ska jag skjuta
    public float ShootDelaySeconds = 2.0f; //för attt skuta burst i omgångar
    public float shootTimer = 0f; //timer som tickar up till att nå firingSpeed
    public float deleyTimer = 0f; //timer som tickar up till att nå Deleyseconds för att sjkuta nästa omgång

    //tyvär har jag märkt att det inte riktigt fungerar såhär men har inte tid att fixa nu




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized; //sjkut åt riktnigen jag är pekad åt

        if (autoshoot) //timer loopar för fiende skäpp, see förklaring åvanför av variabler.
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
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity); //instansiera bullet
        bullet_class gobullet = go.GetComponent<bullet_class>(); //fetcha class
        gobullet.direction = direction; //sätt riktning av bullet 

    }
}
