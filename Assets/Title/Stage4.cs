using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage4 : MonoBehaviour
{
    public void OnclickStartButton()
    {
        SceneManager.LoadScene("GameScene4");
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
