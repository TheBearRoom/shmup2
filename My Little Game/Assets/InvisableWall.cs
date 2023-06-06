using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisableWall : MonoBehaviour
{
    bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy = true)
        {
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        Destroy(bullet);
    }
}
