using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    Vector3 pos;                // 出現位置
    float speed;                // 落下速度

    public enum ITEM_TYPE
    {
        SPEED_UP = 0,   // 速度アップ
        SHOT_UP,        // ショットアップ
    }

    [SerializeField] float moveSpeed = 2.0f;                    // 移動値
    [SerializeField] ITEM_TYPE itemType = ITEM_TYPE.SPEED_UP;   // アイテムタイプ

    void Start()
    {

    }

    void Update()
    {
        float addMove = -moveSpeed * Time.deltaTime;
        transform.Translate(addMove, 0, 0);
    }

    // タイプの取得
    public ITEM_TYPE GetItemType()
    {
        return itemType;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // アイテムにヒット
    //    if (other.gameObject.CompareTag("Item"))
    //    {
    //        ItemController item = other.gameObject.GetComponent<ItemController>();

    //        if (item)
    //        {
    //            switch (item.GetItemType())
    //            {
    //                // 移動スピードアップ
    //                case ItemController.ITEM_TYPE.SPEED_UP:
    //                    {
    //                        ++moveSpeedIndex;
    //                        moveSpeedIndex = Mathf.Min(moveSpeedIndex, MoveSpeedList.Count - 1);

    //                        SoundManager.Instance.PlaySe("speed_up");
    //                    }
    //                    break;
    //            }
    //        }

    //        // アイテムを消す
    //        Destroy(other.gameObject);
    //    }
    //}
}
