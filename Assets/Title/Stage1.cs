using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    public void OnclickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void finish()
    {
        Invoke("Call", 3f);
    }

    void Call()
    {
        OnclickStartButton();
    }

}
