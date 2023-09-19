using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // �ړ������ۑ�
    [SerializeField, Header("�ړ����x")]
    float speed;    // �ړ����x�ۑ�
    float timer;    // ���e�̔��ˊԊu�v�Z�p
    Animator animator;   // �A�j���[�^�[�R���|�[�l���g��ۑ�

    private Rigidbody2D rb;

    private float jumpForce = 350f; //�W�����v��

    public int MaxJumpCount = 2; //�ő�W�����v��

    private int jumpCount = 0;  //�W�����v��

    public GameObject kedamaPre; // �e�̃v���n�u���Z�b�g

    int shotLevel;  // ����̃��x��

    //�ő�HP�ƌ��݂�HP�B
    float maxHp = 100;
    float Hp;
    //Slider
    public Slider slider;


    public int ShotLevel
    {
        set
        {
            shotLevel = value;
            shotLevel = Mathf.Clamp(shotLevel, 0, 12);
        }
        get { return shotLevel; }
    }

    // ���L�����̃X�s�[�h�̒l�𑼂̃X�N���v�g����
    // �Q�ƁE�ύX���邽�߂̃v���p�e�B
    public float Speed
    {
        set
        {
            speed = value;
            speed = Mathf.Clamp(speed, 1, 20);
        }
        get { return speed; }
    }
    public float MaxHp
    {
        set
        {
            maxHp = value;
            maxHp = Mathf.Clamp(maxHp, 0, 10);
        }
        get { return maxHp; }
    }
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

        //Slider���ő�ɂ���B
        slider.value = 1;
        //HP���ő�HP�Ɠ����l�ɁB
        Hp = maxHp;
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        float speedx = Mathf.Abs(dir.x);

        // ��ʓ�����
        Vector2 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, -20f, 20f);
        //pos.y = Mathf.Clamp(pos.y, -4.25f, 4.25f);
        transform.position = pos;

        this.animator.speed = speedx / 1.5f;

        //�X�y�[�X�L�[�ŃW�����v
        if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < MaxJumpCount) //�n�ʂɂ��܂� < �Z��܂ŃW�����v�o����
        {
            this.rb.AddForce(transform.up * jumpForce);
            jumpCount++;
        }

        // Z�L�[��������Ă���Ƃ��e�𔭎�
        timer += Time.deltaTime;
        if (timer >= 0.3f && Input.GetKey(KeyCode.Z))
        {
            timer = 0;
            shotLevel = (shotLevel < 0) ? 0 : shotLevel;
            for (int i = -shotLevel; i < shotLevel + 1; i++)
            {
                // �e�̐����ʒu�̓v���[���[�Ɠ����ꏊ
                Vector3 p = transform.position;

                // �v���[���[�̉�]�p�x���擾���A15�x�����炵�������ɒe����]������
                Quaternion rot = Quaternion.identity;
                rot.eulerAngles = transform.rotation.eulerAngles + new Vector3(0, 0, 15f * i);

                // �ʒu�Ɖ�]�����Z�b�g���Đ���
                Instantiate(kedamaPre, p, rot);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D ot)
    {
        //�n�ʂɓ���������W�����v�J�E���g��0�ɂȂ�
        if (ot.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Enemy�^�O��ݒ肵�Ă���I�u�W�F�N�g�ɐڐG�����Ƃ�
        if (collider.tag == "Enemy")
        {
            //HP����10������
            Hp = Hp -10;

            Debug.Log("�A�^��");

            //HP��Slider�ɔ��f�B
            slider.value = (float)Hp / (float)maxHp;


        }
    }

    ////private void OnTriggerEnter2D(Collider2D other)
    ////{
    ////    // �A�C�e���Ƀq�b�g
    ////    if (other.gameObject.CompareTag("Item"))
    ////    {
    ////        ItemController item = other.gameObject.GetComponent<ItemController>();

    ////        if (item)
    ////        {
    ////            switch (item.GetItemType())
    ////            {
    ////                // �ړ��X�s�[�h�A�b�v
    ////                case ItemController.ITEM_TYPE.SPEED_UP:
    ////                    {
    ////                        ++moveSpeedIndex;
    ////                        moveSpeedIndex = Mathf.Min(moveSpeedIndex, MoveSpeedList.Count - 1);

    ////                        SoundManager.Instance.PlaySe("speed_up");
    ////                    }
    ////                    break;
    ////            }
    ////        }

    ////        // �A�C�e��������
    ////        Destroy(other.gameObject);
    ////    }
    //}



}
