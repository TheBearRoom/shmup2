using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public bool gunUpgrade;
    public bool HealthPickUp;
    public bool Invinsablity;

    // Start is called before the first frame update
    void Start()
    {
        levelChanger.instance.addEnemie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        levelChanger.instance.removeEnemie(); //ta bort mig från enime count i LevelChanger
    }
}
