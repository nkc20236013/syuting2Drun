using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    public void OnclickStartButton()
    {
        SceneManager.LoadScene("GameScene2");
    }
}
