using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;                // �ړ����x��ۑ�
    Vector3 dir;                // �ړ�������ۑ�
    int enemyType;              // �G�̎�ނ�ۑ�
    float rad;                  // �G�̓����T�C���J�[�u�p
    float shotTime;             // �e�̔��ˊԊu�v�Z�p
    float shotInterval = 1.5f;    // �e�̔��ˊԊu

    void Start()
    {
        //�R�R�ɓG�ł���˂��݂̋������\������

        Destroy(gameObject, 6);		    // ����
        enemyType = Random.Range(0, 3); // �G�̎��
        speed = 5;                      // �ړ����x
        dir = Vector3.left;             // �ړ�����
        rad = Time.time;                // �T�C���J�[�u�̓��������炷�p
        shotTime = 0;                   // �e���ˊԊu�v�Z�p
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
