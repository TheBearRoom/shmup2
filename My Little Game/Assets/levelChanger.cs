using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelChanger : MonoBehaviour
{
    public static levelChanger instance;

    uint N_Enemies = 0;
    bool StartNextLevel = false;
    float loadingTime = 3;
    
    int score = 0;
    Text scoreText;

    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            scoreText = GameObject.Find("scoreText").GetComponent<Text>();

        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
      
        
    }

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
                    string sceneName = levels[currentLevel - 1]; 
                    SceneManager.LoadSceneAsync(sceneName); //Async laddar nästa scene iförväg

                }
                else
                {
                    Debug.Log("WINNER WINNER CHIKEN DINNER");
                }
                loadingTime = 3;
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

    public void gotScore(int gotScore)
    {
        score += gotScore;
        scoreText.text = gotScore.ToString();
    }
}
