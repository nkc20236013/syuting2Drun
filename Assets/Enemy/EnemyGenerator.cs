using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyG : MonoBehaviour
{
    public GameObject kuziraPre;
    //����span�͌Œ�łȂ��Ă�����
    float span = 1.4f;
    //����mouse�͌Œ�łȂ��Ă�����
    float mouse = 0;

    int random;
    int randoma;
    public GameObject Boss;
    public GameObject Boss2;
    public GameObject Boss2R;
    float Bosstime;
    float Bossspan = 30;

    
    void Update()
    {
        mouse += Time.deltaTime;
        Bosstime += Time.deltaTime;
        if(Bosstime >= Bossspan)
        {
            random = Random.Range(0, 100);
            if (random <= 50)
            {
                Bosstime = 0;
                GameObject go = Instantiate(Boss);
                go.transform.position = new Vector3(10, 0, 0);
            }
            else
            {
                randoma = Random.Range(0, 100);
                if(randoma <= 50)
                {
                    Bosstime = 0;
                    GameObject go = Instantiate(Boss2);
                    go.transform.position = new Vector3(10, 0, 0);
                }
                else
                {
                    Bosstime = 0;
                    GameObject go = Instantiate(Boss2R);
                    go.transform.position = new Vector3(10, 0, 0);
                }
            }
        }

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
