using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackgroundController : MonoBehaviour
{
    [SerializeField, Header("視差効果"),Range(0,1)]
    public float parallaxEffect;
    private float length, startposX;
    public GameObject cam;
    void Start()
    {
        // 背景画像のx座標
        startposX = transform.position.x;
        // 背景画像のx軸方向の幅
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // 無限スクロールに使用するパラメーター
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // 背景の視差効果に使用するパラメーター
        float dist = (cam.transform.position.x * parallaxEffect);
        // 視差効果を与える処理
        // 背景画像のx座標をdistの分移動させる
        transform.position = new Vector3(startposX + dist, transform.position.y, transform.position.z);
        // 無限スクロール
        // 画面外になったら背景画像を移動させる
        if (temp > startposX + length) startposX += length;
        else if (temp < startposX - length) startposX -= length;
    }
}
