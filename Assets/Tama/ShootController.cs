using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 15f;             // 弾速度
        Destroy(gameObject, 2f); // 寿命２秒
    }

    void Update()
    {
        // 移動
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // 重なり判定
    void OnTriggerEnter2D(Collider2D e)
    {
        // 重なった相手のタグが【Enemy】だったら
        if (e.tag == "Enemy")
        {
            // 自弾削除
            Destroy(gameObject);
        }
    }
}
