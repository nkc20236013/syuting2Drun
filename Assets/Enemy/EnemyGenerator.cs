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
