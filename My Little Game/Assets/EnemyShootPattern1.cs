using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootPattern1 : MonoBehaviour
{
    public float enemybulletSpeed = 1;
    public float cooldown = 1;
    public float destroy_time = 3;
    public GameObject enemybullet;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("wave", 1f, cooldown);
    }

    void wave()
    {
        GameObject go = Instantiate(

               enemybullet,
               transform.position,
               transform.rotation);

        go.GetComponent<Rigidbody2D>().velocity =
            transform.right.normalized * enemybulletSpeed;
       
        Destroy(go, destroy_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
