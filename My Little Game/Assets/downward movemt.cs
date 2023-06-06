using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class downwardmovemt : MonoBehaviour
{
    public float moveSpeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -45f)
        {
            Destroy(gameObject); //f�rs�r om �ker till botten av sk�rmen
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position; //fetch position
        pos.y -= moveSpeed * Time.fixedDeltaTime; //l�gg till f�rflyting
        transform.position = pos; //f�rflyta mig
    }
}
