using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destructable : MonoBehaviour
{
    bool onScreen = false;
    Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            onScreen= true;
            //Debug.Log("Object is visible");
        }
        else
        {
            //Debug.Log("Object is invisible");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!onScreen)
        {
            return;
        }
        else
        {
            bullet_class bullet = collision.GetComponent<bullet_class>();
            if (bullet != null)
            {

                if (!bullet.enemyBullet)
                {
                    Destroy(gameObject);
                    Destroy(bullet.gameObject);
                }

            }
        }
       
    }

}
