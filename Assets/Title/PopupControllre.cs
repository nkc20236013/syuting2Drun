using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupControllre : MonoBehaviour
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
    }
    public void Delete()
    {
        popup.SetActive(false);
    }

}
