using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundController : MonoBehaviour
{
    [SerializeField, Header("��������"),Range(0,1)]
    public float parallaxEffect;
    private float length, startposX;
    public GameObject cam;
    void Start()
    {
        // �w�i�摜��x���W
        startposX = transform.position.x;
        // �w�i�摜��x�������̕�
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // �����X�N���[���Ɏg�p����p�����[�^�[
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // �w�i�̎������ʂɎg�p����p�����[�^�[
        float dist = (cam.transform.position.x * parallaxEffect);
        // �������ʂ�^���鏈��
        // �w�i�摜��x���W��dist�̕��ړ�������
        transform.position = new Vector3(startposX + dist, transform.position.y, transform.position.z);
        // �����X�N���[��
        // ��ʊO�ɂȂ�����w�i�摜���ړ�������
        if (temp > startposX + length) startposX += length;
        else if (temp < startposX - length) startposX -= length;
    }
}
