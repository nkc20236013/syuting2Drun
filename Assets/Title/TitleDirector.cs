using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleDirector : MonoBehaviour
{
    public Text score1Label;
    public Text score2Label;
    public Text score3Label;
    public Text score4Label;
    private int Score1;
    private int Score2;
    private int Score3;
    private int Score4;
    private string key1 = "HIGH SCORE1";
    private string key2 = "HIGH SCORE2";
    private string key3 = "HIGH SCORE3";
    private string key4 = "HIGH SCORE4";


    void Start()
    {
        // ハイスコアリセット用
        PlayerPrefs.DeleteAll();

        Score1 = PlayerPrefs.GetInt(key1, 0);
        score1Label.text = "HighScore\n" + Score1.ToString("D6");

        Score2 = PlayerPrefs.GetInt(key2, 0);
        score2Label.text = "HighScore\n" + Score2.ToString("D6");

        Score3 = PlayerPrefs.GetInt(key3, 0);
        score3Label.text = "HighScore\n" + Score3.ToString("D6");

        Score4 = PlayerPrefs.GetInt(key4, 0);
        score4Label.text = "HighScore\n" + Score4.ToString("D6");
    }

    void Update()
    {
        if (GameDirector.score > Score1)
        {
            Score1 = GameDirector.score;
            PlayerPrefs.SetInt(key1, Score1);
            score1Label.text = "HighScore\n" + Score1.ToString("D6");
        }
        if (GameDirector2.score >  Score2)
        {
            Score2 = GameDirector2.score;
            PlayerPrefs.SetInt(key2, Score2);
            score2Label.text = "HighScore\n" + Score2.ToString("D6");
        }
        if (GameDirector3.score > Score3)
        {
            Score3 = GameDirector3.score;
            PlayerPrefs.SetInt(key3, Score3);
            score3Label.text = "HighScore\n" + Score3.ToString("D6");
        }
        if (GameDirector4.score > Score4)
        {
            Score4 = GameDirector4.score;
            PlayerPrefs.SetInt(key4, Score4);
            score4Label.text = "HighScore\n" + Score4.ToString("D6");
        }

    }
}
