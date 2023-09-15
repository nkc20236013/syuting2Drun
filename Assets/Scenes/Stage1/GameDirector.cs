using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    PleyerCon pc;

    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PleyerCon>();
    }


    void Update()
    {
        // HPが1より小さくなったらゲームオーバーシーンへ
        if (pc.HP < 1)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
