using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerCon : MonoBehaviour
{
    Vector3 dir;
    float speed;
    Animator animator;


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

        if(dir.x!=0)
        {
            transform.localScale = new Vector3(dir.x, 1, 1);
        }
    }


}
