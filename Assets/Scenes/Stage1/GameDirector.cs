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
        // HP��1��菬�����Ȃ�����Q�[���I�[�o�[�V�[����
        if (pc.HP < 1)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
