using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControllre : MonoBehaviour
{
    public int stage_num;
    public GameObject ni;
    public GameObject san;
    public GameObject yon;

    void Start()
    {
        stage_num = PlayerPrefs.GetInt("SCORE", 0);
    }

    void Update()
    {
        if (stage_num >= 2)
        {
            ni.SetActive(true);
        }
        if (stage_num >= 3)
        {
            san.SetActive(true);
        }
        if(stage_num >= 4)
        {
            yon.SetActive(true);
        }
    }
}
