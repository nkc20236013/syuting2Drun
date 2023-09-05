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

    void Start()
    {
         speed = 5f;
    }

    void Update()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        transform.position += dir.normalized * speed * Time.deltaTime;
        if(S1 == true && Input.GetButtonDown("Fire1"))
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
    }
}
