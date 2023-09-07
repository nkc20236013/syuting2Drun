using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyG : MonoBehaviour
{
    public GameObject kuziraPre;
    //‚±‚Ìspan‚ÍŒÅ’è‚Å‚È‚­‚Ä‚à‚¢‚¢
    float span = 1.4f;
    //‚±‚Ìmouse‚ÍŒÅ’è‚Å‚È‚­‚Ä‚à‚¢‚¢
    float mouse = 0;

    
    void Update()
    {
        mouse += Time.deltaTime;

        if (mouse > span)
        {
            mouse = 0;
            span -= (span >= 0.5f) ? 0.02f : 0f;

            GameObject go = Instantiate(kuziraPre);
            int py = Random.Range(-5, 6);
            go.transform.position = new Vector3(10, py, 0);
        }
    }
}
