using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destructable : MonoBehaviour
{
    public bool spawned = false;
    bool spawnCheck = true;
    public int scoreWorth = 10;


    // Start is called before the first frame update
    void Start()
    {
        levelChanger.instance.addEnemie();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        if (bullet != null)
        {

            if (!bullet.enemyBullet)
            {
                levelChanger.instance.increaseScore(scoreWorth);
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }

        }
    }

    private void OnDestroy()
    {
       levelChanger.instance.removeEnemie();
    }

}
