using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 15f;             // �e���x
        Destroy(gameObject, 2f); // �����Q�b
    }

    void Update()
    {
        // �ړ�
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // �d�Ȃ蔻��
    void OnTriggerEnter2D(Collider2D e)
    {
        // �d�Ȃ�������̃^�O���yEnemy�z��������
        if (e.tag == "Enemy")
        {
            // ���e�폜
            Destroy(gameObject);
        }
    }
}
