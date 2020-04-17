using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    public Text ScoreText;
    public int Score=0;
    public GameObject gameOvertext;
    public bool gameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    
    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bomb")
        {
            gameOvertext.SetActive(true);
            gameOver = true;
        }  
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (gameOver)
            return;
        if(target.tag=="Fruit")
        {
            Destroy(target.gameObject);
            Score++;
        }
    }
}
