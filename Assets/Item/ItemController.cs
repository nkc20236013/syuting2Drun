using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    Vector3 pos;                // �o���ʒu
    float speed;                // �������x

    public enum ITEM_TYPE
    {
        SPEED_UP = 0,   // ���x�A�b�v
        SHOT_UP,        // �V���b�g�A�b�v
    }

    [SerializeField] float moveSpeed = 2.0f;                    // �ړ��l
    [SerializeField] ITEM_TYPE itemType = ITEM_TYPE.SPEED_UP;   // �A�C�e���^�C�v

    void Start()
    {

    }

    void Update()
    {
        float addMove = -moveSpeed * Time.deltaTime;
        transform.Translate(addMove, 0, 0);
    }

    // �^�C�v�̎擾
    public ITEM_TYPE GetItemType()
    {
        return itemType;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // �A�C�e���Ƀq�b�g
    //    if (other.gameObject.CompareTag("Item"))
    //    {
    //        ItemController item = other.gameObject.GetComponent<ItemController>();

    //        if (item)
    //        {
    //            switch (item.GetItemType())
    //            {
    //                // �ړ��X�s�[�h�A�b�v
    //                case ItemController.ITEM_TYPE.SPEED_UP:
    //                    {
    //                        ++moveSpeedIndex;
    //                        moveSpeedIndex = Mathf.Min(moveSpeedIndex, MoveSpeedList.Count - 1);

    //                        SoundManager.Instance.PlaySe("speed_up");
    //                    }
    //                    break;
    //            }
    //        }

    //        // �A�C�e��������
    //        Destroy(other.gameObject);
    //    }
    //}
}
