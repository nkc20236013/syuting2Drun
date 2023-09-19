using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class GameDirector : MonoBehaviour
    {
        public Text scoreLabel;

        public static int score;

        float delta;
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

            pc = GameObject.Find("Player").GetComponent<PleyerCon>();

        }

        void Update()
        {
            delta += Time.deltaTime;
            scoreLabel.text = "Score " + score.ToString("D6");
            if (delta >= 30)
            {
                SceneManager.LoadScene("TitleScene");
            }
            // HPが1より小さくなったらゲームオーバーシーンへ
            if (pc.HP < 1)
            {
                SceneManager.LoadScene("GameOverScene");

            }
        }
    }
