using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class reloadScript : MonoBehaviour
{
    public Text Score;
    public Text hiScore;
    float initScore;
    float inithighScore;


    // Start is called before the first frame update
    void Start()
    {
        initScore = PlayerPrefs.GetFloat("Score");
        inithighScore = PlayerPrefs.GetFloat("Highscore");  
        Score.text = "Score: " + initScore.ToString();
        hiScore.text = "High Score: " +  inithighScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retryGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
