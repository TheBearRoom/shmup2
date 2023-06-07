using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public int gunLevelRequierment = 0;


    public bullet_class bullet;
    Vector2 direction;

    public bool autoshoot = false; //fiende har autoshoot
    //Fiendernar andv�nder f�ljande v�rderna f�r att best�ma hur ofta de ska sjkuta 
    public float firingSpeed = 0.5f; //Hur ofta ska jag skjuta
    public float ShootDelaySeconds = 2.0f; //f�r attt skuta burst i omg�ngar
    public float shootTimer = 0f; //timer som tickar up till att n� firingSpeed
    public float deleyTimer = 0f; //timer som tickar up till att n� Deleyseconds f�r att sjkuta n�sta omg�ng

    //tyv�r har jag m�rkt att det inte riktigt fungerar s�h�r men har inte tid att fixa nu




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized; //sjkut �t riktnigen jag �r pekad �t

        if (autoshoot) //timer loopar f�r fiende sk�pp, see f�rklaring �vanf�r av variabler.
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
        gobullet.direction = direction; //s�tt riktning av bullet 

    }
}
