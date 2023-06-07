using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destructable : MonoBehaviour
{
    public bool spawned = false;
    public int health = 1;
    public int scoreWorth = 10; //defult v�rde f�r hur mycket score en fiende med


    // Start is called before the first frame update
    void Start()
    {
        levelChanger.instance.addEnemie(); //s�ger till levelChanger att det finns en till fiende
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        if (bullet != null) //f�rhindrar duplicate h�ndelser
        {

            if (!bullet.enemyBullet) //�r det det en playerbullet?
            {
                if (health >= 0 ) 
                {
                    Debug.Log("DEATH");
                    levelChanger.instance.increaseScore(scoreWorth); //skicka min score till LevelChanger
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Hit");
                    health--;
                }
                Destroy(bullet.gameObject);

            }

        }
    }

    private void OnDestroy()
    {
       levelChanger.instance.removeEnemie(); //ta bort mig fr�n enime count i LevelChanger
    }

}
