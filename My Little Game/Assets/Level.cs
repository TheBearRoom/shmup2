using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int antalHinder = 20;
    public GameObject hinder;

    void Start()
    {
        for (int i = 0; i < antalHinder; i++)
        {
            Instantiate(
                hinder,
                Random.insideUnitCircle * 50,
                hinder.transform.rotation
                );
        }
    }
}
