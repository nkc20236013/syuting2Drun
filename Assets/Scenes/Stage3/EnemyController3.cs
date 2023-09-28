using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController3 : MonoBehaviour
{
    [SerializeField] GameObject itemObj;          // アイテムオブジェクト
    float speed;                // 移動速度を保存
    float speed2;                // 移動速度を保存
    Vector3 dir;                // 移動方向を保存
    int enemyType;              // 敵の種類を保存
    float rad;                  // 敵の動きサインカーブ用
    float shotTime;             // 弾の発射間隔計算用
    float shotInterval = 1.5f;    // 弾の発射間隔
    public Slider slider;
    PlayerCon pc;
    GameDirector3 gd;
    int HP;

    void Start()
    {
        //ココに敵であるねずみの挙動を構成する

        Destroy(gameObject, 7);		    // 寿命
        enemyType = Random.Range(0, 3); // 敵の種類
        speed = 5.6f;                      // 移動速度
        speed2 = 10f;                      // 移動速度
        dir = Vector3.left;             // 移動方向
        rad = Time.time;                // サインカーブの動きをずらす用
        shotTime = 0.3f;                   // 弾発射間隔計算用
        HP = 2;                            //敵のHP
        //pc = GameObject.Find("PleyerCon").GetComponent<PleyerCon>();
        gd = GameObject.Find("GameDirector3").GetComponent<GameDirector3>();
        //enemyType2だけHP1
        if (enemyType == 2)
        {
            HP = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // エネミータイプ２だけ速い
        if (enemyType == 2)
        {
            transform.position += dir.normalized * speed2 * Time.deltaTime;
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
            HP -= 1;
            if (HP == 0)
            {
                // 自分（敵）削除
                Destroy(gameObject);
                gd.Score += 100;
            }
        }

        // 当たったのがプレイヤーの弾
        if (p.gameObject.CompareTag("PlayerShot"))
        {
            float rnd = Random.Range(0, 100f);

            // アイテムがセットされていれば生成
            if (rnd <= 2)
            {
                Instantiate(itemObj, transform.position, Quaternion.identity);
            }
        }
    }
}

