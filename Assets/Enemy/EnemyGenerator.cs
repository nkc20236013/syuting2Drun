using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyG : MonoBehaviour
{
    public GameObject kuziraPre;
    //このspanは固定でなくてもいい
    float span = 1.4f;
    //このmouseは固定でなくてもいい
    float mouse = 0;

    int random;
    int randoma;
    public GameObject Boss;
    public GameObject Boss2;
    public GameObject Boss3;
    float Bosstime;
    float Bossspan = 30;
    Transform Player;

    PlayerCon pc;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerCon>();
        Player = GameObject.Find("Player").transform;
    }


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
                go.transform.position = new Vector3(Player.position.x + 10, 0, 0);
            }
            else
            {
                randoma = Random.Range(0, 100);
                if(randoma <= 50)
                {
                    Bosstime = 0;
                    GameObject go = Instantiate(Boss2);
                    go.transform.position = new Vector3(Player.position.x + 10, 0, 0);
                }
                else
                {
                    Bosstime = 0;
                    GameObject go = Instantiate(Boss3);
                    go.transform.position = new Vector3(Player.position.x + 10, 0, 0);
                }
            }
        }

        if (mouse > span)
        {
            mouse = 0;
            span -= (span >= 0.5f) ? 0.02f : 0f;

            GameObject go = Instantiate(kuziraPre);
            float py = Random.Range(-4.2f,-4.2f);
            go.transform.position = new Vector3(28, py, 0);
        }
    }
}
