using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // 移動方向
    float speed;    // 移動速度
    Animator anim;

    void Start()
    {
        //ココにplayerである猫の動きを構成する

        speed = 5; // スピード初期値
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //左右移動
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if(dir.x != 0)
        {
            transform.localScale = new Vector3(dir.x, 5, 1);
        }

        //if (dir.x == 0) anim.Play("neutral");
        //else if (dir.x == 1) anim.Play("LMove");
        //else if (dir.x == -1) anim.Play("RMove");
    }
}
