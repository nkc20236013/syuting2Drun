using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cursorControllre : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    float speed;
    bool S1 = false;
    bool S2 = false;
    bool S3 = false;
    bool S4 = false;
    bool rule = false;

    void Start()
    {
        speed = 5f;
    }

    void Update()
    {
        // ÉJÅ[É\ÉãëÄçÏ
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;
        // âÊñ ì‡êßå¿
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 9f);
        pos.y = Mathf.Clamp(pos.y, -5f, 5f);
        transform.position = pos;
        if (S1 == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (S2 == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene2");
        }
        if (S3 == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene3");
        }
        if (S4 == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("GameScene4");
        }
        if (rule == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Rule");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "S1")
        {
            S1 = true;
        }
        if(collision.tag == "S2")
        {
            S2 = true;
        }
        if (collision.tag == "S3")
        {
            S3 = true;
        }
        if (collision.tag == "S4")
        {
            S4 = true;
        }
        if (collision.tag == "rule")
        {
            rule = true;
        }
    }
}
