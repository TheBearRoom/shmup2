using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public float enemies_on_screen = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length > enemies_on_screen)
        {

        }
    }
}
