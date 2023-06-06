using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelChanger : MonoBehaviour
{
    public static levelChanger instance;

    uint N_Enemies = 0; //Saker som g�r att f�rst�ras
    bool StartNextLevel = false;
    float loadingTime = 1; //tid som tar innan n�sta level byts, (kunda ha varit st�re men det var inte lika nice)

    string[] levels = { "Level1", "Level2", "Level3"}; //heter samma som scenerna heter
    int currentLevel = 1;

    int score = 0;
    Text value; //variablen som h�ller texten f�r siffrorna p� score UI

    private void Awake() //g�r allting inom loop andv�ndbar med en g�ng
    {
        if (instance == null) 
        {
            instance = this; //g�r detta till den enda instancen av level chancher
            DontDestroyOnLoad(gameObject); //f�rst�r inget inom LevelChanger on load
            value = GameObject.Find("value").GetComponent<Text>(); //beh�ll score
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
                currentLevel++; //hoppa till n�sta i levels index
                if (currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1]; //-1 f�r array, 
                    SceneManager.LoadSceneAsync(sceneName); //Async laddar n�sta scene if�rv�g
                }
                else
                {
                    Debug.Log("WINNER WINNER CHIKEN DINNER");
                }
                loadingTime = 1; //reset
                StartNextLevel = false; //ser till s� att inte den byter till n�sta niv� med en g�ng
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
        value.text = score.ToString(); //l�ggtill h�mtad score till score-texten
    }

    public void addEnemie()
    {
        Debug.Log("addEnemie");
        N_Enemies++;  //f�r varje object som har addEnemie, N_Enemies++
    }

    public void removeEnemie()
    {
        Debug.Log("removeEnemie");
        N_Enemies--;
        if (N_Enemies <= 0) //n�r  N_Enemies = 0 d� �r det dacks att byta level
        {
            StartNextLevel = true;
        }
    }
}
