using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    Vector3 dir;
    float delta;
    float rad;
    float speed;
    int HP;
    Transform player;


    void Start()
    {
        dir = Vector3.left;
        HP = 50;
        rad = Time.time;
        speed = 5f;
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (transform.position.x <= player.position.x + 6)
        {
            dir.y = Mathf.Sin(rad + Time.time * 2f);
            gameObject.transform.position = new Vector3(player.position.x + 6, dir.y, dir.x);
        }
        transform.position += dir.normalized * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerShot")
        {
            HP -= 1;
            if(HP == 0)
            {
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}
