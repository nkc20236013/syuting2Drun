using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCon2 : MonoBehaviour
{
    Vector3 dir;    // 移動方向保存
    [SerializeField, Header("移動速度")]
    float speed;    // 移動速度保存
    float timer;    // 自弾の発射間隔計算用
    Animator animator;   // アニメーターコンポーネントを保存

    private Rigidbody2D rb;

    private float jumpForce = 350f; //ジャンプ力

    public int MaxJumpCount = 2; //最大ジャンプ数

    private int jumpCount = 0;  //ジャンプ回数

    public GameObject kedamaPre; // 弾のプレハブをセット

    int shotLevel;  // 武器のレベル

    //最大HPと現在のHP。
    float maxHp = 100;
    float Hp;
    //Slider
    public Slider slider;

    public AudioClip jumpSE; //ジャンプ音
    private AudioSource audioSource;　//オーディオソース  


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
    // 自キャラのMaxHPを他のスクリプトから
    // 参照・変更するためのプロパティ
    public float MaxHp
    {
        set
        {
            maxHp = value;
            maxHp = Mathf.Clamp(maxHp, 0, 10);
        }
        get { return maxHp; }
    }
    // 自キャラのHPを他のスクリプトから
    // 参照・変更するためのプロパティ
    public float HP
    {
        set
        {
            Hp = value;
            Hp = Mathf.Clamp(Hp, 0, 10);
        }
        get { return Hp; }
    }




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        this.animator = GetComponent<Animator>();

        //Sliderを最大にする。
        slider.value = 1;
        slider.value = 10;
        //HPを最大HPと同じ値に。
        Hp = maxHp;

        audioSource = this.gameObject.GetComponent<AudioSource>(); //オーディオソース取得
    }


    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        float speedx = Mathf.Abs(dir.x);

        // 画面内制限
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        pos.y = Mathf.Clamp(pos.y, -4.25f, 4.25f);
        transform.position = pos;

        this.animator.speed = speedx / 1.5f;

        //スペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < MaxJumpCount) //地面につくまで < 〇回までジャンプ出来る
        {
            this.rb.AddForce(transform.up * jumpForce);
            jumpCount++;
            //GetComponent<AudioSource>().Play();  // 効果音を鳴らす
        }

        // Zキーが押されているとき弾を発射
        timer += Time.deltaTime;
        if (timer >= 0.8f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;
            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // 弾の生成位置はプレーヤーと同じ場所
                Vector3 p = transform.position;

                // プレーヤーの回転角度を取得し、15度ずつずらした方向に弾を回転させる
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 1f * i);

                // 位置と回転情報をセットして生成
                Instantiate(kedamaPre, p, rot);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D ot)
    {
        //地面に当たったらジャンプカウントが0になる
        if (ot.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }

        if (ot.gameObject.CompareTag("Item"))
        {
            // 強化処理
            Hp = Hp += 10;
            shotLevel += 1;

            slider.value = (float)Hp / (float)maxHp;

            // アイテムを消す
            Destroy(ot.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Enemyタグを設定しているオブジェクトに接触したとき
        if (collider.tag == "Enemy")
        {
            //HPから10を引く
            Hp = Hp - 10;

            GetComponent<AudioSource>().Play();  // 効果音を鳴らす

            //HPをSliderに反映。
            slider.value = (float)Hp / (float)maxHp;


        }
    }

}
