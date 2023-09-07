using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // 移動方向保存
    float speed;    // 移動速度保存
    float timer;    // 自弾の発射間隔計算用
    Animator animator;   // アニメーターコンポーネントを保存

    public GameObject kedamaPre; // 弾のプレハブをセット

    int shotLevel;  // 武器のレベル

    public int ShotLevel
    {
        set
        {
            shotLevel = value;
            shotLevel = Mathf.Clamp(shotLevel, 0, 12);
        }
        get { return shotLevel; }
    }

    // 自キャラのスピードの値を他のスクリプトから
    // 参照・変更するためのプロパティ
    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 1, 20);
        }
        get { return speed; }
    }


    void Start()
    {

        //ココにplayerである猫の動きを構成する
        speed = 7;
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        float speedx = Mathf.Abs(dir.x);

        // 画面内制限
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        pos.y = Mathf.Clamp(pos.y, -4.25f, 4.25f);
        transform.position = pos;

        this.animator.speed = speedx / 1.5f;

        // Zキーが押されているとき弾を発射
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;
            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // 弾の生成位置はプレーヤーと同じ場所
                Vector3 p = transform.position;

                // プレーヤーの回転角度を取得し、15度ずつずらした方向に弾を回転させる
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // 位置と回転情報をセットして生成
                Instantiate(kedamaPre, p, rot);
            }
        }

        if (dir.x!=0)
        {
            transform.localScale = new Vector3(dir.x, 1, 1);
        }
    }


}
