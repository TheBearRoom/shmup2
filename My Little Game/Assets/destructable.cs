using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class destructable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet2 bullet = collision.GetComponent<bullet2>();    
        if (bullet != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }

}