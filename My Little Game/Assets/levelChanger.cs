using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelChanger : MonoBehaviour
{
    public static levelChanger instance;

    uint N_Enemies = 0; //Saker som går att förstöras
    bool StartNextLevel = false;
    float loadingTime = 1; //tid som tar innan nästa level byts, (kunda ha varit störe men det var inte lika nice)

    string[] levels = { "Level1", "Level2", "Level3"}; //heter samma som scenerna heter
    int currentLevel = 1;

    int score = 0;
    Text value; //variablen som håller texten för siffrorna på score UI

    private void Awake() //gör allting inom loop andvändbar med en gång
    {
        if (instance == null) 
        {
            instance = this; //gör detta till den enda instancen av level chancher
            DontDestroyOnLoad(gameObject); //förstör inget inom LevelChanger on load
            value = GameObject.Find("value").GetComponent<Text>(); //behåll score
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
            if (loadingTime <= 0) //ticka ner loading time
            {
                Debug.Log("time");
                currentLevel++; //hoppa till nästa i levels index
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1]; //-1 för array, 
                    SceneManager.LoadSceneAsync(sceneName); //Async laddar nästa scene iförväg
                }
                else
                {
                    Debug.Log("WINNER WINNER CHIKEN DINNER");
                }
                loadingTime = 1; //reset
                StartNextLevel = false; //ser till så att inte den byter till nästa nivå med en gång
            }
            else
            {
                loadingTime -= Time.deltaTime; //ticka ner loading time en sekund
            }
        }
    }

    public void increaseScore(int scoreWorth)
    {
        score += scoreWorth;
        value.text = score.ToString(); //läggtill hämtad score till score-texten
    }

    public void addEnemie()
    {
        Debug.Log("addEnemie");
        N_Enemies++;  //för varje object som har addEnemie, N_Enemies++
    }

    public void removeEnemie()
    {
        Debug.Log("removeEnemie");
        N_Enemies--;
        if (N_Enemies <= 0) //när  N_Enemies = 0 då är det dacks att byta level
        {
            StartNextLevel = true;
        }
    }
}
