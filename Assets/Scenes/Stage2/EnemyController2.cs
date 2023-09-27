using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    float speed;                // �ړ����x��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 1.5f;    // �e�̔��ˊԊu
    GameDirector gd;

    void Start()
    {
        //�R�R�ɓG�ł���˂��݂̋������\������

        Destroy(gameObject, 6);		    // ����
        enemyType = Random.Range(0, 3); // �G�̎��
        speed = 5.6f;                      // �ړ����x
        dir = Vector3.left;             // �ړ�����
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        shotTime = 0.3f;                   // �e���ˊԊu�v�Z�p
        gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // �G�l�~�[�^�C�v�Q�����c�ړ��i�T�C���J�[�u�j�ǉ�
        if (enemyType == 2)
        {
            dir.y = Mathf.Sin(rad + Time.time * 5f);
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
            // �����i�G�j�폜
            Destroy(gameObject);
            gd.Score += 100;
        }
    }
}

