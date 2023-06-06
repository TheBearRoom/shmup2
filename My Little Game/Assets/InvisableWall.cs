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
    //Det här fungerar inte tror jag, orkar inte ta bort de nu ifallall det har sönder något. (Jag skriver de här kommentarerna rätt så sent)
    {
        bullet_class bullet = collision.GetComponent<bullet_class>();
        Destroy(bullet);
    }
}
