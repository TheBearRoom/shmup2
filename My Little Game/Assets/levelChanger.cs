using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour
{
    public static levelChanger instance;

    uint N_Enemies = 0;
    bool StartNextLevel = false;
    float loadingTime = 1;

    string[] levels = { "Level1", "Level2" }; //heter samma som scenerna heter
    int currentLevel = 1;

    private void Awake() //g�r allting inom scripted andv�ndbar med en g�ng
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StartNextLevel)
        {
            Debug.Log("start next");
            if (loadingTime <= 0)
            {
                Debug.Log("time");
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    Debug.Log("array");
                    string sceneName = levels[currentLevel - 1]; //-1 f�r array, 
                    SceneManager.LoadSceneAsync(sceneName); //Async laddar n�sta scene if�rv�g

                }
                else
                {
                    Debug.Log("WINNER WINNER CHIKEN DINNER");
                }
                loadingTime = 1;
                StartNextLevel = false;
            }
            else
            {
                loadingTime -= Time.deltaTime;
            }
        }
    }

    public void addEnemie()
    {
        Debug.Log("addEnemie");
        N_Enemies++;
    }

    public void removeEnemie()
    {
        Debug.Log("removeEnemie");
        N_Enemies--;
        if (N_Enemies <= 0)
        {
            StartNextLevel = true;
        }
    }
}
