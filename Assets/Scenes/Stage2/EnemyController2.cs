using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    float speed;                // 移動速度を保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 1.5f;    // 弾の発射間隔
    GameDirector gd;

    void Start()
    {
        //ココに敵であるねずみの挙動を構成する

        Destroy(gameObject, 6);		    // 寿命
        enemyType = Random.Range(0, 3); // 敵の種類
        speed = 5.6f;                      // 移動速度
        dir = Vector3.left;             // 移動方向
        rad = Time.time;                // サインカーブの動きをずらす用
        shotTime = 0.3f;                   // 弾発射間隔計算用
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // エネミータイプ２だけ縦移動（サインカーブ）追加
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
        }

        // 移動処理
        transform.position += dir.normalized * speed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D p)
    {
        // 重なった相手のタグが【Player】だったら
        if (p.tag == "Player")
        {
            // 自分（敵）削除
            Destroy(gameObject);
        }

        // 重なった相手のタグが【PlayerShot】だったら
        if (p.tag == "PlayerShot")
        {
            // 自分（敵）削除
            Destroy(gameObject);
            gd.Score += 100;
        }
    }
}

