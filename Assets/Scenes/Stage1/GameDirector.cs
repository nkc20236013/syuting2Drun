using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Text scoreLabel;

    public static int score;

    float delta;

    public int Score
    {
        set
        {
            score = value;
            score = Mathf.Clamp(score, 0, 999999);
        }
        get { return score; }
    }
    void Start()
    {
        score = 0;
        
    }

    void Update()
    {
        delta += Time.deltaTime;
        scoreLabel.text = "Score " + score.ToString("D6");
        if(delta >= 30)
        {
            if (score >= 1000)
            {
                PlayerPrefs.SetInt("SCORE", 2);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene("TitleScene");
        }
    }
}
