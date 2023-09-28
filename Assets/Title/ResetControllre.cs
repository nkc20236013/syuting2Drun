using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetControllre : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Appear()
    {
        popup.SetActive(true);
        PlayerPrefs.DeleteAll();
    }
    public void Delete()
    {
        popup.SetActive(false);
    }

}
