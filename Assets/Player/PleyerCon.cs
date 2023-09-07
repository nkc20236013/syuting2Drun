using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // �ړ������ۑ�
    float speed;    // �ړ����x�ۑ�
    float timer;    // ���e�̔��ˊԊu�v�Z�p
    Animator animator;   // �A�j���[�^�[�R���|�[�l���g��ۑ�

    public GameObject kedamaPre; // �e�̃v���n�u���Z�b�g

    int shotLevel;  // ����̃��x��

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

        //�R�R��player�ł���L�̓������\������
        speed = 7;
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        float speedx = Mathf.Abs(dir.x);

        // ��ʓ�����
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        pos.y = Mathf.Clamp(pos.y, -4.25f, 4.25f);
        transform.position = pos;

        this.animator.speed = speedx / 1.5f;

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

        if (dir.x!=0)
        {
            transform.localScale = new Vector3(dir.x, 1, 1);
        }
    }


}
