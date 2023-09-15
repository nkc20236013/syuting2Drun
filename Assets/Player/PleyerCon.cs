using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // �ړ������ۑ�
    float speed;    // �ړ����x�ۑ�
    float timer;    // ���e�̔��ˊԊu�v�Z�p
    Animator animator;   // �A�j���[�^�[�R���|�[�l���g��ۑ�

    private Rigidbody2D rb;

    private float jumpForce = 350f; //�W�����v��

    public int MaxJumpCount = 2; //�ő�W�����v��

    private int jumpCount = 0;  //�W�����v��

    public GameObject kedamaPre; // �e�̃v���n�u���Z�b�g

    int shotLevel;  // ����̃��x��

    int hp; // �c��HP

    //�ő�HP�ƌ��݂�HP�B
    public int maxHp = 10;
    public int Hp;
    //Slider

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




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //�R�R��player�ł���L�̓������\������
        speed = 7;
        this.animator = GetComponent<Animator>();
        hp = 10;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        //�n�ʂɓ���������W�����v�J�E���g��0�ɂȂ�
        if (other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        //Enemy�^�O��ݒ肵�Ă���I�u�W�F�N�g�ɐڐG�����Ƃ�
        if (collider.gameObject.tag == "Enemy")
        {
            //HP����1������
            Hp = Hp - 1;


        }
    }



}
