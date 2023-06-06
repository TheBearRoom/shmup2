using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.y -= moveSpeed * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
