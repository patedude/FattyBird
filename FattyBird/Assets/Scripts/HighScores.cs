using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    //public Text highestScore; // Korkein tulos

    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        //highScore.BirdDied();
    }
}
