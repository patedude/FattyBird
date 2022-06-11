using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance; // GameControlleriin pääsee muista scripteistä
    public Text scoreText; // Pistelaskuri
    public Text highScore; // Korkein tulos
    public GameObject gameOvertext; // Game over ruutu

    private int score = 0; // Pisteet
    public bool gameOver = false; // Onko peli loppunut
    public float scrollSpeed = -1.5f;
    public float scrollSpeed2 = -2f;


    void Awake()
    {
        highScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        // Laskee pisteet ja näyttää ne ruudulla
        score++;
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOvertext.SetActive(true); // Game over ruutu aktivoituu
        // Kun tulee game over paras tulos päivittyy jos se on parempi kuin aikaisempi
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = "HIGHSCORE: " + score.ToString();
        }

        gameOver = true;
       // gameIsRunning = false;
        if (gameOver == true)
        {
            Time.timeScale = 0f;
        }
    }
}