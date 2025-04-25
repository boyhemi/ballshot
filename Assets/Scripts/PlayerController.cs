using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Gravitons.UI.Modal;

public class PlayerController : MonoBehaviour
{
    public float acceleration;
    public float modifySpeed;
    Touch touchInput;
    public Text gameoverTxt;
    public Text score;
    public bool itisDone; 
    public float scoreCount;
    public float speedBoost;
    public int reviveCount;
    
    
    private void Awake() {
        scoreCount = 0;
        
        if (PlayerPrefs.GetFloat("Highscore") == 0)
        {
            PlayerPrefs.SetFloat("Highscore", 0);

        }
         PlayerPrefs.SetFloat("Score", scoreCount);

    }

    void Start()
    {
        itisDone = false;
        gameoverTxt.enabled = false;
        speedBoost = 4f;
        modifySpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedBoost >= 0)
        {
            speedBoost -= Time.deltaTime;

        }
        if (speedBoost <= 0 && acceleration < 50)
        {
            speedBoost = 4f;
            acceleration++;
        }
        if (itisDone == false)
        {
        scoreCount++;
        }
        score.text = "Score: " + scoreCount.ToString();
        if (Input.GetKey(KeyCode.A) && transform.position.x > -3.5f)
        {
            transform.Translate(Vector3.left * acceleration * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 3.5f)
        {
            transform.Translate(Vector3.right * acceleration * Time.deltaTime);
        }
         
    #if UNITY_ANDROID && !UNITY_EDITOR
      if (Input.touchCount > 0 && transform.position.x >= -3.5f && transform.position.x <= 3.5f)
        {
            touchInput = Input.GetTouch(0);
            transform.Translate(touchInput.deltaPosition.x * modifySpeed, 0, 0);
            Debug.Log("touch registered");
        }
        else if (transform.position.x > -3.5f)
        {
            transform.position = new Vector3(-3.49f, transform.position.y, transform.position.z);
            Debug.Log("touch registered");

        }
        else if (transform.position.x < 3.5f)
        {
            transform.position = new Vector3(3.49f, transform.position.y, transform.position.z);
            Debug.Log("touch registered");

        }
        

    #endif

          // TO FIX TOUCH INPUT!!!
           transform.Translate(Vector3.forward * acceleration * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision other) {
    
        if (other.gameObject.tag ==  "Foe")
        {
         StartCoroutine("Reload");
         itisDone = true;
         gameoverTxt.enabled = true;
       // ModalManager.Show("Game Over", "Do you like to revive yourself?", new[] { new ModalButton() { Text = "Watch an Ad", Callback = reviveAd }, new ModalButton() { Text = "Give up", Callback = reloadGame } });
       GetComponent<MeshRenderer>().enabled = false;
       gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
        if (PlayerPrefs.GetFloat("Highscore") < scoreCount)
        {
            PlayerPrefs.SetFloat("Highscore", scoreCount);
            PlayerPrefs.SetFloat("Score", scoreCount);
        }
        else 
        {
             PlayerPrefs.SetFloat("Score", scoreCount);
        }

        }
    }

//TO DO
     /*   void reloadGame()
        {
        Debug.Log("GAME OVER G A M E O V E R");
        Debug.Log("Your score is = " + PlayerPrefs.GetFloat("Score"));
        Debug.Log("Your High Score is = " + PlayerPrefs.GetFloat("Highscore"));
        Destroy(gameObject);
        SceneManager.LoadScene("Reload Menu");
        }
        void reviveAd()
        {
            itisDone = false;
            transform.position = new Vector3(0.00f, transform.position.y, transform.position.z);

            GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponentInChildren<TrailRenderer>().enabled = false;
        }
*/

 IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("GAME OVER G A M E O V E R");
        Debug.Log("Your score is = " + PlayerPrefs.GetFloat("Score"));
        Debug.Log("Your High Score is = " + PlayerPrefs.GetFloat("Highscore"));
        Destroy(gameObject);
        SceneManager.LoadScene("Reload Menu");

    }   

}
