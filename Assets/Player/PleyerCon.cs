using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;    // �ړ�����
    float speed;    // �ړ����x
    Animator anim;

    void Start()
    {
        //�R�R��player�ł���L�̓������\������

        speed = 5; // �X�s�[�h�����l
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //���E�ړ�
        dir.x = Input.GetAxisRaw("Horizontal");
        transform.position += dir.normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if(dir.x != 0)
        {
            transform.localScale = new Vector3(dir.x, 5, 1);
        }

        //if (dir.x == 0) anim.Play("neutral");
        //else if (dir.x == 1) anim.Play("LMove");
        //else if (dir.x == -1) anim.Play("RMove");
    }
}
