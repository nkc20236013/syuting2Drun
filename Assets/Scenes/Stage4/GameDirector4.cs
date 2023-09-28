using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector4 : MonoBehaviour
{
    public Text scoreLabel;

    public static int score;

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
    }
}
