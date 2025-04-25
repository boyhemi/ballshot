using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manage : MonoBehaviour
{
    public Text firstHighScore;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("Highscore") == 0 )
        {
            PlayerPrefs.SetFloat("Highscore", 0);
        }
        else
        {
         firstHighScore.text = "High Score: " + PlayerPrefs.GetFloat("Highscore").ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void startGame()
    {
        SceneManager.LoadScene("Main");
    }
}
