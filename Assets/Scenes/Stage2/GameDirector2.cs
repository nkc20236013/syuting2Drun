using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector2 : MonoBehaviour
{
    public Text scoreLabel;

    public static int score;

    PleyerCon pc;

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
        scoreLabel.text = "Score " + score.ToString("D7");
        if (score >= 1000)
        {
            PlayerPrefs.SetInt("SCORE", 3);
            PlayerPrefs.Save();
        }
        // HPが1より小さくなったらゲームオーバーシーンへ
        if (pc.HP < 1)
        {
            SceneManager.LoadScene("GameOverScene");

        }
    }
}
