using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController3 : MonoBehaviour
{
    [SerializeField] GameObject itemObj;          // �A�C�e���I�u�W�F�N�g
    float speed;                // �ړ����x��ۑ�
    float speed2;                // �ړ����x��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 1.5f;    // �e�̔��ˊԊu
    public Slider slider;
    PlayerCon pc;
    GameDirector3 gd;
    int HP;

    void Start()
    {
        //�R�R�ɓG�ł���˂��݂̋������\������

        Destroy(gameObject, 7);		    // ����
        enemyType = Random.Range(0, 3); // �G�̎��
        speed = 5.6f;                      // �ړ����x
        speed2 = 10f;                      // �ړ����x
        dir = Vector3.left;             // �ړ�����
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        shotTime = 0.3f;                   // �e���ˊԊu�v�Z�p
        HP = 2;                            //�G��HP
        //pc = GameObject.Find("PleyerCon").GetComponent<PleyerCon>();
        gd = GameObject.Find("GameDirector3").GetComponent<GameDirector3>();
        //enemyType2����HP1
        if (enemyType == 2)
        {
            HP = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // �G�l�~�[�^�C�v�Q��������
        if (enemyType == 2)
        {
            transform.position += dir.normalized * speed2 * Time.deltaTime;
        }

        // �ړ�����
        transform.position += dir.normalized * speed * Time.deltaTime;

    }

    void OnTriggerEnter2D(Collider2D p)
    {
        // �d�Ȃ�������̃^�O���yPlayer�z��������
        if (p.tag == "Player")
        {
            // �����i�G�j�폜
            Destroy(gameObject);
        }

        // �d�Ȃ�������̃^�O���yPlayerShot�z��������
        if (p.tag == "PlayerShot")
        {
            HP -= 1;
            if (HP == 0)
            {
                // �����i�G�j�폜
                Destroy(gameObject);
                gd.Score += 100;
            }
        }

        // ���������̂��v���C���[�̒e
        if (p.gameObject.CompareTag("PlayerShot"))
        {
            float rnd = Random.Range(0, 100f);

            // �A�C�e�����Z�b�g����Ă���ΐ���
            if (rnd <= 2)
            {
                Instantiate(itemObj, transform.position, Quaternion.identity);
            }
        }
    }
}

