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

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    //Det h�r fungerar inte tror jag, orkar inte ta bort de nu ifallall det har s�nder n�got. (Jag skriver de h�r kommentarerna r�tt s� sent)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        Destroy(bullet);
    }
}
