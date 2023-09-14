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

    void Start()
    {
        score2Label.text = "Score\n" + GameDirector2.score.ToString("D6");
        score3Label.text = "Score\n" + GameDirector3.score.ToString("D6");
        score4Label.text = "Score\n" + GameDirector4.score.ToString("D6");
    }

    void Update()
    {
        
    }
}
