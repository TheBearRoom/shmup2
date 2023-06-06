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
    float loadingTime = 1;

    string[] levels = { "Level1", "Level2", "Level3"}; //heter samma som scenerna heter
    int currentLevel = 1;

    int score = 0;
    Text value;

    private void Awake() //gör allting inom scripted andvändbar med en gång
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            value = GameObject.Find("value").GetComponent<Text>();
        }
        
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
                    string sceneName = levels[currentLevel - 1]; //-1 för array, 
                    SceneManager.LoadSceneAsync(sceneName); //Async laddar nästa scene iförväg

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

    public void increaseScore(int scoreWorth)
    {
        score += scoreWorth;
        value.text = score.ToString();
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
