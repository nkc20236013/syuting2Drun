using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3 : MonoBehaviour
{
    public void OnclickStartButton()
    {
        SceneManager.LoadScene("GameScene3");
    }
}
