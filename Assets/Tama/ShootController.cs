using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = 15f;             // ’e‘¬“x
        Destroy(gameObject, 2f); // õ–½‚Q•b
    }

    void Update()
    {
        // ˆÚ“®
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // d‚È‚è”»’è
    void OnTriggerEnter2D(Collider2D e)
    {
        // d‚È‚Á‚½‘Šè‚Ìƒ^ƒO‚ªyEnemyz‚¾‚Á‚½‚ç
        if (e.tag == "Enemy")
        {
            // ©’eíœ
            Destroy(gameObject);
        }
    }
}
